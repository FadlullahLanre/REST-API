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
    [Route("api/results")]
    [ApiController]
    public class ResultsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IResultsService _resultsService;

        public ResultsController(IMapper mapper, IResultsService resultsService)
        {
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(_mapper));
            _resultsService = resultsService ??
                throw new ArgumentNullException(nameof(_resultsService));
        }
        [HttpGet("{studentId}", Name = "GetResults")]
        public ActionResult GetResults(string studentId)
        {
            var resultsFromRepo = _resultsService.GetResultById(studentId);

            if (resultsFromRepo == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ResultDTO>(resultsFromRepo));



        }
        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<ResultCreationDTO>> GetResults()
        {
            var resultsFromRepo = _resultsService.GetResults();
            return Ok(_mapper.Map<IEnumerable<ResultDTO>>(resultsFromRepo));
        }
    }
}
