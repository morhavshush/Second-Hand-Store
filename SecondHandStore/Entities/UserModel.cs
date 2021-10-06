using Entities.HelpersModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class UserModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        [ValidationBirthDate(ErrorMessage ="Your age must to be between 12-90")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "UserName is required.")]
        [MaxLength(50)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
