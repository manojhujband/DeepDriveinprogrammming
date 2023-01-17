using System.ComponentModel.DataAnnotations;

namespace MagicVila_VilaAPI.Models
{
    public class Villa
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int SQft { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }
        public string ImageUrl { get; set; }
        public string Amentiy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
