public interface IUserRepository
{
    List<User> GetUsers();
    User Register(User user);



    User Login(string Email, string password);

    User Profile(string email);


    void Update(int id, User user);
    void Delete(int id);
}