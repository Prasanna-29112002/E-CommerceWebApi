using log4net;
public class UserRepository : IUserRepository
{
    private AppDbContext appDbContext;
    private static readonly ILog log = LogHelper.Logger;
    public UserRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<User> GetUsers()
    {
        log.Info("Getting all the users data by admin");
        return appDbContext.Users.ToList();
    }
    public User Register(User user)
    {
        var found = appDbContext.Users.FirstOrDefault(u => u.Email == user.Email);
        if (found != null)
        {
            log.Warn($"Already user Registered with this Email {user.Email}");
            return found;
        }
        else
        {
            log.Info("Registering User");
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
            log.Info("User added to database Sucessfully");
            return user;

        }
        
    }

    public User Login(string Email, string Password)
    {
        var user = appDbContext.Users.FirstOrDefault(u => u.Email == Email && u.Password == Password);
        if (user != null)
        {
            log.Info("User logged in successfully");
            return user;
        }
        else
        {
            log.Error("User not found");
            return null;
        }
    }

    public User Profile(string email)
    {
        User found = appDbContext.Users.FirstOrDefault(u => u.Email == email);
        if (found != null)
        {
            log.Info("Fetching User Profile");
            return found;
        }
        else
        {
            log.Error("User Profile not found");
            return null;
        }
    }

    // public void Create(User user)
    // {
    //     appDbContext.Users.Add(user);
    //     appDbContext.SaveChanges();

    // }


    public void Update(int id, User user)
    {
        var productToUpdate = appDbContext.Users.Find(id);
        if (productToUpdate != null)
        {
            log.Info("Updating data of user");
            productToUpdate.Name = user.Name;
            productToUpdate.ShippingAddress = user.ShippingAddress;
            productToUpdate.PaymentDetails = user.PaymentDetails;
            appDbContext.SaveChanges();
        }
        else
        {
            log.Error("User Profile not found");
            throw new Exception("User not found!");
        }
       
    }
    public void Delete(int id)
    {
        var nproduct = appDbContext.Users.Find(id);
        if (nproduct != null)
        {
            log.Warn("Deleting user data");
            appDbContext.Remove(nproduct);
            appDbContext.SaveChanges();
            log.Info("Delete User data");
        }
        else
        {
            log.Error("Unsuccessfully Deletion of user profile!!..");

        }
        
    }
}
