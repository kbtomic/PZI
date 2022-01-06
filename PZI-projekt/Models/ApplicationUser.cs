using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PZI_projekt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Car> Car { get; set; }
    }
}
