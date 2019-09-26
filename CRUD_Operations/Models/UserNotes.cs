using System;
using SQLite;

namespace CRUD_Operations.Models
{
    public class UserNotes
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(255)] 
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Desc { get; set; }
        public UserNotes()
        {
        }
    }
}
