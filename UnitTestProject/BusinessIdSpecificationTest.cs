using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class BusinessIdSpecificationTest
    {
        [TestMethod]
        public void TestValidBusinessIds()
        {
            ClassLibrary.ISpecification<string> businessId = new ClassLibrary.BusinessIdSpecification();
            Assert.IsTrue(businessId.IsSatisfiedBy("8517418-0"));
            Assert.IsTrue(businessId.IsSatisfiedBy("3155130-7"));
            Assert.IsTrue(businessId.IsSatisfiedBy("3838802-0"));
            Assert.IsTrue(businessId.IsSatisfiedBy("1566507-2"));
            Assert.IsTrue(businessId.IsSatisfiedBy("6810385-8"));
        }

        [TestMethod]
        public void TestInvalidBusinessIds()
        {
            ClassLibrary.ISpecification<string> businessId = new ClassLibrary.BusinessIdSpecification();
            Assert.IsTrue(businessId.IsSatisfiedBy("8a17418-9") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
            Assert.IsTrue(businessId.IsSatisfiedBy("875-9") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
            Assert.IsTrue(businessId.IsSatisfiedBy("8700875-1") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
            Assert.IsTrue(businessId.IsSatisfiedBy("9700875-9") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
            Assert.IsTrue(businessId.IsSatisfiedBy("18700875-9") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
            Assert.IsTrue(businessId.IsSatisfiedBy("6810385-85") == false && businessId.ReasonsForDisatisfaction.Count() > 0);
        }
    }
}
