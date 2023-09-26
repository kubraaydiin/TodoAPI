namespace TodoAPI.Data.Entities
{
    public class Users : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
    }
}
