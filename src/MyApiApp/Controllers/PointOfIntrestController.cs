namespace MyApiApp.Controllers {
    using Microsoft.AspNetCore.Mvc;

[Route("api/cities/{cityId}/pointsofintrest")]     
[ApiController]
    public class PointOfIntrestController : ControllerBase {

     [HttpGet()]   
     public ActionResult<IEnumerable<PointOfIntrestDTO>> GetPointOfIntrest(int cityId) {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null) {
                return NotFound();
            }
            return Ok(city.PointOfIntrest);
        }

        [HttpGet("{pointofintrestid}")]
    public ActionResult<PointOfIntrestDTO> GetPointOfIntrest(int cityId , int pointofintrestid) {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if(city == null) {
            return NotFound();
        }
        var pointOfIntrest = city.PointOfIntrest.FirstOrDefault(p => p.Id == pointofintrestid);
        if(pointOfIntrest == null) {
            return NotFound();
        }
        return Ok(pointOfIntrest);
    }
 }

}