using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExcursionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExcursionDTO>>> GetExcursions()
        {
            var excursions = await _unitOfWork.ExcursionRepository.GetAllAsync();

            if (excursions is null || excursions.Count() == 0)
            {
                return BadRequest("There are not any excursions");
            }

            return Ok(_mapper.Map<IEnumerable<ExcursionDTO>>(excursions));
        }
    }
}