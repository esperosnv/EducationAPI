using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EducationAPI.Data.Entities
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public IEnumerable<Material> Materials { get; set; }

        public Author()
        {
            Materials = new List<Material>();
        }
    }
}
