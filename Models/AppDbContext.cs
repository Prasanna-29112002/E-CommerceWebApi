
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<MyOrder> MyOrders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Payment> Payments { get; set; }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, Name = "Teja", Email = "Teja@User.com", Password = "user123", Role = Role.User, Phone = "2648264816", ShippingAddress = "Hyderabad", PaymentDetails = "pending" },
            new User { UserId = 2, Name = "Sowmya", Email = "Sowmya@User.com", Password = "user123", Role = Role.User, Phone = " 5262627771", ShippingAddress = "Banglore", PaymentDetails = "pending" },
            new User { UserId = 3, Name = "Harshitha", Email = "Harshitha@User.com", Password = "user123", Role = Role.User, Phone = "42548648246", ShippingAddress = "Chennai", PaymentDetails = "Loading" }

        );
        modelBuilder.Entity<Admin>().HasData(
             new Admin { AdminId = 1, Name = "Prasanna", Permissions = "All", Role = Role.Admin, Email = "Prasanna123@Admin.com", Password = "Prasanna123" },
             new Admin { AdminId = 2, Name = "Harsha", Permissions = "All", Role = Role.Admin, Email = "Harsha123@Admin.com", Password = "Harsha123" },
          new Admin { AdminId = 3, Name = "Vidya", Permissions = "All", Role = Role.Admin, Email = "Vidya123@Admin.com", Password = "Vidya123" },
           new Admin { AdminId = 4, Name = "Chandu", Permissions = "All", Role = Role.Admin, Email = "Chandu123@Admin.com", Password = "Chandu123" }
      );
        modelBuilder.Entity<Category>().HasData(
             new Category { CategoryId = 1, Name = "Woman" },
             new Category { CategoryId = 2, Name = "Men" },
             new Category { CategoryId = 3, Name = "Kids" },
             new Category { CategoryId = 4, Name = "Beauty" }
         );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, ProductName = "Jeans", Description = "High Waist Skinny ", Price = 999, Category = "Woman", ImageURL = "2648264816" },
            new Product { ProductId = 2, ProductName = "Tops", Description = "Pure Cotton", Price = 399, Category = "Woman", ImageURL = "2648264816" },
            new Product { ProductId = 3, ProductName = "Shirt", Description = "Mean's Casual", Price = 899, Category = "Men", ImageURL = "2648264816" },
            new Product { ProductId = 4, ProductName = "Trouserds", Description = "Blue slim Fit", Price = 1365, Category = "Men", ImageURL = "2648264816" },
             new Product { ProductId = 5, ProductName = "Jumpsuits", Description = "Pure Cotton ", Price = 999, Category = "Kids", ImageURL = "2648264812" },
            new Product { ProductId = 6, ProductName = "Flared Dresses", Description = "Pure Cotton", Price = 599, Category = "Kids", ImageURL = "2644364816" },
            new Product { ProductId = 7, ProductName = "Sunscreen", Description = "SPF 50++++", Price = 899, Category = "Beauty", ImageURL = "2648264566" },
            new Product { ProductId = 8, ProductName = "Serum", Description = "Niacinamide Face with Zinc", Price = 453, Category = "Buauty", ImageURL = "2648265816" }
        );
    //     modelBuilder.Entity<Payment>().HasData(
    //        new Payment { OrderId = 1002, UserId = 1, TotalPrice =3500, ShippingAddress ="1/4/,madhavcolony,hyderabad", OrderStatus ="Pending", paymentType =PaymentType. UPI, PaymentStatus ="Success"},
    //     new Payment { OrderId = 1003, UserId = 3, TotalPrice =4000, ShippingAddress ="3-5-24,vanara street,vikas colony,Ongole", OrderStatus ="Success", paymentType =PaymentType. PayPal, PaymentStatus ="Success"}

           
    //    );






        // modelBuilder.Entity<ShoppingCart>()
        //     .HasIndex(c => c.UserId)
        //     .IsUnique(); 




    }

  
}

