﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGOManagementSystem.Models
{
    public class DonorDetail
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }



        #region Navigation Properties to the DonorInfo Model
        [Display(Name = "Donor Name")]
        public int DonorId { get; set; }

        [ForeignKey(nameof(DonorDetail.DonorId))]

        public DonorInfo DonorInfo { get; set; }

        #endregion


        [Required]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Amount")]
        public string Amount { get; set; }


        //#region Navigation Properties to the Menu Model

        //[Display(Name = "Name of the Donor")]
        //public int DonorName { get; set; }

        //[ForeignKey(nameof(DonorDetail.DonorName))]

        //public DonorInfo DonorInfo{ get; set; }

        //#endregion



        #region Navigation Properties to the Payment Model
        [Display(Name = "Payment Options")]
        public int PaymentMethod { get; set; }
        [ForeignKey(nameof(DonorDetail.PaymentMethod))]
        public Payment Payments { get; set; }


        #endregion
    }
}
