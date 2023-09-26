using TodoAPI.Data.Entities;

namespace TodoAPI.Business.Operations
{
    public interface IUserOperations
    {
        void Add(Users userItem);
        bool IsExistEmail(string email);
        Users GetUserByEmail(string email);
    }
}
