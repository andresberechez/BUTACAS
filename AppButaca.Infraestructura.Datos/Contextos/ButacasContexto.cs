
using Microsoft.EntityFrameworkCore;
using AppButaca.Infraestructura.Datos.Configs;
using AppButaca.dominio;
using System.Reflection.Emit;


namespace AppButaca.Infraestructura.Datos.Contextos
{
    public class ButacasContexto : DbContext
    {
       
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<BillboardEntity> Billboards { get; set; }  
        public DbSet<BookingEntity> Bookings { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; } 
        public DbSet<MovieEntity> Movies { get; set; }
        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<SeatEntity> Seats { get; set; }
  
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=prueba; Integrated Security=true;");
        }*/

        
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {      
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=prueba2; Integrated Security=true;")
                        .LogTo(Console.WriteLine) 
                        .EnableSensitiveDataLogging(); // para pruebas
                        optionsBuilder.UseSqlServer().EnableServiceProviderCaching(false);
         }
         
         


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BaseConfig());
            builder.ApplyConfiguration(new BillboardConfig());
            builder.ApplyConfiguration(new BookingConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new MovieConfig());
            builder.ApplyConfiguration(new RoomConfig());
            builder.ApplyConfiguration(new SeatConfig());


            builder.Entity<BillboardEntity>()
            .HasOne(b => b.Movie)
            .WithMany()
            .HasForeignKey(b => b.MovieId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<BillboardEntity>()
            .HasOne(b => b.Room)
            .WithMany()
            .HasForeignKey(b => b.RoomId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<SeatEntity>()
            .HasOne(s => s.Room)
            .WithMany()
            .HasForeignKey(s => s.RoomId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<BookingEntity>()
            .HasOne(b => b.Billboard)
            .WithMany()
            .HasForeignKey(b => b.BillboardId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<BookingEntity>()
            .HasOne(b => b.Customer)
            .WithMany()
            .HasForeignKey(b => b.CustomerId)
            .OnDelete(DeleteBehavior.Restrict); 

            builder.Entity<BookingEntity>()
            .HasOne(b => b.Seat)
            .WithMany()
            .HasForeignKey(b => b.SeatId)
            .OnDelete(DeleteBehavior.Restrict); 

            //base.OnModelCreating(builder);
           

        }

    }


}
