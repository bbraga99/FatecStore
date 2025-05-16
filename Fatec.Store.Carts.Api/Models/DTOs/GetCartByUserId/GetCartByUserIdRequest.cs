namespace Fatec.Store.Carts.Api.Models.DTO.GetCartByUserId
{
    public class GetCartByUserIdRequest(int userId)
    {
        public int UserId { get; set; } = userId;
    }
}
