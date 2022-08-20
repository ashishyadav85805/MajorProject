using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NGOManagementSystem.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonorDetailId { get; set; }


        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Bank Name")]
        public string BankName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Bank Account NO.")]
        public string  AccountNO { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "IFSC NO.")]
        public string IFSC { get; set; }



        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Payment Methods")]
        public string PaymentMethods { get; set; }

        #region Navigation Properties to the OrderDetails Model
        public ICollection<DonorDetail> DonorDetails { get; set; }
        #endregion
    }
}
