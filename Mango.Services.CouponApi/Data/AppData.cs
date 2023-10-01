using Mango.Services.CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponApi.Data
{
    public class AppData:DbContext
    {
        public AppData(DbContextOptions<AppData> options):base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id= 1,
                CouponCode="100FF",
                DiscountAmount=10,
                MinAmount=20
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "200FF",
                DiscountAmount = 20,
                MinAmount = 30
            });
        }
    }
}
