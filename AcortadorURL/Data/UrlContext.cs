using System.Collections.Generic;
using AcortadorURL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AcortadorURL.Data
{
    public class UrlContext : DbContext
    {
        public DbSet<Url>Urls { get; set; }
        
        public UrlContext(DbContextOptions<UrlContext> options) : base(options) 
        {

        } 
    }
}