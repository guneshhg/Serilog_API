using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [StringLength(6)]
        public string MembershipCode { get; set; }
    }
}