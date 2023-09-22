using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDbContext _todoDbContext;
        public UserRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public void AddUsers(Users users)
        {
            _todoDbContext.Users.Add(users);
            _todoDbContext.SaveChanges();
        }

        public bool IsExist(string email)
        {
            var isExist = _todoDbContext.Users.Any(x => x.Email == email);
            return isExist;
        }

        public Users GetUserByEmail(string useremail)
        {
            var user = _todoDbContext.Users.FirstOrDefault(x => x.Email == useremail);
            return user;
        }
    }
}
