using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_Tutorial.Data.DTO
{
    public class ExamDetailDTO
    {
        public string Examvenue { get; set; }
        public string StudentID { get; set; }
        public string Subjects { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
