using TodoAPI.Data.Entities;
using TodoAPI.Data.Repository;


namespace TodoAPI.Business.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IUserRepository _userRepository;
        public UserOperations(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(Users userItem)
        {
            _userRepository.AddUsers(userItem);
        }

        public bool IsExistEmail(string email)
        {
            var isExist = _userRepository.IsExist(email);

            return isExist;
        }

        public Users GetUserByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user;
        }



    }
}
