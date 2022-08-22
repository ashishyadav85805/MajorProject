using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;



namespace NGOManagementSystem.Models
{
    [Table(name: "Paytm")]
    public class Paytm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaytmId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Payment Methods")]
        public string PaytmMethods { get; set; }

        

        #region Navigation Properties to the DonorDetails Model
        public ICollection<DonorDetail> DonorDetails { get; set; }
        #endregion

    }
}
