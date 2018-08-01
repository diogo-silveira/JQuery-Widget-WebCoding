
using HotelsCombined.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelsCombined.Controllers
{
    [AllowAnonymous]
    [Route("place")]
    public class PlaceController : Controller
    {
        private readonly IPlaceRepository _placeRepository;

        public PlaceController(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }
        [AllowAnonymous]
        [HttpGet, Route("GetDomainByName")]
        public IActionResult GetDomainByName(string file)
        {
            var result = _placeRepository.Get(file);
            return Ok(result);
        }
    }

}