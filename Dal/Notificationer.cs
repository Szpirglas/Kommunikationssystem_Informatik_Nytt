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
    
    public partial class Notificationer
    {
        public int Id { get; set; }
        public Nullable<int> Reciever { get; set; }
        public Nullable<bool> Participate { get; set; }
        public string Text { get; set; }
        public Nullable<int> MeetingID { get; set; }
    
        public virtual Meeting Meeting { get; set; }
        public virtual User User { get; set; }
    }
}