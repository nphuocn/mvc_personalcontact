using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.NetCore.Models
{
    public class PersonalContactModel
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Title")]
        public string Title { get; set; }
    }
}
