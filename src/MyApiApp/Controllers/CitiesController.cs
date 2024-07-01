
using Microsoft.AspNetCore.Mvc;

namespace MyApiApp.Controllers
{
 [ApiController]
 [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
   
  [HttpGet()]
public ActionResult GetCities() {

        return Ok(CitiesDataStore.Current.Cities);
}

[HttpGet("{id}")]
public ActionResult GetCity(int id) {
  
       var CityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
       
       if(CityToReturn == null) {
           return NotFound();
       }
    return Ok(CityToReturn);

}

}

}