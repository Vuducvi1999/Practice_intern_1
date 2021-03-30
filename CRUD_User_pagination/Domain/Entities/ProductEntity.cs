using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Domain.Entities
{
    public class ProductEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string Image { get; set; }

        [NotMapped, Required]
        public IFormFile ImageFile{ get; set; }
    }
}
