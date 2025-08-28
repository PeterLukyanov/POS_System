using Microsoft.EntityFrameworkCore;
using Models;

namespace Db;

public class POS_System_Db : DbContext
{
    public POS_System_Db(DbContextOptions options) : base(options) { }
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<MenuPosition> MenuPositions { get; set; } = null!;
}