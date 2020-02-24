using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.Models
{

    public class Account
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        #region Email
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Confirm Email")]
        //[Compare("UserEmail", ErrorMessage = "The Email and confirmation Email do not match.")]
        public string ConfirmUserEmail { get; set; }
        #endregion
        #region FullName
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        #endregion
        #region Phone Number
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        #endregion
        #region Password
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmUserPassword { get; set; }
        #endregion

        // Need to be drop down menu to choose Role

        

        [Required]
        [Display(Name = "Select Role")]
        public int SelectedRole { get { return 2; } }
        public SelectList RoleList { get; set; }


        // private DateTime Register = DateTime.Now;
        //[Required]
        //[DataType(DataType.DateTime)]
        //[Display(Name = "Created on")]
        //public DateTime RegisterDate { get; set; }
        //    { get   {       
        //            return Register;
        //           } 
        //      set          { Register = value; } }  
        //
    }
    public class UsersDBContext : DbContext
    {
        public DbSet<Account> Users { get; set; }
    }

    public static class Repository
    {
        public class UserRole           
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public static IEnumerable<UserRole> FetchRoles()
        {
            return new List<UserRole>()
            {
                new UserRole(){ Id = 1, Name = "Admin" },
                new UserRole(){ Id = 2, Name = "Member" },
                new UserRole(){ Id = 3, Name = "Guest" }
            };
        }
    }

}