using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialScape.Shared.Models.MediaAccountFold
{
    public class MediaAccount
    {
        public int MediaAccountId { get; set; }
        [Required(ErrorMessage = "Enter Your Full Name")]
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Your User Name")]
        public string UserName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter Your Description")]
        public string Description { get; set; } = string.Empty;
        public string Photo { get; set; } = "https://i.ibb.co/rc0fPvM/4cdee02fbf6649b4e2c7b597f9d4d143.jpg";
    }
}
