namespace Fatec.Store.Carts.Api.Models.GetCartByUserId
{
    public class GetCartByUserIdRequest(int userId)
    {
        public int UserId { get; set; } = userId;
    }
}
