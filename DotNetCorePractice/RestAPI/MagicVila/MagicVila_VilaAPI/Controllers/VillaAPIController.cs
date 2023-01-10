using MagicVila_VilaAPI.Data;
using MagicVila_VilaAPI.Dto;
using MagicVila_VilaAPI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace MagicVila_VilaAPI.Controllers
{
    //[Route("API/[Controller]")]
    [Route("API/VillaAPI")]
    //[ApiController]
   
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()

        {
            return Ok(VillaStore.villalist);

        }
        [HttpGet("{id:int}",Name="GetVilla")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> CreateVilas([FromBody]VillaDto villadto) 
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (VillaStore.villalist.FirstOrDefault(u=>u.Name.ToLower()==villadto.Name.ToLower())!=null)
                {
                ModelState.AddModelError("customerror", "Villa allready exist!");
                return BadRequest(ModelState);
                }
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
        //return Ok(villadto);
       return  CreatedAtRoute("GetVilla", new { id = villadto.Id }, villadto);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa=VillaStore.villalist.FirstOrDefault(u=>u.Id==id);
            if (villa==null)
            {
                return NotFound();

            }
            VillaStore.villalist.Remove(villa);
            return NoContent();
        }

        [HttpPut ("{id:int}",Name="UpdateVilla")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDto villadto)
        {
            if (villadto==null||id!=villadto.Id) 
            { 
            
            return BadRequest();    
            }
           var  villa=VillaStore.villalist.FirstOrDefault(u=>u.Id==id);
            //if (villa!=null)
            //{

            //}
            villa.Name=villadto.Name;
            villa.SQft=villadto.SQft;   
            villa.Occupancy=villadto.Occupancy;
            return NoContent();

        }


        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {

                return BadRequest();
            }
           
            var villa =VillaStore.villalist.FirstOrDefault(u=> u.Id==id);
            if (villa==null)
            {
                return BadRequest();

            }
            patchDto.ApplyTo(villa,ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
