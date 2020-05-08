namespace Models
{
	public class DatabaseContext : System.Data.Entity.DbContext
	{
		static DatabaseContext()
		{
			// فقط به درد برنامه نويسان آنهم در زمان پياده سازی می خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.DropCreateDatabaseAlways<DatabaseContext>());

			// فقط به درد برنامه نويسان آنهم در زمان پياده سازی می خورد
			System.Data.Entity.Database.SetInitializer
				(new System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>());

			// به درد مشتری می خورد
			//System.Data.Entity.Database.SetInitializer
			//	(new System.Data.Entity.CreateDatabaseIfNotExists<DatabaseContext>());
		}

		public DatabaseContext() : base()
		{

			System.Data.Entity.Database.SetInitializer(new DatabaseContextInitializer());
		}

		public System.Data.Entity.DbSet<Role> Roles { get; set; }
		public System.Data.Entity.DbSet<User> Users { get; set; }
		public System.Data.Entity.DbSet<Feature> Features { get; set; }
		public System.Data.Entity.DbSet<Product> Products { get; set; }
		public System.Data.Entity.DbSet<ProductTag> ProductTags { get; set; }
		public System.Data.Entity.DbSet<ProductGroup> ProductGroups { get; set; }
		public System.Data.Entity.DbSet<ProductFeature> ProductFeatures { get; set; }
		public System.Data.Entity.DbSet<ProductGallery> ProductGalleries { get; set; }
		public System.Data.Entity.DbSet<ProductSelectedGroup> ProductSelectedGroups { get; set; }
	}
}
