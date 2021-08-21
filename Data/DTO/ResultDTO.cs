using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_Tutorial.Data.DTO
{
    public class ResultDTO
    {
        public string StudentID { get; set; }
        public int SubjectOne { get; set; }
        public int SubjectTwo { get; set; }
        public int SubjectThree { get; set; }
        public int SubjectFour { get; set; }
        public int Aggregate { get; set; }
        public string Status { get; set; }
    }
}
