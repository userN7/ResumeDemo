using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace pluritechDemo.Models
{
	public class AppIdentityDbContext: IdentityDbContext<IdentityUser>
	{
		public AppIdentityDbContext(DbContextOptions opts) : base(opts) { }
	}
}
