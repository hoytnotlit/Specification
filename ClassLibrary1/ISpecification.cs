using System.Collections.Generic;

namespace ClassLibrary
{
    public interface ISpecification<in TEntity>
    {
        IEnumerable<string> ReasonsForDisatisfaction { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
