using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Feed_Section { get; set; }


        public virtual Feed_SectionModel Feed_Section1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BlogEntryModel> BlogEntries { get; set; }
    }
}