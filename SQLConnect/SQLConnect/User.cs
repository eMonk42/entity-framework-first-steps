using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLConnect
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("first_name", TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "varchar(40)")]
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Column("age")]
        [Required]
        public int Age { get; set; }

        [Column("telephone_numbers")]
        [Required]
        public virtual ICollection<TelephoneNumber> TelephoneNumbers { get; set; } = new List<TelephoneNumber>();
    }

    [Table("telephone_numbers", Schema = "public")]
    public class TelephoneNumber
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("type", TypeName = "varchar(20)")]
        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Column("number", TypeName = "varchar(20)")]
        [Required]
        [MaxLength(20)]
        public string Number { get; set; }
    }
}
