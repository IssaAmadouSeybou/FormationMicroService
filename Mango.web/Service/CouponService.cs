using Mango.web.Models;
using Mango.web.Service.IService;
using Mango.web.Utulity;

namespace Mango.web.Service
{
    public class CouponService : ICouponService
    {
        private readonly BaseService service;
        public CouponService(BaseService service)
        {
            this.service = service;
        }

        public async Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data= couponDTO,
                Url = SD.CouponApiBase + "/api/coupon/" 
            });
        }

        public async  Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.CouponApiBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> GetAllCouponAsync()
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url=SD.CouponApiBase+"/api/coupon"
            }) ;
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponcode)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon/GetByCode/"+couponcode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.CouponApiBase + "/api/coupon/" + id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await service.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data=couponDTO,
                Url = SD.CouponApiBase + "/api/coupon/"
            }) ;
        }
    }
}
