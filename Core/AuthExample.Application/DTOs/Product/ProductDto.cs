﻿using AuthExample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.DTOs.Product
{
    public class ProductDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float ProductPrice { get; set; }
        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
