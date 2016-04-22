using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whiteboard.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Förnamn")]
        public string Firstname { get; set; }
        [Display(Name ="Efternamn")]
        public string Lastname { get; set; }
        [Display(Name ="Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Forskaradmin")]
        public bool ResearchAdmin { get; set; }
        [Display(Name = "Utbildningsadmin")]
        public bool EducationAdmin { get; set; } 
        [Display(Name = "Forskare")]
        public bool Researcher { get; set; }
        [Display(Name ="Doktorand")]
        public bool Doctorand { get; set; }
        [Display(Name ="Föreläsare")]
        public bool Lecturer { get; set; }
        public List<UserModel> userList { get; set; }
        public UserModel()
        {
            userList = new List<UserModel>();
        }
    }
}