namespace Fatec.Store.Carts.Api.Models.DTOs.GetCartByUserId
{
    public class GetCartByUserIdRequest(int userId)
    {
        public int UserId { get; set; } = userId;
    }
}
