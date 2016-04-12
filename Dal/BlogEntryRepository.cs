using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BlogEntryRepository : GenericRepository<BlogEntries>
    {
        public IEnumerable<BlogEntries> GetPosts(int sectionID)
        {
            var blogEntries = new List<BlogEntries>();
            try
            {
                using (var db = new Entities())
                {
                    return db.BlogEntries.Where(c => c.Section == sectionID).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Något gick väldigt fel: " + e);
                return null;
            }
        }

        public int AddBlogEntry(BlogEntries blogEntry)
        {
            try
            {
                using (var db = new Entities())
                {

                    db.Set<BlogEntries>().Add(blogEntry);
                    db.SaveChanges();
                    int id = blogEntry.BId;
                    return id;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return 0;
            }
        }
    }
}
