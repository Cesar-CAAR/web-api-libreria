using System;
using Microsoft.EntityFrameworkCore;
using Libreria_CAAR.Data.Models;

namespace Libreria_CAAR.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get;set;}
    }
}
