using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuseumController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public MuseumController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ExhibitionDTO>>> GetExhibitions()
        {
            var models = await _unitOfWork.ExhibitionRepository.GetAllAsync();

            if (models.Count() < 1)
            {
                return BadRequest($"Error");
            }

            var dto = new ExhibitionDTO();

            return Ok();
        }
    }
}