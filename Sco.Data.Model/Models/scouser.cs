using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sco.Data.Model
{
    [Table("scouser")]
    public partial class scouser
    {
        [Key]
        public int ScoUserId { get; set; }

        [Required]
        [StringLength(1000)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1000)]
        public string EmailId { get; set; }

        [Required]
        [StringLength(5000)]
        public string Password { get; set; }

        public int? CreatedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreatedDateTime { get; set; }

        public int? ModifiedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ModifiedDateTime { get; set; }
    }
}
