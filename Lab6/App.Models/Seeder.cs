using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Models;

public class Seeder(AppDbContext context,
    ILogger<Seeder> logger)
{
    public void Seed()
    {
        context.Database.EnsureCreated();

        if (context.CustomerProfiles.Any())
        {
            logger.LogInformation("Database already seeded. Exiting seeder.");
            return;
        }

        logger.LogInformation("Starting database seeding...");

        LogAndSeed(nameof(SeedCustomerProfiles), SeedCustomerProfiles);
        context.SaveChanges();
        LogAndSeed(nameof(SeedCustomerLoyalties), SeedCustomerLoyalties);
        context.SaveChanges();
        LogAndSeed(nameof(SeedHouseholdMembers), SeedHouseholdMembers);

        context.SaveChanges();
        LogAndSeed(nameof(SeedRefPreferenceFactors), SeedRefPreferenceFactors);
        LogAndSeed(nameof(SeedServicesAndProducts), SeedServicesAndProducts);
        LogAndSeed(nameof(SeedSpecialOffers), SeedSpecialOffers);
        LogAndSeed(nameof(SeedRefAssetTypes), SeedRefAssetTypes);
        LogAndSeed(nameof(SeedRefContactOutcomes), SeedRefContactOutcomes);

        context.SaveChanges();
        logger.LogInformation("Saved initial seeded entities to the database.");

        LogAndSeed(nameof(SeedCustomerPreferences), SeedCustomerPreferences);
        LogAndSeed(nameof(SeedCustomerAssets), SeedCustomerAssets);
        LogAndSeed(nameof(SeedCustomerProductHoldings), SeedCustomerProductHoldings);
        LogAndSeed(nameof(SeedCustomerOffers), SeedCustomerOffers);
        LogAndSeed(nameof(SeedContactHistories), SeedContactHistories);
        context.SaveChanges();

        logger.LogInformation("Database seeding completed successfully.");
    }

    private void LogAndSeed(string seedName, Action seedAction)
    {
        try
        {
            logger.LogInformation($"Starting seeding: {seedName}");
            seedAction();
            logger.LogInformation($"Completed seeding: {seedName}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Error during seeding: {seedName}");
            throw;
        }
    }
    
     private void SeedCustomerProfiles()
    {
        var customers = new List<CustomerProfile>
        {
            new() { CustomerDetails = "John Doe" },
            new() { CustomerDetails = "Jane Smith" },
            new() { CustomerDetails = "Alice Johnson" },
            new() { CustomerDetails = "Bob Brown" },
            new() { CustomerDetails = "Charlie Davis" },
        };

        context.CustomerProfiles.AddRange(customers);
    }

     private void SeedCustomerLoyalties()
     {
         var loyalties = new List<CustomerLoyalty>
         {
             new()
             {
                 CustomerId = 1,
                 DateFirstPurchase = new DateTime(2020, 1, 15),
                 DateLastPurchase = new DateTime(2023, 8, 10),
                 OtherLoyaltyDetails = "VIP customer"
             },
             new()
             {
                 CustomerId = 2,
                 DateFirstPurchase = new DateTime(2019, 5, 22),
                 DateLastPurchase = new DateTime(2023, 7, 20),
                 OtherLoyaltyDetails = "Regular customer"
             },
             new()
             {
                 CustomerId = 3,
                 DateFirstPurchase = new DateTime(2021, 3, 10),
                 DateLastPurchase = new DateTime(2023, 6, 15),
                 OtherLoyaltyDetails = "Loyalty program participant"
             },
             new()
             {
                 CustomerId = 4,
                 DateFirstPurchase = new DateTime(2018, 11, 5),
                 DateLastPurchase = new DateTime(2023, 8, 1),
                 OtherLoyaltyDetails = "Gold tier member"
             },
             new()
             {
                 CustomerId = 5,
                 DateFirstPurchase = new DateTime(2022, 4, 18),
                 DateLastPurchase = new DateTime(2023, 9, 25),
                 OtherLoyaltyDetails = "New loyalty program participant"
             }
         };

         context.CustomerLoyalties.AddRange(loyalties);
     }
     
     private void SeedHouseholdMembers()
     {
         var householdMembers = new List<HouseholdMember>
         {
             new() { CustomerId = 1, MemberCount = 4, CountOfChildren = 2, CountOfWageEarners = 2 },
             new() { CustomerId = 2, MemberCount = 3, CountOfChildren = 1, CountOfWageEarners = 2 },
             new() { CustomerId = 3, MemberCount = 5, CountOfChildren = 3, CountOfWageEarners = 2 },
             new() { CustomerId = 4, MemberCount = 2, CountOfChildren = 0, CountOfWageEarners = 2 },
             new() { CustomerId = 5, MemberCount = 6, CountOfChildren = 4, CountOfWageEarners = 2 }
         };

         context.HouseholdMembers.AddRange(householdMembers);
     }
     
     private void SeedRefPreferenceFactors()
     {
         var preferenceFactors = new List<RefPreferenceFactor>
         {
             new() { FactorCode = 101, FactorDescription = "Preferred Contact Time: Morning" },
             new() { FactorCode = 202, FactorDescription = "Preferred Contact Time: Afternoon" },
             new() { FactorCode = 303, FactorDescription = "Preferred Contact Time: Evening" },
             new() { FactorCode = 404, FactorDescription = "Preferred Contact Time: Night" },
             new() { FactorCode = 505, FactorDescription = "Preferred Contact Time: Weekend" },
         };

         context.RefPreferenceFactors.AddRange(preferenceFactors);
         context.SaveChanges();
     }


    private void SeedServicesAndProducts()
    {
        var services = new List<ServiceAndProduct>
        {
            new() { ProductName = "Savings Account", ProductDetails = "Basic savings account" },
            new() { ProductName = "Credit Card", ProductDetails = "Visa Platinum Card" },
            new() { ProductName = "Mortgage Loan", ProductDetails = "Home loan with low interest rates" },
            new() { ProductName = "Car Insurance", ProductDetails = "Comprehensive car insurance plan" },
            new() { ProductName = "Health Insurance", ProductDetails = "Basic health coverage plan" },
        };

        context.ServicesAndProducts.AddRange(services);
    }

    private void SeedSpecialOffers()
    {
        var offers = new List<SpecialOffer>
        {
            new() { SpecialOfferDetails = "10% cashback on groceries" },
            new() { SpecialOfferDetails = "5% discount on loan rates" },
            new() { SpecialOfferDetails = "Free credit score check" },
            new() { SpecialOfferDetails = "No annual fee on credit card" },
            new() { SpecialOfferDetails = "Free health check-up package" },
        };

        context.SpecialOffers.AddRange(offers);
    }

    private void SeedRefAssetTypes()
    {
        var assetTypes = new List<RefAssetType>
        {
            new() { AssetTypeCode = 101, AssetTypeDescription = "Vehicle" },
            new() { AssetTypeCode = 202, AssetTypeDescription = "Property" },
            new() { AssetTypeCode = 303, AssetTypeDescription = "Jewelry" },
            new() { AssetTypeCode = 404, AssetTypeDescription = "Electronics" },
            new() { AssetTypeCode = 505, AssetTypeDescription = "Furniture" },
        };

        context.RefAssetTypes.AddRange(assetTypes);
    }
    
    private void SeedCustomerPreferences()
    {
        var preferences = new List<CustomerPreference>
        {
            new() { CustomerId = 1, FactorCode = 101 },
            new() { CustomerId = 1, FactorCode = 202 },
            new() { CustomerId = 2, FactorCode = 101 },
            new() { CustomerId = 3, FactorCode = 303 },
            new() { CustomerId = 4, FactorCode = 404 }
        };

        context.CustomerPreferences.AddRange(preferences);
    }
    
    private void SeedCustomerAssets()
    {
        var assets = new List<CustomerAsset>
        {
            new() { CustomerId = 1, AssetTypeCode = 101, DateAssetAcquired = DateTime.Now.AddYears(-5) },
            new() { CustomerId = 2, AssetTypeCode = 202, DateAssetAcquired = DateTime.Now.AddYears(-3) },
            new() { CustomerId = 3, AssetTypeCode = 303, DateAssetAcquired = DateTime.Now.AddYears(-1) },
            new() { CustomerId = 4, AssetTypeCode = 101, DateAssetAcquired = DateTime.Now.AddYears(-4) },
            new() { CustomerId = 5, AssetTypeCode = 202, DateAssetAcquired = DateTime.Now.AddYears(-2) }
        };

        context.CustomerAssets.AddRange(assets);
    }

    private void SeedCustomerProductHoldings()
    {
        var productHoldings = new List<CustomerProductHolding>
        {
            new() { CustomerId = 1, ProductId = 1, DateAcquired = DateTime.Now.AddYears(-2), DateDiscontinued = null },
            new() { CustomerId = 2, ProductId = 2, DateAcquired = DateTime.Now.AddYears(-3), DateDiscontinued = DateTime.Now.AddYears(-1) },
            new() { CustomerId = 3, ProductId = 3, DateAcquired = DateTime.Now.AddYears(-1), DateDiscontinued = null },
            new() { CustomerId = 4, ProductId = 4, DateAcquired = DateTime.Now.AddYears(-4), DateDiscontinued = null },
            new() { CustomerId = 5, ProductId = 5, DateAcquired = DateTime.Now.AddYears(-5), DateDiscontinued = null }
        };

        context.CustomerProductHoldings.AddRange(productHoldings);
    }

    private void SeedCustomerOffers()
    {
        var offers = new List<CustomerOffer>
        {
            new() { CustomerId = 1, SpecialOfferId = 1, DateOfferAccepted = DateTime.Now.AddDays(-10) },
            new() { CustomerId = 2, SpecialOfferId = 2, DateOfferAccepted = DateTime.Now.AddDays(-20) },
            new() { CustomerId = 3, SpecialOfferId = 3, DateOfferAccepted = DateTime.Now.AddDays(-30) },
            new() { CustomerId = 4, SpecialOfferId = 4, DateOfferAccepted = DateTime.Now.AddDays(-40) },
            new() { CustomerId = 5, SpecialOfferId = 5, DateOfferAccepted = DateTime.Now.AddDays(-50) }
        };

        context.CustomerOffers.AddRange(offers);
    }
    
    private void SeedRefContactOutcomes()
    {
        var contactOutcomes = new List<RefContactOutcome>
        {
            new() { OutcomeStatusCode = 101, OutcomeStatusDescription = "Successful" },
            new() { OutcomeStatusCode = 202, OutcomeStatusDescription = "Failed" },
            new() { OutcomeStatusCode = 303, OutcomeStatusDescription = "Pending" },
            new() { OutcomeStatusCode = 404, OutcomeStatusDescription = "Cancelled" },
            new() { OutcomeStatusCode = 505, OutcomeStatusDescription = "Completed" }
        };

        context.RefContactOutcomes.AddRange(contactOutcomes);
        context.SaveChanges();
    }
    
    private void SeedContactHistories()
    {
        var contactHistories = new List<ContactHistory>
        {
            new()
            {
                CustomerId = 1,
                OutcomeStatusCode = 101, 
                ContactDatetime = DateTime.Now.AddMonths(-2),
                ContactDetails = "Follow-up call regarding new product inquiry."
            },
            new()
            {
                CustomerId = 2,
                OutcomeStatusCode = 202, 
                ContactDatetime = DateTime.Now.AddMonths(-1),
                ContactDetails = "Attempted to contact for product delivery confirmation."
            },
            new()
            {
                CustomerId = 3,
                OutcomeStatusCode = 303,
                ContactDatetime = DateTime.Now.AddDays(-15),
                ContactDetails = "Email sent for feedback on service."
            },
            new()
            {
                CustomerId = 4,
                OutcomeStatusCode = 404, 
                ContactDatetime = DateTime.Now.AddDays(-10),
                ContactDetails = "Call cancelled for product return inquiry."
            },
            new()
            {
                CustomerId = 5,
                OutcomeStatusCode = 505, 
                ContactDatetime = DateTime.Now.AddDays(-5),
                ContactDetails = "Completed customer satisfaction survey."
            }
        };

        context.ContactHistories.AddRange(contactHistories);
    }
}