using BusinessObjects;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var categories = new List<Category>();
            try
            {
                using (var context = new MyStoreContext())
                {
                    categories = context.Categories.ToList();
                }
            }
            catch
            {
                throw;
            }
            return categories;
        }
    }
}
