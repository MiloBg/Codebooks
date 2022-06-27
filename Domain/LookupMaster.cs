using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LookupMaster
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = Environment.UserName;
        public List<LookupValue>? LookupValues { get; set; }
    }
}