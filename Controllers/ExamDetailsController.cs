using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIs_Tutorial.Data.DTO;
using APIs_Tutorial.Services.Interfaces;
using APIs_Tutorial.Services.StudentServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Tutorial.Controllers
{
    [Route("api/examDetails")]
    [ApiController]
    public class ExamDetailsController : ControllerBase
    {



        private readonly IMapper _mapper;
        private readonly IExamService _examService;

        public ExamDetailsController(IMapper mapper, IExamService examService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _examService = examService ??
                throw new ArgumentNullException(nameof(_examService));
        }
        [HttpPost]
        public async Task<ActionResult<ExamDetailDTO>> CreateExamDetail(ExamDetailCreationDTO examCreation)
        {
            if (examCreation == null)
            {
                return BadRequest();
            }
            var examDetailEntity = _mapper.Map<Entities.ExamDetail>(examCreation);
            await _examService.AddExamDetails(examDetailEntity);
            var examDetailToReturn = _mapper.Map<ExamDetailDTO>(examDetailEntity);

            return Ok(examDetailToReturn);
        }
        [HttpGet("{studentId}", Name = "GetExamDetails")]
        public ActionResult GetExamDetails(string studentId)
        {
            var examDetailsFromRepo = _examService.GetExamDetailsById(studentId);

            if (examDetailsFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ExamDetailDTO>(examDetailsFromRepo));

        }
        [HttpPut("{studentId}")]
        public IActionResult UpdateExamDetails(string studentId, ExamDetailCreationDTO updatedExamDetails)
        {
            var examDetailsFromRepo = _examService.GetExamDetailsById(studentId);

            if (examDetailsFromRepo == null)
            {
                return NotFound();
            }
            examDetailsFromRepo.SubjectThree = updatedExamDetails.SubjectThree;
            examDetailsFromRepo.SubjectTwo = updatedExamDetails.SubjectTwo;
            examDetailsFromRepo.SubjectOne = updatedExamDetails.SubjectOne;
            examDetailsFromRepo.SubjectFour = updatedExamDetails.SubjectFour;
            examDetailsFromRepo.DateCreated = updatedExamDetails.DateCreated;

            _examService.UpdateExamDetails(examDetailsFromRepo);
            _examService.Commit();

            return NoContent();

        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<ExamDetailCreationDTO>> GetExamDetail()
        {
            var examDetailsFromRepo = _examService.GetExamDetails();
            return Ok(_mapper.Map<IEnumerable<ExamDetailDTO>>(examDetailsFromRepo));
        }
        [HttpOptions]
        public IActionResult GetExamDetailsOptions()
        {
            Response.Headers.Add("Allow", "GET,OPTIONS,POST");
            return Ok();
        }
    }
}


