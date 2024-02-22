using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WEBKITTER.API.Context;

namespace WEBKITTER.API.Models.Roles
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
