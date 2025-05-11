using AutoMapper;
using Fatec.Store.Discount.Api.DTOs;
using Fatec.Store.Discount.Api.Models;
using Fatec.Store.Discount.Api.Repositories;

namespace Fatec.Store.Discount.Api.Services
{
    public class CouponService : ICouponService
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IUserCouponRepository _userCouponRepository;
        private readonly IMapper _mapper;

        public CouponService(ICouponRepository couponRepository, IUserCouponRepository userCouponRepository, IMapper mapper)
        {
            _userCouponRepository = userCouponRepository;
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CouponReponseDTO>> GetAllCoupons()
        {
            var coupons = await _couponRepository.GetAllCouponsAsync();

            return _mapper.Map<IEnumerable<CouponReponseDTO>>(coupons);
        }

        public async Task<CouponReponseDTO> GetCoupon(string couponCode)
        {
            var coupon = await _couponRepository.GetCouponByCodeAsync(couponCode);

            return _mapper.Map<CouponReponseDTO>(coupon);
        }

        public async Task<CouponReponseDTO> CreateCoupon(CouponRequestDTO couponRequestDTO)
        {
            var newCoupon = _mapper.Map<Coupon>(couponRequestDTO);

            if (newCoupon is null) throw new Exception("Invalid coupon");

            await _couponRepository.CreateCouponAsync(newCoupon);

            return _mapper.Map<CouponReponseDTO>(newCoupon);
        }

        public async Task<CouponReponseDTO> UseCoupon(CouponRequestPatchDTO couponCode)
        {
            var couponEntity = await _couponRepository.GetCouponByCodeAsync(couponCode.CouponCode) ?? throw new Exception("CoupounNotFound");

            if (couponEntity.Active == false) throw new Exception("CouponInactive");
            
            await ApplyCouponAsync(couponCode.userId, couponCode.CouponCode);

            couponEntity.Quantity--;

            if (couponEntity.Quantity == 0) await _couponRepository.ActiveOrInactiveCoupon(couponEntity.CouponCode);

            await _couponRepository.UpdateCouponAsync(couponEntity);

            return _mapper.Map<CouponReponseDTO>(couponEntity);
        }
        public async Task<bool> ApplyCouponAsync(string userId, string couponCode)
        {
            if (await _userCouponRepository.HasUserUsedCouponAsync(userId, couponCode))
                throw new Exception("AlreadyUsed");

            var userCoupon = new UserCoupon
            {
                UserID = userId,
                CouponCode = couponCode,
                UsedAt = DateTime.UtcNow,
            };

            await _userCouponRepository.AddUserCouponAsync(userCoupon);

            return true;
        }

        public async Task<CouponReponseDTO> ActiveOrInactiveCoupon(string couponCode)
        {
            var coupon = await GetCoupon(couponCode);
            
            await _couponRepository.ActiveOrInactiveCoupon(coupon.CouponCode);

            var updatedCoupon = await GetCoupon(couponCode);

            return _mapper.Map<CouponReponseDTO>(updatedCoupon);
        }
    }
}
