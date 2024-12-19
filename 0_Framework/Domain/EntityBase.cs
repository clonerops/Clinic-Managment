namespace _0_Framework.Domain
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }

        public EntityBase()
        {
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
    }
}
