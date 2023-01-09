using System.ComponentModel.DataAnnotations;

namespace MagicVila_VilaAPI.Dto
{
    public class VillaDto
    { 
        public int Id  { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }    
    }
}
