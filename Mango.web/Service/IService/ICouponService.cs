using Mango.web.Models;

namespace Mango.web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponcode);
        Task<ResponseDto?> GetAllCouponAsync();
        Task<ResponseDto?> CreateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> UpdateCouponAsync(CouponDTO couponDTO);
        Task<ResponseDto?> DeleteCouponAsync(int id);

    }
}
