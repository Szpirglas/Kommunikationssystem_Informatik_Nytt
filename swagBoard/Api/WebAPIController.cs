using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Whiteboard.Models;
using System.Web.Http;
using Whiteboard.Extensions;
using System.IO;

namespace Whiteboard.API
{
    public class WebAPIController : ApiController
    {
        BlogEntryRepository blogRep;
        Category_BlogRepository cb_rep;
        FileRepository fileRep;
        public WebAPIController()
        {
            blogRep = new BlogEntryRepository();
            cb_rep = new Category_BlogRepository();
            fileRep = new FileRepository();
        }





        [System.Web.Mvc.HttpPost]
        public void sendPost(string title, int section, int sender, string content, string categoryIds, HttpPostedFileBase file)
        {
            if (!string.IsNullOrWhiteSpace(content) || !string.IsNullOrWhiteSpace(title))
            {
                var blogToPost = new BlogEntryModel
                {
                    Title = title,
                    Section = section,
                    Sender = sender,
                    Content = content,
                    Date = DateTime.Now
                };

                int id = blogRep.AddBlogEntry(blogToPost.MapToBlogEntity());

                var test = mjau(categoryIds);

                //int k;
                //k = test.Length;

                for (int s = 0; s < test.Length; s++)
                {

                    var blog_kat = new Category_Blog
                    {
                        CategoryId = test[s],
                        BlogId = id
                    };
                    cb_rep.Add(blog_kat);
                };
                if (file != null)
                {
                    UploadFile(file, id);
                }

            }
        }



        public int[] mjau(string katt)
        {
            //string s = "there is a cat";
            // Split string on spaces.
            // ... This will separate all the words.
            string[] words = katt.Split(' ');

            //int[] katts2;
            int[] myInts = words.Select(int.Parse).ToArray();
            return myInts;


        }

        public void UploadFile(HttpPostedFileBase file, int blogId)
        {
            try
            {
                var user = User.Identity.Name;

                var fileToAdd = Path.GetFileName(file.FileName);
                var folderPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/SavedFiles");
                var savePath = Path.Combine(folderPath, fileToAdd);

                var fileModel = new FileModel
                {
                    BlogEntry = blogId,
                    Path = savePath,
                    Type = file.ContentType
                };
                file.SaveAs(savePath);
                fileRep.Add(fileModel.MapToFileEntity());
            }
            catch (Exception e)
            {
                Console.WriteLine("Nu jävlar gubbar. Nu gick det fel." + e);
            }

        }





    }
}