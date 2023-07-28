using Microsoft.AspNetCore.Mvc;

namespace Taller_Controlador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CourseController : Controller
    {
        
            [HttpGet]
            public string Get()
            {
                return "Este es el controlador de cursos";
            }
        
    }
}
