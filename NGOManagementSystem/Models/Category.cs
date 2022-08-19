using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NGOManagementSystem.Models
{
    [Table(name: "Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }


        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Name of the Category")]

        public string CategoryName { get; set; }

        #region Navigation Properties to the donorinfo Model

        public ICollection<DonorInfo> DonorInfo { get; set; }

        #endregion


    }
}
