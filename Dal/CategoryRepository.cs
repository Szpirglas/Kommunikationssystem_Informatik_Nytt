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
    }
}
