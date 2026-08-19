using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LandenModel;

public class LandenContext : DbContext
{
    public DbSet<Land> Landen { get; set; }
    public DbSet<Stad> Steden { get; set; }
    public DbSet<Taal> Talen { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Land>()
            .HasMany(l => l.Steden)
            .WithOne(s => s.Land)
            .HasForeignKey(s => s.LandCode);

        modelBuilder.Entity<Land>()
            .HasMany(l => l.Talen)
            .WithMany(lt => lt.Landen)
            .UsingEntity<Dictionary<string, object>>(
                "LandenTaal",

                JoinToTaal => JoinToTaal
                    .HasOne<Taal>()
                    .WithMany()
                    .HasForeignKey("TaalCode"),
                joinToLand => joinToLand
                    .HasOne<Land>()
                    .WithMany()
                    .HasForeignKey("LandCode"),
                joinEntity =>
                {
                    joinEntity.HasKey("LandCode", "TaalCode");
                    joinEntity.HasData(
                        new { LandCode = "BEL", TaalCode = "de" },
                        new { LandCode = "BEL", TaalCode = "fr" },
                        new { LandCode = "BEL", TaalCode = "nl" },
                        new { LandCode = "DEU", TaalCode = "de" },
                        new { LandCode = "FRA", TaalCode = "fr" },
                        new { LandCode = "LUX", TaalCode = "de" },
                        new { LandCode = "LUX", TaalCode = "fr" },
                        new { LandCode = "LUX", TaalCode = "lb" },
                        new { LandCode = "NLD", TaalCode = "nl" }
                    );
                });

        modelBuilder.Entity<Land>().HasData(
            new Land { LandCode = "BEL", Naam = "België" },
            new Land { LandCode = "DEU", Naam = "Duitsland" },
            new Land { LandCode = "FRA", Naam = "Frankrijk" },
            new Land { LandCode = "LUX", Naam = "Luxemburg" },
            new Land { LandCode = "NLD", Naam = "Nederland" }
        );

        modelBuilder.Entity<Stad>().HasData(
            new Stad { StadNr = 1, Naam = "Brussel", LandCode = "BEL" },
            new Stad { StadNr = 2, Naam = "Antwerpen", LandCode = "BEL" },
            new Stad { StadNr = 3, Naam = "Luik", LandCode = "BEL" },
            new Stad { StadNr = 4, Naam = "Amsterdam", LandCode = "NLD" },
            new Stad { StadNr = 5, Naam = "Den Haag", LandCode = "NLD" },
            new Stad { StadNr = 6, Naam = "Rotterdam", LandCode = "NLD" },
            new Stad { StadNr = 7, Naam = "Berlijn", LandCode = "DEU" },
            new Stad { StadNr = 8, Naam = "Hamburg", LandCode = "DEU" },
            new Stad { StadNr = 9, Naam = "München", LandCode = "DEU" },
            new Stad { StadNr = 10, Naam = "Luxemburg", LandCode = "LUX" },
            new Stad { StadNr = 11, Naam = "Parijs", LandCode = "FRA" },
            new Stad { StadNr = 12, Naam = "Marseille", LandCode = "FRA" },
            new Stad { StadNr = 13, Naam = "Lyon", LandCode = "FRA" }
        );

        modelBuilder.Entity<Taal>().HasData(
            new Taal { TaalCode = "de", Naam = "Duits" },
            new Taal { TaalCode = "fr", Naam = "Frans" },
            new Taal { TaalCode = "lb", Naam = "Luxemburgs" },
            new Taal { TaalCode = "nl", Naam = "Nederlands" }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("Appsettings.json")
            .Build();

        optionsBuilder.UseSqlServer(
            config.GetConnectionString("Landen"));
    }
}




