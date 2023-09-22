using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public interface IUserRepository
    {
        void AddUsers(Users users);
        bool IsExist(string email);
        Users GetUserByEmail(string useremail);
    }
}
