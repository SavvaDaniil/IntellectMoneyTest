using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntellectMoneyTest.Entities
{
    [Table("newsletter")]
    public class Newsletter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id", Order = 0)]
        public int id { get; set; }

        [Column("name", TypeName = "varchar(256)")]
        public string name { get; set; }

        [Column("subject", TypeName = "varchar(256)")]
        public string subject { get; set; }

        [Column("name", TypeName = "TEXT")]
        public string messageText { get; set; }

        [Column("active", TypeName = "int(1)")]
        [System.ComponentModel.DefaultValue("0")]
        public int active { get; set; }

        public DateTime? dateOfAdd { get; set; }

        public DateTime? dateOfFinished { get; set; }
    }
}
