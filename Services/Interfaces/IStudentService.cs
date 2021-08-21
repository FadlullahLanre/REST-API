using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Entities;

namespace APIs_Tutorial.Services.Interfaces
{
    public interface IStudentService
    {

        IEnumerable<Student> GetStudents();
        Student GetStudentById(Guid studentId);
        Student UpdateStudent(Student student);
        Task<Student> AddStudent(Student student);
        Student Login(Guid studentId, string FirstName);
        void DeleteStudent(Student student);
        bool Commit();
   

        
    }
}
