using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public interface IUserRepository
    {
        bool IsExist(string email);
        Users GetUserByEmail(string useremail);
    }
}
