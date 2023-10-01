using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.Models;
using Mango.Services.CouponApi.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponApiController : ControllerBase
    {
        private readonly AppData _db;
        private readonly IMapper mapper;
        private readonly ResponseDto _responseDto;
        public CouponApiController(AppData db,IMapper _mapper)
        {
            _db = db;
            this.mapper = _mapper;
            _responseDto= new ResponseDto();
        }
        [HttpGet]
        public ResponseDto GetCoupon()
        {
            try
            {
                var _couponsAlls = _db.Coupons.ToList();
                _responseDto.Result = mapper.Map<IEnumerable<CouponDTO>>(_couponsAlls);
            }catch(Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message= ex.Message;
            }
            return _responseDto;


        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetCouponById(int id)
        {
            try
            {
                var _couponById = _db.Coupons.FirstOrDefault(x => x.Id == id);
                _responseDto.Result= mapper.Map<CouponDTO>(_couponById);
            }catch(Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;


        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {
            try
            {
                var _couponById = _db.Coupons.FirstOrDefault(x => x.CouponCode.ToLower()==code.ToLower());
                _responseDto.Result = mapper.Map<CouponDTO>(_couponById);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;


        }
        [HttpPost]
        public ResponseDto AddCoupon([FromBody] CouponDTO couponDTO)
        {
            Coupon obj=mapper.Map<Coupon>(couponDTO);
            _db.Coupons.Add(obj);
            _db.SaveChanges();
            _responseDto.Result = mapper.Map<CouponDTO>(obj);
            return _responseDto;
        }
        [HttpPut]
        public ResponseDto UpdateCoupon([FromBody] CouponDTO couponDTO)
        {
            Coupon obj = mapper.Map<Coupon>(couponDTO);
            _db.Coupons.Update(obj);
            _db.SaveChanges();
            _responseDto.Result = mapper.Map<CouponDTO>(obj);
            return _responseDto;
        }
        [HttpDelete]
        public ResponseDto DeleteCoupon(int id)
        {
            Coupon obj = _db.Coupons.FirstOrDefault(x=>x.Id==id);
            _db.Coupons.Remove(obj);
            _db.SaveChanges();
            return _responseDto;
        }
    }
}
