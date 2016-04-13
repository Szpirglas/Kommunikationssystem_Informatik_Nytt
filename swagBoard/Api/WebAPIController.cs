using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal;
using Whiteboard.Models;
using System.Web.Http;
using Whiteboard.Extensions;
namespace Whiteboard.API
{
    public class WebAPIController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public void sendPost(string title, int section, int sender, string content)
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
                var blogRep = new BlogEntryRepository();
                blogRep.Add(blogToPost.MapToBlogEntity());
            }
        }

    }
}