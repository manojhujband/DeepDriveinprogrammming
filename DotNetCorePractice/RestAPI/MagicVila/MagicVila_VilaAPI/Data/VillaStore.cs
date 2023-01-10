using MagicVila_VilaAPI.Dto;

namespace MagicVila_VilaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villalist= new List<VillaDto>()  
            
            {
                new VillaDto { Id = 1, Name = "Pool View",SQft=100,Occupancy=4 },
                new VillaDto{ Id = 2, Name = "Beach View" ,SQft=300,Occupancy=3}
            };
    }
    
}
