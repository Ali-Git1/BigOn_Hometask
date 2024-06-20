using BigonApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Extensions
{
    public static class CategoryExtension
    {
        public static IEnumerable<Category> GetHierArchy(this IEnumerable<Category> categories,Category parent)
        {
            if (parent.ParentId != null)
            {
                yield return parent;
            }

            foreach (var item in categories.Where(m=>m.ParentId==parent.Id && m.DeletedBy==null).SelectMany(ch=>categories.GetHierArchy(ch)))
            {
                yield return item;
            }
        }
    }
}
