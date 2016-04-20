using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dal;
using Whiteboard.Models;

namespace Whiteboard.Extensions
{
    public static class ExtensionMethods
    {
        public static BlogEntries MapToBlogEntity(this BlogEntryModel blogPost)
        {

            //Nytt objekt av Profilemodel med NOT NULL data.
            var blogEntry = new BlogEntries
            {
                Title = blogPost.Title,
                Content = blogPost.Content,
                Date = blogPost.Date,
                Sender = blogPost.Sender,
                Section = blogPost.Section

            };
            return blogEntry;
        }

        public static Meeting MapToMeeting(this MeetingModel meeting)
        {
            var meetingS = new Meeting
            {
                Sender = meeting.Sender,
                Reciever = meeting.Reciever,
                Confirmed = meeting.Confirmed,
                text = meeting.Text
            };
            return meetingS;
        }

        public static BlogEntryModel MaptoBlogEntryModel(this BlogEntries blogEntryModel)
        {
            var blogEntryMapped = new BlogEntryModel
            {
                BId=blogEntryModel.BId,
                Title = blogEntryModel.Title,
                Content = blogEntryModel.Content,
                Date = blogEntryModel.Date,
                Sender = blogEntryModel.Sender,
                Section = blogEntryModel.Section

            };
            return blogEntryMapped;
        }

        public static CategoryModel MaptoCategoryModel(this Categories categoryModel)
        {
            var categoryMapped = new CategoryModel
            {
                Name = categoryModel.Name,
                Id = categoryModel.Id,
            };
            return categoryMapped;
        }
        public static UserModel MapToUserModel(this User userModel)
        {

            var x = new UserModel
            {
                Email = userModel.Email,
                Password = userModel.Password,
                Firstname = userModel.Firstname,
                Lastname = userModel.Lastname,
                PhoneNumber = userModel.Phonenumber,
                ResearchAdmin = userModel.ResearchAdmin,
                Researcher = userModel.Researcher,
                Lecturer = userModel.Lecturer,
                EducationAdmin = userModel.EducationAdmin,
                Doctorand = userModel.Doctorand,

            };
            return x;
        }
    }
}