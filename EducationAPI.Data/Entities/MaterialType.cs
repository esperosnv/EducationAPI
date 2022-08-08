using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace EducationAPI.Data.Entities
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
    }
}
