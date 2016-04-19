using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Whiteboard.Models;

namespace Whiteboard.Controllers
{
    public class RolesController : Controller
    {
        public void addUserToRole(UserModel model)
        {
            if (model.Lecturer == true)
            {
                addLectureRole();
                if (!Roles.IsUserInRole(model.Email, "Lecture"))
                    Roles.AddUserToRole(model.Email.ToLower(), "Lecture");
            }

            if (model.EducationAdmin == true)
            {
                addEducationAdminRole();
                if (!Roles.IsUserInRole(model.Email, "EducationAdmin"))
                    Roles.AddUserToRole(model.Email.ToLower(), "EducationAdmin");
            }

            if (model.Doctorand == true)
            {
                addDoctorandRole();
                if (!Roles.IsUserInRole(model.Email, "Doctorand"))
                    Roles.AddUserToRole(model.Email.ToLower(), "Doctorand");
            }

            if (model.ResearchAdmin == true)
            {
                addResearchAdminRole();
                if (!Roles.IsUserInRole(model.Email, "ResearchAdmin"))
                    Roles.AddUserToRole(model.Email.ToLower(), "ResearchAdmin");
            }

            if (model.Researcher == true)
            {
                addResearcherRole();
                if (!Roles.IsUserInRole(model.Email, "Researcher"))
                    Roles.AddUserToRole(model.Email.ToLower(), "Researcher");
            }
        }

        public void addEducationAdminRole()
        {
            if (!Roles.RoleExists("EducationAdmin"))
            {
                Roles.CreateRole("EducationAdmin");
            }
        }

        public void addResearchAdminRole()
        {
            if (!Roles.RoleExists("ResearchAdmin"))
            {
                Roles.CreateRole("ResearchAdmin");
            }
        }

        public void addLectureRole()
        {
            if (!Roles.RoleExists("Lecture"))
            {
                Roles.CreateRole("Lecture");
            }
        }

        public void addDoctorandRole()
        {
            if (!Roles.RoleExists("Doctorand"))
            {
                Roles.CreateRole("Doctorand");
            }
        }

        public void addResearcherRole()
        {
            if (!Roles.RoleExists("Researcher"))
            {
                Roles.CreateRole("Researcher");
            }
        }
    }
}