using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.API.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Photo { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public DateTimeOffset LastUpdated { get; set; }
    }
}
