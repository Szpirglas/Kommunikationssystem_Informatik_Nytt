using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class BlogEntryModel
    {
        public int BId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Sender { get; set; }
        public DateTime Date { get; set; }
        public int Section { get; set; }
        public string SenderName { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileModel> Files { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryModel> Categories { get; set; }
        public List<BlogEntryModel> BlogList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public List<List<string>> CategoriesPerBlog { get; set; }
        public UserModel user { get; set; }

        public BlogEntryModel()
        {
            BlogList = new List<BlogEntryModel>();
            CategoryList = new List<CategoryModel>();
            CategoriesPerBlog = new List<List<string>>();
            user = new UserModel();
        }
    }
}