using LiteDB;

namespace LiteDB_Test.Data
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
