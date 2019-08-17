using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LACC.Model
{
    public class Cigar
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(40)]
        public string Type { get; set; }

        public string Description { get; set; }

        public int QTY { get; set; }
    }
}
