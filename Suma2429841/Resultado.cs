using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suma2429841
{
    [SQLite.Table("resultado")]
    public class Resultado
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("id")]
        public int Id { get; set; }
        [SQLite.Column("numero1")]
        public string? numero1 { get; set; }
        [SQLite.Column("numero2")]
        public string? numero2 { get; set; }
        [SQLite.Column("suma")]
        public string? Suma { get; set; }
    }
}
