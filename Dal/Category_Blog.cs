//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category_Blog
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BlogId { get; set; }
    
        public virtual BlogEntries BlogEntries { get; set; }
        public virtual Categories Categories { get; set; }
    }
}