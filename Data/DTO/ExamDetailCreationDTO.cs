using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_Tutorial.Data.DTO
{
    public class ExamDetailCreationDTO
    {
        public string StudentID { get; set; }
        public string SubjectOne { get; set; }
        public string SubjectTwo { get; set; }
        public string SubjectThree { get; set; }
        public string SubjectFour { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
