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
        public IEnumerable<VillaDto> GetVillas()

        {
            return VillaStore.villalist;

        }
        [HttpGet("{id:int}")]
        public VillaDto GetVilla(int id)

        {
            return VillaStore.villalist.FirstOrDefault(u => u.Id == id);

        }
    }
}
