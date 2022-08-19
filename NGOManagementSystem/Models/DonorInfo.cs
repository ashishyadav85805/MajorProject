using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGOManagementSystem.Models
{
    [Table(name: "DonorInfo")]

    public class DonorInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DonorId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Customer")]

        public string DonorName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Address")]

        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

       



        #region Navigation Properties to the OrderDetail Model

        [Display(Name = "Choose Category")]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(DonorInfo.CategoryId))]
        public Category Category { get; set; }
        #endregion

        #region Navigation Properties to the OrderDetail Model
        public ICollection<DonorDetail> DonorDetails { get; set; }
        #endregion
    }
}
