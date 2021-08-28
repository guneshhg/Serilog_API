using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class MembershipDTO
    {
        [StringLength(6)]
        public string MembershipCode { get; set; }

        [Required]
        [StringLength(10)]
        public string Title { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}