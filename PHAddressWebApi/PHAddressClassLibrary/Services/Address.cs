using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using PHAddressClassLibrary.ApiResponse;
using PHAddressClassLibrary.Dto;
using PHAddressClassLibrary.Entities;

namespace PHAddressClassLibrary.Services
{
    public class Address : IAddress
    {
        private readonly PHAddressDbContext _dbContext;

        public Address(PHAddressDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Benchmark]
        public async Task<ApiResponse<BarangayMappingDto>> GetBarangayMapping(string brgyCode)
        {
            if (brgyCode == "")
            {
                return new ApiResponse<BarangayMappingDto>
                {
                    Data = new BarangayMappingDto(),
                    IsSuccess = false,
                    ErrorMessage = "InputIsNull"
                };
            }
            var mapping = await _dbContext
                .Barangays.Include(e => e.CityFK)
                .ThenInclude(e => e.ProvinceFK)
                .ThenInclude(e => e.RegionFk)
                .Where(e => e.BrgyCode == brgyCode)
                .Select(e => new BarangayMappingDto
                {
                    BarangayCode = e.BrgyCode,
                    BarangayName = e.BrgyName,
                    CityName = e.CityFK.CityName,
                    ProvinceName = e.CityFK.ProvinceFK.ProvinceName,
                    RegionName = e.CityFK.ProvinceFK.RegionFk.RegionName
                })
                .FirstOrDefaultAsync();
            if (mapping is null)
            {
                return new ApiResponse<BarangayMappingDto>
                {
                    Data = new BarangayMappingDto(),
                    IsSuccess = false,
                    ErrorMessage = "MappingNotFound"
                };
            }
            return new ApiResponse<BarangayMappingDto>
            {
                Data = mapping,
                IsSuccess = true,
                ErrorMessage = ""
            };
        }
    }
}
