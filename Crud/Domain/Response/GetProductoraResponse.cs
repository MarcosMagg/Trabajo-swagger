using Crud.Domain.Entities;

namespace Crud.Domain.Response
{
    public class GetProductoraResponse
    {
        public List<Productora> Productoras { get; set; }
        public int Total { get; set; }
    }

}
