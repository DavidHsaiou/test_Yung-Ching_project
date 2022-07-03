using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using test_Yung_Ching_project.Models;

namespace test_Yung_Ching_project.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<test_Yung_Ching_project.Models.ErrorViewModel>? ErrorViewModel { get; set; }
    public DbSet<test_Yung_Ching_project.Models.ItemModel>? ItemModel { get; set; }
}