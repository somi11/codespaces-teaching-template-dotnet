namespace MyApiApp.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        
        public List<PointOfIntrestDTO> PointOfIntrest { get; set; } = new List<PointOfIntrestDTO>();
    }
}


