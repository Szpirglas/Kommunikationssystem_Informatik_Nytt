﻿using System;
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
        UserRepository userRep;


        public FeedController()
        {
            blogEntryRepository = new BlogEntryRepository();
            categoryRepository = new CategoryRepository();
            userRep = new UserRepository();
        }
        // GET: Feed



            [Authorize]
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

                 var  item2 = item.MaptoBlogEntryModel();

                    item2.SenderName = userRep.getYaUserFromYaId(item.Sender).Firstname + ' ' + userRep.getYaUserFromYaId(item.Sender).Lastname;
                    blogPosts.BlogList.Add(item2);

                    blogPosts.CategoriesPerBlog.Add(categoryRepository.GetCategoriesByBlogId(item.BId));
                }

                foreach (var item in categoryList)
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

        //[HttpPost]
        //[ActionName("getPersonalFeed")]
        [Authorize]
        public ActionResult getPersonalFeed(int sectionId)
        {
            try
            {

                var user = userRep.getYaUserFromYaMail(User.Identity.Name);

                var blogPosts = new BlogEntryModel();
                var posts = blogEntryRepository.GetYaOwnPostsMan(sectionId, user.Id);
                var categoryList = categoryRepository.GetCategories(sectionId);
                ViewBag.sectionId = sectionId;

                foreach (var item in posts)
                {
                    blogPosts.BlogList.Add(item.MaptoBlogEntryModel());

                    blogPosts.CategoriesPerBlog.Add(categoryRepository.GetCategoriesByBlogId(item.BId));
                }

                foreach (var item in categoryList)
                {
                    blogPosts.CategoryList.Add(item.MaptoCategoryModel());
                }

                return View("Feed", blogPosts);
            }
            catch
            {
                return null;
            }
        }


        [Authorize]
        public ActionResult getSomeOneElsesFeed(int sectionId, int userID)
        {
            try
            {
               

                var user = userRep.getYaUserFromYaId(userID);
                var currentUser = userRep.getYaUserFromYaMail(User.Identity.Name);

                var blogPosts = new BlogEntryModel();
                blogPosts.user.Email = currentUser.Email;
                var posts = blogEntryRepository.GetYaOwnPostsMan(sectionId, user.Id);
                var categoryList = categoryRepository.GetCategories(sectionId);
                ViewBag.sectionId = sectionId;

                foreach (var item in posts)
                {
                    blogPosts.BlogList.Add(item.MaptoBlogEntryModel());
                    blogPosts.CategoriesPerBlog.Add(categoryRepository.GetCategoriesByBlogId(item.BId));
                }

                foreach (var item in categoryList)
                {
                    blogPosts.CategoryList.Add(item.MaptoCategoryModel());
                }

                return View("Feed", blogPosts);
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