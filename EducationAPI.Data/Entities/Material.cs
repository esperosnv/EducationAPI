using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace EducationAPI.Data.Entities
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int MaterialTypeID { get; set; }
        public MaterialType MaterialType { get; set; }
        public IEnumerable<Review> Reviews { get; set; } = new List<Review>();
        public DateTime PublishingDate { get; set; }
    }
}
