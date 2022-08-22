using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NGOManagementSystem.Models
{
    [Table(name: "Volunteer")]
    public class Volunteer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VolunteerId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Customer")]
        public string VolunteerName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Age")]
        public string Age{ get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Address")]
        public string Address { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "E-Mail Id")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Qualification ")]
        public string Qualification { get; set; }


    }
}
