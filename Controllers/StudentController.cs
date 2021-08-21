using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Data.DTO;
using APIs_Tutorial.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Tutorial.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper, IStudentService studentService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _studentService = studentService ??
                throw new ArgumentNullException(nameof(_studentService));

        }
        [HttpPost]
        public async Task<ActionResult<StudentDTO>> CreateStudent(StudentCreationDTO student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            var studentEntity = _mapper.Map<Entities.Student>(student);
            await _studentService.AddStudent(studentEntity);
            var studentToReturn = _mapper.Map<StudentDTO>(studentEntity);

            return Ok(studentToReturn);
        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var studentFromRepo = _studentService.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(studentFromRepo));
        }
        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudent(Guid studentId)
        {
            var studentFromRepo = _studentService.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<StudentDTO>(studentFromRepo));


        }
        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(Guid studentId)
        {
            var studentFromRepo = _studentService.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }
            _studentService.DeleteStudent(studentFromRepo);
            _studentService.Commit();

            return NoContent();

        }
        [HttpPut("{studentId}")]
        public ActionResult UpdateResult(Guid studentId, StudentCreationDTO updatedStudent)
        {
            var studentFromRepo = _studentService.GetStudentById(studentId);

            if (studentFromRepo == null)
            {
                return NotFound();
            }
            studentFromRepo.Department = updatedStudent.Department;
            studentFromRepo.FirstName = updatedStudent.FirstName;
            studentFromRepo.LastName = updatedStudent.LastName;

            _studentService.UpdateStudent(studentFromRepo);
            _studentService.Commit();

            return NoContent();
        }
        [HttpOptions]
        public IActionResult GetStudentOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }





    }
}






