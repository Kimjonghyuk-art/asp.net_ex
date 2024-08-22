using System;
using ASP.NETMVC_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETMVC_test.Dao
{
	public class ApplicationDbContext : DbContext
	{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    // Add DbSets for other entities as needed


  }
}

