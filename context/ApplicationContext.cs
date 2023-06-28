using Model.models;
using Microsoft.EntityFrameworkCore;

namespace Model.context;

public sealed class ApplicationContext : DbContext
{
	public DbSet<Animal> Animals => Set<Animal>();



	public ApplicationContext() : base()
	{
	}


protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite("Data Source=zooApp.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Animal>()
			.HasOne(a => a.Cell)
			.WithMany(c => c.Animals)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Animal>()
			.Navigation(a => a.Zookeepers);

		modelBuilder.Entity<Zookeeper>().Navigation(z => z.Animals);


		modelBuilder.Entity<Meal>();


		base.OnModelCreating(modelBuilder);

	}
}