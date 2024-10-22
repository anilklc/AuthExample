using Microsoft.AspNetCore.Identity;

namespace AuthExample.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<Guid>
    {
        public ICollection<Endpoint> Endpoints { get; set; }

    }
}
