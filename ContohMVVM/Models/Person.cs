using System;
using SQLite;

namespace ContohMVVM.Models
{
    [Table("people")]
	public class Person
	{
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250),Unique]
        public string Name { get; set; }
    }
}

