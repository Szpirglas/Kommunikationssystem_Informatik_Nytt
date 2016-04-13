using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Whiteboard.Models;
using Whiteboard.Extensions;
namespace Whiteboard.Controllers
{
    public class FeedController : Controller
    {
        CategoryRepository categoryRepository;
        BlogEntryRepository blogEntryRepository;
        public FeedController()
        {
            blogEntryRepository = new BlogEntryRepository();
            categoryRepository = new CategoryRepository();
        }
        // GET: Feed




        //public ActionResult Feed()
        //{
        //    return View();

        //}



        public ActionResult Feed(int sectionId = 2)
        {
            try
            {
                var blogPosts = new BlogEntryModel();
                var posts = blogEntryRepository.GetPosts(sectionId);
                var categoryList = categoryRepository.GetCategories(sectionId);
                ViewBag.sectionId = sectionId;

                foreach (var item in posts)
                {
                    blogPosts.BlogList.Add(item.MaptoBlogEntryModel());
                }

                foreach(var item in categoryList)
                {
                    blogPosts.CategoryList.Add(item.MaptoCategoryModel());
                }

                return View(blogPosts);
            }
            catch
            {
                return null;
            }
        }

        
        public void removeBlogEntry(int bld)
        {

           


            blogEntryRepository.removeOneBlogEntry(bld);


    




        }
       


    }
}