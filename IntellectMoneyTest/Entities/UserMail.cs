using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntellectMoneyTest.Entities
{
    [Table("user_lite")]
    public class UserMail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("id", Order = 0)]
        public int id { get; set; }

        [Column("id_of_user", TypeName = "int(11)")]
        [System.ComponentModel.DefaultValue("0")]
        public int id_of_user { get; set; }

        public Newsletter newsletter { get; set; }

        [Column("username", TypeName = "varchar(256)")]
        public string username { get; set; }

        [Column("name", TypeName = "varchar(256)")]
        public string name { get; set; }

        [Column("active", TypeName = "int(1)")]
        [System.ComponentModel.DefaultValue("1")]
        public int active { get; set; }

        [Column("is_sended", TypeName = "int(1)")]
        [System.ComponentModel.DefaultValue("0")]
        public int isSended { get; set; }

        [Column("mail_error", TypeName = "int(1)")]
        [System.ComponentModel.DefaultValue("0")]
        public int mailError { get; set; }


        public DateTime? dateOfAdd { get; set; }
        public DateTime? dateOfLastTrySendMail { get; set; }
        public DateTime? dateOfSendMail { get; set; }


    }
}
