public interface IAdminRepository
{
    List<Admin> GetAdmins();
    void Create(Admin admin);
    Admin Profile(string email);
    void Update(int id, Admin admin);
     void Delete(int id);   
}