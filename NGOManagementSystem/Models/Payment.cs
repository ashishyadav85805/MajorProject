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

        #region Navigation Properties to the DonorInfo Model
        [Display(Name = "Donor Name")]
        public int DonorId { get; set; }
        [ForeignKey(nameof(Payment.DonorId))]
        public DonorInfo DonorInfo { get; set; }

        #endregion

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


        #region Navigation Properties to the Paytm Model
        [Display(Name = "Payment Options")]
        public int PaytmMethod { get; set; }
        [ForeignKey(nameof(Payment.PaytmMethod))]
        public Paytm Paytms { get; set; }


        #endregion

       

    }
}
