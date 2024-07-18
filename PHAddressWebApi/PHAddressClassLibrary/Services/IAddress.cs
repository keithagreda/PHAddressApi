using PHAddressClassLibrary.ApiResponse;
using PHAddressClassLibrary.Dto;

namespace PHAddressClassLibrary.Services
{
    public interface IAddress
    {
        Task<ApiResponse<BarangayMappingDto>> GetBarangayMapping(string brgyCode);
    }
}