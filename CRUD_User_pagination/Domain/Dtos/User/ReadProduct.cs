using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.User
{
    public class ReadProduct
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public string Image { get; set; }

    }
}
