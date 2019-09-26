using System;
using SQLite;

namespace CRUD_Operations.Models
{
    public class TimeTracker
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
