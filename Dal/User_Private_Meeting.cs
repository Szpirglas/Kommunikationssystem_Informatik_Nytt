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
    
    public partial class User_Private_Meeting
    {
        public int Id { get; set; }
        public Nullable<int> User { get; set; }
        public Nullable<int> Meeting { get; set; }
    
        public virtual Events Events { get; set; }
        public virtual User User1 { get; set; }
    }
}