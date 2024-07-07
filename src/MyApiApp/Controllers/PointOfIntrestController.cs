namespace MyApiApp.Controllers {
    using Microsoft.AspNetCore.Mvc;

    using MyApiApp.Models;


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

        [HttpGet("{pointofintrestid}" , Name = "GetPointOfIntrest")]
    public ActionResult<MyApiApp.Models.PointOfIntrestDTO> GetPointOfIntrest(int cityId , int pointofintrestid) {
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

    [HttpPost]
    public ActionResult <PointOfIntrestDTO> CreatePointOfIntrest(
        int cityId, [FromBody] PointOfIntrestForCreationDTO pointOfIntrest)   
    {
        var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);
        if(city == null) {
            return NotFound();
        }
        var maxPointOfIntrestId = CitiesDataStore.Current.Cities.SelectMany(
            c => c.PointOfIntrest).Max(p => p.Id);
        var finalPointOfIntrest = new PointOfIntrestDTO() { 
        Id = ++maxPointOfIntrestId,
        Name = pointOfIntrest.Name,
        Description = pointOfIntrest.Description
        };
        city.PointOfIntrest.Add(finalPointOfIntrest);

        return CreatedAtRoute("GetPointOfIntrest", new { cityId, pointOfIntrestId = finalPointOfIntrest.Id }, finalPointOfIntrest);
    }
 }

}