using LiteDB_Test.Model;
namespace LiteDB_Test.Service
{
    public interface IStudentService
    {
        bool Delete(int id);
        IEnumerable<Student> FindAll();
        Student FindOne(int id);
        int Insert(Student student);
        bool Update(Student student);
    }
}
