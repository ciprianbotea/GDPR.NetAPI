using Microsoft.EntityFrameworkCore;

namespace GDPR.NetAPI.Models

{
    public class GdprAgreementContext : DbContext
    {
        public GdprAgreementContext(DbContextOptions<GdprAgreementContext> options) : base(options)
        {
        }

        public DbSet<GdprAgreement> Agreements { get; set; }

    }
}