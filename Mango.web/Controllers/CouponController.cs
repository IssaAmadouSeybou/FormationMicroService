using Mango.web.Models;
using Mango.web.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.web.Controllers
{
    public class CouponController : Controller
    {
        private readonly CouponService couponService;
        public CouponController(CouponService couponService)
        {
            this.couponService = couponService;
        }

        public async Task<IActionResult> CouponIndex()
        {
            List<CouponDTO>? list = new();
            ResponseDto? responseDto=await couponService.GetAllCouponAsync();
            if(responseDto!=null && (bool)responseDto.Success) 
            { 
                list=JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(responseDto.Result));
            }
            return View(list);
        }
    }
}
