using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class Feed_SectionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CategoryModel> Categories { get; set; }

    }
}