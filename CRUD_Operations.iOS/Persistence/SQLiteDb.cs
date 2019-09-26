using System;
using System.IO;
using CRUD_Operations.Persistence;
using SQLite;

namespace CRUD_Operations.iOS.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "chinook.db");

            return new SQLiteAsyncConnection(path);
        }
    }
}
