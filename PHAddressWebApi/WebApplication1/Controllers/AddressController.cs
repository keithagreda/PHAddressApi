using Microsoft.AspNetCore.Mvc;
using PHAddressClassLibrary.ApiResponse;
using PHAddressClassLibrary.Dto;
using PHAddressClassLibrary.Services;

namespace PHAddressWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _IAddressServices;

        public AddressController(IAddress iAddressServices)
        {
            _IAddressServices = iAddressServices;
        }

        [HttpGet("GetBarangayMapping/{brgyCode}")]
        public async Task<ActionResult<ApiResponse<BarangayMappingDto>>> GetBarangayMapping(
            string brgyCode
        )
        {
            var result = await _IAddressServices.GetBarangayMapping(brgyCode);
            return result;
        }
    }
}
