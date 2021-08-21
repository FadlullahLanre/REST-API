using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Entities;

namespace APIs_Tutorial.Services.Interfaces
{
    public interface IExamService
    {

        IEnumerable<ExamDetail> GetExamDetails();
        Task<ExamDetail> AddExamDetails(ExamDetail examDetail);
        ExamDetail GetExamDetailsById(string studentId);
        ExamDetail UpdateExamDetails(ExamDetail examDetail);
        bool Commit();

       
    }
}
