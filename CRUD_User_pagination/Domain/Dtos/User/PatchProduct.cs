using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.User
{
    public class PatchProduct
    {
        public string ?Name { get; set; }
        public int ?Quantity { get; set; }
        public IFormFile ?ImageFile { get; set; }
    }
}
