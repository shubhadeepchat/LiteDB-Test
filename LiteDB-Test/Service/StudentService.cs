using LiteDB_Test.Model;
using LiteDB;
using LiteDB_Test.Data;

namespace LiteDB_Test.Service
{
    public class StudentService : IStudentService
    {
        private LiteDatabase _liteDb;
        public StudentService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
        }
        public bool Delete(int id)
        {
            return _liteDb.GetCollection<Student>("Students").Delete(id);
        }

        public IEnumerable<Student> FindAll()
        {
            var result = _liteDb.GetCollection<Student>("Students")
                .FindAll();
            return result;
        }

        public Student FindOne(int id)
        {
            return _liteDb.GetCollection<Student>("Students")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public int Insert(Student student)
        {
            return _liteDb.GetCollection<Student>("Students").Insert(student);
        }

        public bool Update(Student student)
        {
            return _liteDb.GetCollection<Student>("Students").Update(student);
        }
    }
}
