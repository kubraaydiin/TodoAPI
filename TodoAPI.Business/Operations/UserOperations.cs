using TodoAPI.Data.Entities;
using TodoAPI.Data.Repository;


namespace TodoAPI.Business.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IUserRepository _userRepository;
        private readonly IBaseRepository<Users> _baseRepository;
        public UserOperations(IUserRepository userRepository, IBaseRepository<Users> baseRepository)
        {
            _userRepository = userRepository;
            _baseRepository = baseRepository;
        }

        public void Add(Users userItem)
        {
            _baseRepository.Add(userItem);
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
