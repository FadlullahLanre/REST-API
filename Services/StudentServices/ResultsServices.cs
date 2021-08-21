using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Data;
using APIs_Tutorial.Entities;
using APIs_Tutorial.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIs_Tutorial.Services.StudentServices
{
    public class ResultsServices : IResultsService
    {

        private readonly StudentDBContext _context;

        public ResultsServices(StudentDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Results> GetResults()
        {
            var query = from x in _context.Results
                        orderby x.Aggregate
                        select x;
            return query;

        }

        public Results GetResultById(string studentId)
        {
            if (studentId == string.Empty)
            {
                throw new NotImplementedException(nameof(studentId));
            }
            return _context.Results.FirstOrDefault(x => x.StudentID == studentId);
            
        }

     
            
        }
    }

