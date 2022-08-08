using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationAPI.Data.Entities
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public string Text { get; set; }
        public int MaterialID { get; set; }
        public Material Material { get; set; }
        [Range(0, 10)]
        public uint Mark { get; set; }

    }
}
