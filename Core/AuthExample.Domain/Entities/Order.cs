using AuthExample.Domain.Common;
using AuthExample.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExample.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Status { get; set; } = "Placed";
    }
}
