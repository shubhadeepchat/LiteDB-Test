using LiteDB_Test.Model;
using LiteDB_Test.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiteDB_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _studentService = studentService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentService.FindAll();
        }

        [HttpPost]
        public ActionResult<Student> insert(Student student)
        {
            var id = _studentService.Insert(student);
            if (id != default)
                return CreatedAtRoute("FindById", new { id = id }, student);
            else
                return BadRequest();
        }

        [HttpGet("{id}", Name = "FindById")]
        public ActionResult<Student> GetById(int id) {
            var result = _studentService.FindOne(id);
            if (result != default)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPut]
        public ActionResult<Student> update(Student student)
        {
            var result = _studentService.Update(student);
            if (result)
                return NoContent();
            else
                return NotFound();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _studentService.Delete(id);
            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
