using Microsoft.EntityFrameworkCore;

namespace App.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerProfile>(entity =>
        {
            entity.HasKey(c => c.CustomerId);

            entity.HasMany(c => c.CustomerLoyalties)
                .WithOne(cl => cl.Customer)
                .HasForeignKey(cl => cl.CustomerId);

            entity.HasMany(c => c.HouseholdMembers)
                .WithOne(hm => hm.Customer)
                .HasForeignKey(hm => hm.CustomerId);

            entity.HasMany(c => c.CustomerPreferences)
                .WithOne(cp => cp.Customer)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasMany(c => c.ContactHistories)
                .WithOne(ch => ch.Customer)
                .HasForeignKey(ch => ch.CustomerId);

            entity.HasMany(c => c.CustomerProductHoldings)
                .WithOne(cph => cph.Customer)
                .HasForeignKey(cph => cph.CustomerId);

            entity.HasMany(c => c.CustomerOffers)
                .WithOne(co => co.Customer)
                .HasForeignKey(co => co.CustomerId);

            entity.HasMany(c => c.CustomerAssets)
                .WithOne(ca => ca.Customer)
                .HasForeignKey(ca => ca.CustomerId);
        });
            
        modelBuilder.Entity<CustomerLoyalty>()
            .HasKey(cl => cl.CustomerId);
        
        modelBuilder.Entity<HouseholdMember>()
            .HasKey(cl => cl.CustomerId);
        
        modelBuilder.Entity<CustomerPreference>(entity =>
        {
            entity.HasKey(cp => new { cp.CustomerId, cp.FactorCode });

            entity.HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerPreferences)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasOne(cp => cp.RefPreferenceFactor)
                .WithMany(rpf => rpf.CustomerPreferences)
                .HasForeignKey(cp => cp.FactorCode);
        });
        
        modelBuilder.Entity<RefPreferenceFactor>(entity =>
        {
            entity.HasKey(rpf => rpf.FactorCode);

            entity.HasMany(rpf => rpf.CustomerPreferences)
                .WithOne(cp => cp.RefPreferenceFactor)
                .HasForeignKey(cp => cp.FactorCode);
        });
        
        
        modelBuilder.Entity<ContactHistory>(entity =>
        {
            entity.HasKey(cp => cp.ContactHistoryId);

            entity.HasOne(cp => cp.Customer)
                .WithMany(c => c.ContactHistories)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasOne(cp => cp.RefContactOutcome)
                .WithMany(rpf => rpf.ContactHistories)
                .HasForeignKey(cp => cp.OutcomeStatusCode);
        });
        
        modelBuilder.Entity<RefContactOutcome>(entity =>
        {
            entity.HasKey(rco => rco.OutcomeStatusCode);
            
            entity.HasMany(rpf => rpf.ContactHistories)
                .WithOne(cp => cp.RefContactOutcome)
                .HasForeignKey(cp => cp.OutcomeStatusCode);
        });


        modelBuilder.Entity<CustomerProductHolding>(entity =>
        {
            entity.HasKey(cph => new { cph.CustomerId, cph.ProductId });

            entity.HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerProductHoldings)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasOne(cp => cp.ServiceAndProduct)
                .WithMany(rpf => rpf.CustomerProductHoldings)
                .HasForeignKey(cp => cp.ProductId);
        });
        
        modelBuilder.Entity<ServiceAndProduct>(entity =>
        {
            entity.HasKey(sap => sap.ProductId);
            
            entity.HasMany(rpf => rpf.CustomerProductHoldings)
                .WithOne(cp => cp.ServiceAndProduct)
                .HasForeignKey(cp => cp.ProductId);
        });
        
        modelBuilder.Entity<CustomerOffer>(entity =>
        {
            entity.HasKey(co => new { co.CustomerId, co.SpecialOfferId });

            entity.HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerOffers)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasOne(cp => cp.SpecialOffer)
                .WithMany(rpf => rpf.CustomerOffers)
                .HasForeignKey(cp => cp.SpecialOfferId);
        });
        
        modelBuilder.Entity<SpecialOffer>(entity =>
        {
            entity.HasKey(so => so.SpecialOfferId);
            
            entity.HasMany(rpf => rpf.CustomerOffers)
                .WithOne(cp => cp.SpecialOffer)
                .HasForeignKey(cp => cp.SpecialOfferId);
        });
        
        modelBuilder.Entity<CustomerAsset>(entity =>
        {
            entity.HasKey(ca => ca.CustomerAssetId);
            
            entity.HasOne(cp => cp.Customer)
                .WithMany(c => c.CustomerAssets)
                .HasForeignKey(cp => cp.CustomerId);

            entity.HasOne(cp => cp.RefAssetType)
                .WithMany(rpf => rpf.CustomerAssets)
                .HasForeignKey(cp => cp.AssetTypeCode);
        });
        
        modelBuilder.Entity<RefAssetType>(entity =>
        {
            entity.HasKey(rat => rat.AssetTypeCode);
            
            entity.HasMany(rpf => rpf.CustomerAssets)
                .WithOne(cp => cp.RefAssetType)
                .HasForeignKey(cp => cp.AssetTypeCode);
        });
    }
}
