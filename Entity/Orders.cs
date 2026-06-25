using System.ComponentModel.DataAnnotations;

namespace InterviewProj.Entity
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
    }
}
