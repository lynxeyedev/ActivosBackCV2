﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivosAPI.Infraestructura.Database.Entity.MySQL
{
    [Table("tickets")]
    public class TicketsEntity
    {
        [Key]
        public int idtickets { get; set; }
        public int? Campo1 { get; set; }
        public string? subject { get; set; }
        public int? Campo3 { get; set; }
        public int? idstatus { get; set; }
        public int? campo5 { get; set; }
        public int? idgroping { get; set; }
        public int? idcliente { get; set; }
        public int? campo8 { get; set; }
        public int? idapplicant { get; set; }
        public int? idorigin { get; set; }
        public bool? campo12 { get; set; }
        public bool? campo13 { get; set; }
        public bool? campo14 { get; set; }
        public bool? campo15 { get; set; }
        public bool? campo16 { get; set; }
        public bool? campo17 { get; set; }
        public bool? campo18 { get; set; }
        public bool? campo19 { get; set; }
        public int? campo20 { get; set; }
        public DateTime? fecha { get; set; }
        public int? campo22 { get; set; }
        public bool? campo23 { get; set; }
        public string? campo24 { get; set; }
        public int? campo25 { get; set; }
        public string? campo26 { get; set; }
        public bool? campo27 { get; set; }
        public int? campo28 { get; set; }
        public int? campo29 { get; set; }
        public int? campo30 { get; set; }
        public bool? campo31 { get; set; }
        public int? campo32 { get; set; }
        public int? campo33 { get; set; }
        public int? campo34 { get; set; }
    }
}
