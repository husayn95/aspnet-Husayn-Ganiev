using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace GymPortal.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        // Use the same SQLite file the app uses. Adjust path if needed.
        optionsBuilder.UseSqlite("Data Source=gymportal.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
