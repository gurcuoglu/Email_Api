using EmailApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace EmailApp.DataContext
{
    public class EmailDbContext :DbContext
    {
        public DbSet<EmailAdres> EmailAddresses { get; set; }
        public DbSet<GidenEmail> OutgoingEmails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-U0527J2\SQLEXPRESS;catalog=EmailDB;User=sa;Password=aykut234");
            }
        }
    }
}
