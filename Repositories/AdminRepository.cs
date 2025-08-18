

using log4net;
using Microsoft.EntityFrameworkCore;
public class AdminRepository : IAdminRepository
{
    private AppDbContext appDbContext;
    private static readonly ILog log = LogHelper.Logger;
    public AdminRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public Admin Profile(string email)
    {
        Admin found = appDbContext.Admins.FirstOrDefault(u => u.Email == email);
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
    public List<Admin> GetAdmins()
    {
         log.Info("Getting all Admin Data!..");
        return appDbContext.Admins.ToList(); 
    }


    public void Create(Admin admin)
    {
        log.Warn("Adding the New Admin!..");
        appDbContext.Admins.Add(admin);
        appDbContext.SaveChanges();
        log.Info("New Admin is added.");
    }
    public void Update(int id, Admin admin)
    {
        var adToUpdate = appDbContext.Admins.Find(id);
        if (adToUpdate != null)
        {
            log.Warn("Updating data of Admin!..");
            adToUpdate.Permissions = admin.Permissions;
            adToUpdate.Role = admin.Role;
            adToUpdate.Name = admin.Name;
            adToUpdate.Email = admin.Email;
            adToUpdate.Password = admin.Password;   
            appDbContext.SaveChanges();
            log.Info("Updated data successfully.");
        }
        else
        {
             log.Error(" Admin not found");
        }
        
    }
    public void Delete(int id)
    {
        var ad = appDbContext.Admins.Find(id);
        if (ad != null)
        {
            log.Warn("Deleting Admin data");
            appDbContext.Remove(ad);
            appDbContext.SaveChanges();
            log.Info("Deleted Admin data");
        }
        else
        {
             log.Error("Unsuccessfull Deletion of Admin profile!!!!");
        }
    }

    

    
}

