using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class BusinessIdSpecification : ISpecification<string>
    {
        public IEnumerable<string> ReasonsForDisatisfaction => _errors;

        readonly string idTemplate = "NNNNNNN-T";
        private IEnumerable<string> _errors;
        public bool IsSatisfiedBy(string entity)
        {
            //speksit luntattu: https://tarkistusmerkit.teppovuori.fi/tarkmerk.htm#y-tunnus2
            List<string> errors = new List<string>();
            try
            {
                //entity = entity.Trim();
                //annettu arvo pitää olla oikeassa muodossa (NNNNNNN-T)
                var regex = new Regex(@"^[0-9]{6,7}-[0-9]{1}$");
                if (string.IsNullOrEmpty(entity) || !regex.IsMatch(entity))
                    errors.Add($"Y-tunnus ei ole oikeassa muodossa ({idTemplate})");
                else
                {
                    //tarvittaessa lisätään alkuun nolla; numeroita oli aikaisemmin kuusi, ja tätä vanhaa muotoa voi hyvin harvoin nähdä vieläkin
                    if (entity.Length != idTemplate.Length)
                        entity = entity.Insert(0, "0");

                    char[] entityChars = entity.ToCharArray();
                    int tarkiste = int.Parse(entityChars[entityChars.Length - 1].ToString());
                    int[] kertoimet = { 7, 9, 10, 5, 8, 4, 2 };
                    int sum = 0;

                    //numeroita painotetaan vasemmalta lähtien kertoimilla & tulot lasketaan yhteen
                    for (int i = 0; i < kertoimet.Length; i++)
                    {
                        sum += int.Parse(entityChars[i].ToString()) * kertoimet[i];
                    }

                    //laskettu tarkiste
                    int calcedTarkiste = sum % 11;
                    //Jos jakojäännös on 0, tarkistusnumero on 0.
                    //Ei anneta tunnuksia, jotka tuottaisivat jakojäännöksen 1.
                    if (calcedTarkiste == 1)
                        errors.Add("Tunnuksen tarkiste ei voi olla 1");
                    //Jos jakojäännös on 2..10, tarkistusnumero on 11 miinus jakojäännös. 
                    else if (calcedTarkiste > 1)
                        calcedTarkiste = 11 - calcedTarkiste;

                    //tarkistetaan täsmääko annettu tarkiste laskettuun tarkisteeseen
                    if (tarkiste != calcedTarkiste)
                        errors.Add($"Tunnuksen tarkiste ({tarkiste}) ei täsmää laskettuun tarkisteeseen ({calcedTarkiste})");
                    else if (errors.Count == 0)
                        return true;
                }
            }
            catch (Exception e)
            {
                errors.Add(e.Message);
            }
            _errors = errors;
            return false;
        }
    }
}
