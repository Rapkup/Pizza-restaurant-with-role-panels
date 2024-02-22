using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBKITTER.API.Context;

namespace WEBKITTER.API.Models.Roles
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
