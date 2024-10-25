using AuthExample.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Application.DTOs.Order
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
