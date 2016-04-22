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

        public IEnumerable<BlogEntries> GetYaOwnPostsMan(int sectionID,int userId)
        {
            var blogEntries = new List<BlogEntries>();
            try
            {
                using (var db = new Entities())
                {
                    return db.BlogEntries.Where(c => c.Section == sectionID && c.Sender== userId).ToList();
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

        public void removeOneBlogEntry(int bld)
        {

            try
            {

                using (var db = new Entities())
                {


                    var cat_blog = new List<Category_Blog>();

                    cat_blog = db.Category_Blog.Where(x => x.BlogId == bld).ToList();
                    foreach(var cat in cat_blog) {
                        db.Entry(cat).State = System.Data.Entity.EntityState.Deleted;

                    }


                    BlogEntries BlogEntryToDelete = db.BlogEntries.Where(x => x.BId == bld).FirstOrDefault<BlogEntries>();

                    
                    db.Entry(BlogEntryToDelete).State = System.Data.Entity.EntityState.Deleted;

                    db.SaveChanges();



                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e);



            }

        }


    }
}
