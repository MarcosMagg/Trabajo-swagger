using Crud.Repository;
using Microsoft.AspNetCore.Mvc;
using Crud.Domain.Request;
using Crud.Domain.Response;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Crud.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]

        public class ProductoraController : ControllerBase
        {
            private readonly MARCOS_1Context _1Context
            ;
            public ProductoraController(MARCOS_1Context context)
            {
                _1Context = context;

            }



            [HttpGet]
            public IActionResult GetProductoraNameByName([FromQuery] int id )
            {
                //string Name = request.name;
                //string Id = request.Idd;

                var result = _1Context.Productoras.FirstOrDefault(p => p.IdProductora == id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { Error = $"No se encontro el id: {id}" });

            }
            }

 


        [HttpGet("id")]
        public IActionResult GetProductoraNameByName([FromRoute] GetProductoraRequest request )
        {
            int skip = request.Skip;
            int take = request.Take;

            var result = _1Context.Productoras.Skip(skip).Take(take).ToList();
            var count = _1Context.Productoras.Count();

            var response = new GetProductoraResponse()
            {
                Productoras = result,
                Total = count,
            };

            return Ok(response);
        }


        [HttpGet("cosa")]



    }
}
