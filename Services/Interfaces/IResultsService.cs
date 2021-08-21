using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Entities;

namespace APIs_Tutorial.Services.Interfaces
{
    public interface IResultsService
    {
        IEnumerable<Results> GetResults();
        Results GetResultById(string studentId);
       

    }
}
