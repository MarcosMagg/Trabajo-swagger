namespace Crud.Domain.Request
{
    public class GetDirectoresRequest
    {
        public int Take { get; set; } = 0;

        public int Skip { get; set; }= 0;
    }
}
