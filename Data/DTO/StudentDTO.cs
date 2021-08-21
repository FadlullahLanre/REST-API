using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_Tutorial.Data.DTO
{
    public class StudentDTO
    {
        public Guid StudentID { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
    }
}
