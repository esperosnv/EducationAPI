using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationAPI.Data.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
       // public Role Role { get; set; }
    }
}
