using AutoMapper;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitionController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExhibitionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExhibitionDTO>>> GetExhibitions()
        {
            var exhibitions = await _unitOfWork.ExhibitionRepository.GetAllAsync();

            if (exhibitions is null || exhibitions.Count() == 0)
            {
                return BadRequest("There are not any exhibitions");
            }

            return Ok(_mapper.Map<IEnumerable<ExhibitionDTO>>(exhibitions));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{name}")]
        public async Task<ActionResult> ChangeExhibition(string name)
        {
            var exhibition = await _unitOfWork.ExhibitionRepository.FindAsync(x => x.Name == name);

            if (exhibition is null)
            {
                return BadRequest(string.Format("Not found exhibition with name {0}", name));
            }

            exhibition.NumberOfVisitors++;

            _unitOfWork.ExhibitionRepository.Update(exhibition);

            await _unitOfWork.ConfirmAsync();

            return NoContent();
        }
    }
}