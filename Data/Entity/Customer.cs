using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("T_Customer")]
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Column("First_Name", TypeName = "varchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column("Last_Name", TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Gender { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }
        [Column("Birth_Date")]
        public DateTime? BirthDate { get; set; }
        [Column("Membership_Code")]
        public string MembershipCode { get; set; }
        [ForeignKey("MembershipCode")]
        public Membership Membership { get; set; }
    }
}