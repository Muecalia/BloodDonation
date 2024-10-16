namespace BloodDonation.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity() 
        {
            IsDeleted = false;
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
