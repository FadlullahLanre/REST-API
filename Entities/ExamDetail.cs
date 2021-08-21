using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIs_Tutorial.Entities
{
    public class ExamDetail
    {
        public ExamDetail()
        {
            DateCreated  = DateTime.Now;
            String[] Venue = { "Lagos", "Ibadan", "Abuja", "Kaduna", "PortHarcourt", "Benin", "Kano", "Owerri" };
            Random rnd = new Random();
            Examvenue = Venue[rnd.Next(Venue.Length)];
        }


        [Key]
        public string Examvenue { get; set; }
        public string StudentID { get; set; }
        public string SubjectOne { get; set; }
        public string SubjectTwo { get; set; }
        public string SubjectThree { get; set; }
        public string SubjectFour { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
