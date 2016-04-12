using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public int BlogEntry { get; set; }

        public virtual BlogEntryModel BlogEntry1 { get; set; }
    }
}