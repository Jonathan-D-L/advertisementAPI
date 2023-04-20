using advertisementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace advertisementAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }
        private void SeedData()
        {
            if (_dbContext.Adverts.Any()) { return; }
            _dbContext.Add(new Advert
            {
                Header = "Summer Sale!",
                Img = "https://example.com/images/summer_sale.png",
                Description = "Get up to 50% off on summer styles",
                CallToAction = "Shop Now",
                Clicks = 1000
            });

            _dbContext.Add(new Advert
            {
                Header = "New Arrivals",
                Img = "https://example.com/images/new_arrivals.png",
                Description = "Discover our latest collection of clothing and accessories",
                CallToAction = "Learn More",
                Clicks = 500
            });

            _dbContext.Add(new Advert
            {
                Header = "Limited Time Offer",
                Img = "https://example.com/images/limited_time_offer.png",
                Description = "Buy one, get one free on all shoes",
                CallToAction = "Shop Now",
                Clicks = 750
            });

            _dbContext.Add(new Advert
            {
                Header = "Back to School Sale",
                Img = "https://example.com/images/back_to_school_sale.png",
                Description = "Get 20% off on all school supplies",
                CallToAction = "Shop Now",
                Clicks = 1200
            });

            _dbContext.Add(new Advert
            {
                Header = "Holiday Special",
                Img = "https://example.com/images/holiday_special.png",
                Description = "Save up to 40% on holiday gifts",
                CallToAction = "Learn More",
                Clicks = 800
            });

            _dbContext.Add(new Advert
            {
                Header = "New Year's Sale",
                Img = "https://example.com/images/new_years_sale.png",
                Description = "Ring in the new year with big savings",
                CallToAction = "Shop Now",
                Clicks = 900
            });

            _dbContext.Add(new Advert
            {
                Header = "Clearance Event",
                Img = "https://example.com/images/clearance_event.png",
                Description = "Last chance to save on clearance items",
                CallToAction = "Shop Now",
                Clicks = 1500
            });

            _dbContext.Add(new Advert
            {
                Header = "Spring Styles",
                Img = "https://example.com/images/spring_styles.png",
                Description = "Update your wardrobe with our latest spring styles",
                CallToAction = "Learn More",
                Clicks = 600
            });

            _dbContext.Add(new Advert
            {
                Header = "Valentine's Day Sale",
                Img = "https://example.com/images/valentines_day_sale.png",
                Description = "Show your love with the perfect gift at a discount",
                CallToAction = "Shop Now",
                Clicks = 1100
            });

            _dbContext.Add(new Advert
            {
                Header = "Summer Travel",
                Img = "https://example.com/images/summer_travel.png",
                Description = "Plan your summer getaway and save on travel packages",
                CallToAction = "Learn More",
                Clicks = 700
            });
        }
    }
}
