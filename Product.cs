using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace SampleMvcApp.Models
{

    public class Product
    {
        public int PId { get; set; }
        public string PName { get; set; } = string.Empty;

        public int PPrice { get; set; }
        public string PImg { get; set; } = string.Empty;
    }


    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}