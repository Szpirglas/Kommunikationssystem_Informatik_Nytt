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
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Whiteboard.API
{
    public class WebAPIController : ApiController
    {
        BlogEntryRepository blogRep;
        Category_BlogRepository cb_rep;
        FileRepository fileRep;
        UserRepository userRep;

        string root;
        public WebAPIController()
        {
            blogRep = new BlogEntryRepository();
            cb_rep = new Category_BlogRepository();
            fileRep = new FileRepository();
            root = HttpContext.Current.Server.MapPath("~/Content/SavedFiles");
            userRep = new UserRepository();
        }





        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public void sendPost(string title, int section, string content, string categoryIds)
        {

            var sender=userRep.getYaUserFromYaMail(User.Identity.Name);

             
            if (!string.IsNullOrWhiteSpace(content) || !string.IsNullOrWhiteSpace(title))
            {
                var blogToPost = new BlogEntryModel
                {
                    Title = title,
                    Section = section,
                    Sender = sender.Id,
                    Content = content,
                    Date = DateTime.Now
                };

                var id = blogRep.AddBlogEntry(blogToPost.MapToBlogEntity());

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

                var fileModel = new FileModel
                {
                    BlogEntry = id,
                    Path = root,
                    Type = null
            };
                fileRep.Add(fileModel.MapToFileEntity());

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

        //[System.Web.Mvc.HttpPost]
        //[ValidateAntiForgeryToken]
        //public void UploadFile(HttpPostedFileBase file)
        //{

        //    try
        //    {
        //        if (file != null)
        //        {
        //            var fileToAdd = Path.GetFileName(file.FileName);
        //            var folderPath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/SavedFiles");
        //            var savePath = Path.Combine(folderPath, fileToAdd);
        //            var type = file.ContentType;

        //            //var fileModel = new FileModel
        //            //{
        //            //    BlogEntry = 1,
        //            //    Path = savePath,
        //            //    Type = type
        //            //};
        //            file.SaveAs(savePath);
        //            //fileRep.Add(fileModel.MapToFileEntity());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Nu jävlar gubbar. Nu gick det fel." + e);
        //    }

        //}

        public void UploadFile()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                // Read the form data.
                Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the file names.
                foreach (MultipartFileData file in provider.FileData)
                {
                    Trace.WriteLine(file.Headers.ContentDisposition.FileName);
                    Trace.WriteLine("Server file path: " + file.LocalFileName);
                }
                
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }




    }
}