using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class CategoryRepository : GenericRepository<Categories>
    {
        public IEnumerable<Categories> GetCategories(int sectionID)
        {
            try
            {
                using (var db = new Entities())
                {
                    return db.Categories.Where(c => c.Feed_Section == sectionID).ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Något gick väldigt fel: " + e);
                return null;
            }
        }

        public List<string> GetCategoriesByBlogId(int blogId)
        {
            try
            {
                using (var db = new Entities())
                {
                    var categoryList = (from c in db.Categories
                                        join cb in db.Category_Blog on c.Id equals cb.CategoryId
                                        join b in db.BlogEntries on cb.BlogId equals b.BId
                                        where b.BId == blogId
                                        select c.Name).ToList();

                    return categoryList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Nånting gick fel: " + e);
                return null;
            }
        }
    }
}
