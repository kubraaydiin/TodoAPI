namespace TodoAPI.Data.Entities
{
    public class TodoItem : BaseEntity
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
