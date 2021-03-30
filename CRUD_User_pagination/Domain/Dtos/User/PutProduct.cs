using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.User
{
    public class PutProduct
    {
        [Required]
        public string ?Name { get; set; }

        [Required]
        public int ?Quantity { get; set; }

        [Required]
        public IFormFile ?ImageFile { get; set; }
    }
}
