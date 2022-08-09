using System.ComponentModel.DataAnnotations;


namespace EducationAPI.Data.Entities
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Definition { get; set; }
    }
}
