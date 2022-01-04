using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infastructure.Data
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery , ISpecification<T> spec)
        {
            var query = InputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}
