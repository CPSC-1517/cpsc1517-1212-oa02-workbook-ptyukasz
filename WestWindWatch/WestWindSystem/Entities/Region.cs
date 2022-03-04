using System.ComponentModel.DataAnnotations; //for Key, Required, StringLength
using System.ComponentModel.DataAnnotations.Schema; //for Table
namespace WestWindSystem.Entities
{   [Table("Regions")]
    internal class Region
    {   [Key]
       public int RegionId { get; set; }
       [Required(ErrorMessage = "Region Description is required")]
       [StringLength(50, ErrorMessage = "Region Description is limited to 50 characters")]
       public string RegionDescription { get; set; }
    }
}
