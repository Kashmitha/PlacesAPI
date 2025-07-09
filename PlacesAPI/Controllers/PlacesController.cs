using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlacesAPI.Data;
using PlacesAPI.Models.Dto;
using PlacesAPI.Models.Entities;

namespace PlacesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly PlaceDbContext placeDbContext;

        public PlacesController(PlaceDbContext placeDbContext)
        {
            this.placeDbContext = placeDbContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var AllPlaces = placeDbContext.places.ToList();
            return Ok(AllPlaces);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var place = placeDbContext.places.FirstOrDefault(x => x.Id == id);
            if(place == null)
            {
                return NotFound();
            }
            return Ok(place);
        }
        [HttpPost]
        public IActionResult AddPlace(AddPlaceDto addPlaceDto)
        {
            // Map Dto to Entity
            var placeEntity = new Places()
            { 
                Name = addPlaceDto.Name, 
                Description = addPlaceDto.Description, 
                ImageUrl = addPlaceDto.ImageUrl 
            };

            placeDbContext.places.Add(placeEntity);
            placeDbContext.SaveChanges();
            return Ok(placeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdatePlaces(Guid id, UpdatePlacesDto updatePlaceDto)
        {
            var place = placeDbContext.places.FirstOrDefault(x => x.Id == id);
            if(place == null)
            {
                return NotFound();
            }
            place.Name = updatePlaceDto.Name;
            place.Description = updatePlaceDto.Description;
            place.ImageUrl = updatePlaceDto.ImageUrl;
            placeDbContext.SaveChanges();

            return Ok(place);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeletePlace(Guid id)
        {
            var place = placeDbContext.places.FirstOrDefault(x =>x.Id == id);
            if(place == null)
            {
                return NotFound();
            }
            placeDbContext.places.Remove(place);
            placeDbContext.SaveChanges();
            return Ok(place);
        }
    }
}
