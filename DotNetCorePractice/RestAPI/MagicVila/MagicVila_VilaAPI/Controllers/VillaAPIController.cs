using MagicVila_VilaAPI.Data;
using MagicVila_VilaAPI.Dto;
using MagicVila_VilaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVila_VilaAPI.Controllers
{
    //[Route("API/[Controller]")]
    [Route("API/VillaAPI")]
    [ApiController]
   
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()

        {
            return Ok(VillaStore.villalist);

        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
             
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa = VillaStore.villalist.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> CreateVilas([FromBody]VillaDto villadto) 
        { 
            if (villadto == null)
            {
                return BadRequest(villadto);
            }
            if(villadto.Id>0)
            {
               return StatusCode(StatusCodes.Status500InternalServerError);

            }
            villadto.Id = VillaStore.villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            VillaStore.villalist.Add(villadto);
            return Ok(villadto);
        }
    }
}
