using Crud.Domain.Request;
using Crud.Domain.Response;
using Crud.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//=>api/Director
    public class DirectorController : ControllerBase
    {
        private readonly MARCOS_1Context _context;

        public DirectorController(MARCOS_1Context context)
        {
            _context = context;
        }




        [HttpGet]
        public IActionResult GetDirectores([FromQuery] GetDirectoresRequest request)
        {
            int skip = request.Skip;
            int take = request.Take;

            //A ESTO SE LE LLAMA PAGINADO, DEVUELVE UNA CIERTA CANTIDAD DE DATOS
            var result = _context.Directores.Skip(skip).Take(take).ToList();//EL SKIP ES PARA SALTAR, ATRAVES DEL ENTRERO skip le paso cuanto y el TAKE es lo mismo pero toma
            int count = _context.Directores.Count();//ESTE COUNTO MOSTRARIA LA CANTIDAD, ES UN CONTADOR



            //ESTO DEVUELVE TODO EN FORMA DE LISTA
            /*
            var result = _context.Directores.ToList();
            return Ok (result);
            */
            var response = new GetDirectoresResponse()//asi lo devolvemos como objeto declarado
            {
                Directores = result,
                Total = count,
            };

            return Ok(response);
            //return Ok(new {Datos = result, Count = count});//De esta forma se devuelve como anonimo
        }



        
        [HttpGet("{id}")]
        public IActionResult GetDirectorById([FromRoute] int id)//
        {
            //var result = _context.Directores.Where(w => w.IdDirector == id).ToList();//asi devolveria una lista de los que coinciden con el id
           // var result = _context.Directores.Where(w => w.IdDirector == id).FirstOrDefault();//devuelve el primero
            var result = _context.Directores.FirstOrDefault(f => f.IdDirector   ==id);//otra forma de hacerlo


            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(new { Error = $"No se encontro el id: {id}" });

            }
        }
        



        
        [HttpGet("peliculas")]//api/Director/Pelicula
        public IActionResult GetPeliculasByDirector([FromQuery] int idDirector)
        {
            var result = _context.Directores.Where(w => w.IdDirector == idDirector)//CRWA UNA AGRUPACION LOGICA CREANDO UN NUEVO ID
                                            .Include(i => i.Peliculas)//CON ESTO MOSTRAMOS EL DIRECTOR Y SU PELICULA
                                            .ToList();

            return Ok(result);

        }
        





        





    }
}
