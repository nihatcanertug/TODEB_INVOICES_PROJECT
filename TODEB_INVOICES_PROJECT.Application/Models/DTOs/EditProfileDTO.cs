using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODEB_INVOICES_PROJECT.Application.Models.DTOs
{
    public class EditProfileDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must to type into name")]
        public string Name { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
