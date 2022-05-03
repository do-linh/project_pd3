using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotelManager.Models.EF
{
    [Table("Code")]
    public partial class Code
    {
        [Key]
        public int code_id { get; set; }

        [Column("code")]
        [StringLength(200)]
        public string code { get; set; }

    }
}