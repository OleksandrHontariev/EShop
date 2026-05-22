using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.DataLayer.QueryObjects
{
    public static class GenericPaging
    {
        public static IQueryable<T> Page<T> (this IQueryable<T> query, int pageNumZiroStart, int pageSize)
        {
            if (pageSize == 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize cannot be zero.");

            if (pageNumZiroStart != 0)
                query = query.Skip(pageNumZiroStart * pageSize);

            return query.Take(pageSize);
        }
    }
}
