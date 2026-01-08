namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
