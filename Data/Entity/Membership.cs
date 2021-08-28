using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("T_Membership")]
    public class Membership
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Membership_Code", TypeName = "varchar(6)")]
        public string MembershipCode { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string Title { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
    }
}