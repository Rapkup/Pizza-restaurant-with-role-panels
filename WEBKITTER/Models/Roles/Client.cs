using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WEBKITTER.UI.Context;

namespace WEBKITTER.UI.Models.Roles
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }


        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
