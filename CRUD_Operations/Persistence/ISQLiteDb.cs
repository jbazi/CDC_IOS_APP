using System;
using SQLite;

namespace CRUD_Operations.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
