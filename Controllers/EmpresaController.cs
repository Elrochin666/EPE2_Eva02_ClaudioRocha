using Microsoft.AspNetCore.Mvc;
using MiapiEpe2.Modelo;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MiapiEpe2.Controllers
{   
    // Ruta de accesos de mi api
    [Route("Empresas")]
    [ApiController]

    public class EmpresaController : ControllerBase

    {   // Declaración de una lista para almacenar objetos de la clase Empresas
        public List<Empresas> empresa = new List<Empresas>{

            // Listado de la empresas creada con valores asigandos 
            new Empresas {NombreCliente = "Claudio", ApePaterno = "Gonzales", ApeMaterno = "Astudillo" , EdadCliente = 30, RutCliente = "12.345.678-9", NombreEmpresa = "TechSolutions S.A", RutEmpresa = "22222222-2", GiroEmpresa = "Tecnología y Soluciones",TotalVentas = 300 ,MontoVentas = 3000000  },
            new Empresas {NombreCliente = "Rey", ApePaterno = "Marques",ApeMaterno = "López" , EdadCliente = 29, RutCliente = "23.456.789-0", NombreEmpresa = "GreenEco Ltda", RutEmpresa = "88888888-8", GiroEmpresa = "Ecología y Medio Ambiente",TotalVentas = 300,MontoVentas = 5000000},
            new Empresas {NombreCliente = "Carlos", ApePaterno = "Mendez",ApeMaterno = "Fernández" , EdadCliente = 25, RutCliente = "34.567.890-1", NombreEmpresa = "Global Innovations Corp", RutEmpresa = "77777777-7", GiroEmpresa = "Innovaciones Globales",TotalVentas = 7000000,MontoVentas = 475000},
            new Empresas {NombreCliente = "Juan", ApePaterno = "Osorio", ApeMaterno = "Ramírez" ,EdadCliente = 37, RutCliente = "45.678.901-2", NombreEmpresa = "Swift Logistics Group", RutEmpresa = "66666666-6", GiroEmpresa = "Logística Rápida",TotalVentas = 250,MontoVentas = 2500000, MontoUtilidades = 3645000},
            new Empresas {NombreCliente = "Marter", ApePaterno = "Fujimori",ApeMaterno = "López" , EdadCliente = 24, RutCliente = "56.789.012-3", NombreEmpresa = "Golden Harvest Enterprises", RutEmpresa = "55555555-5", GiroEmpresa = "Empresas de Cosecha Dorada",TotalVentas = 450,MontoVentas = 4500000},

        };
        //Indica que este método responderá a las solicitudes HTTP GET en la ruta "/empresa".
        [HttpGet("empresa")]
        public IActionResult GetAllEmpresas()
        {
            return Ok(empresa);
        }

        [HttpGet("tres-empresas")]
        public IActionResult GetTresEmpresas()
        {
            // Selecciona tres empresas diferentes de la lista
            var tresEmpresas = empresa.Take(3).ToList();
            return Ok(tresEmpresas);
        }

        // Método GET para obtener todos los datos de una empresa en particular mediante su Rut
        [HttpGet("empresa/{RutEmpresa}")]
        public IActionResult GetEmpresaByRut(string RutEmpresa)
        {
            var emp = empresa.FirstOrDefault(e => e.RutEmpresa == RutEmpresa);
            if (emp == null)
            {
                StatusCode(200, empresa);
            }
            return StatusCode(404);
        }

        //Método POST para crear y guardar una nueva empresa
        [HttpPost]
        public IActionResult CrearEmpresa([FromBody] Empresas nuevaEmpresa)
        {
            if (nuevaEmpresa == null)
            {
                return BadRequest();
            }

            empresa.Add(nuevaEmpresa);
            return CreatedAtAction("GetEmpresa", new { nombreEmpresa = nuevaEmpresa.NombreEmpresa }, nuevaEmpresa);
        }

        //Método PUT para editar y guardar cambios a una empresa seleccionada
        [HttpPut("{nombreEmpresa}")]
        public IActionResult EditarEmpresa(string nombreEmpresa, [FromBody] Empresas empresaActualizada)
        {
            if (empresaActualizada == null)
            {
                return BadRequest();
            }

            Empresas empresaExistente = empresa.FirstOrDefault(e => e.NombreEmpresa == nombreEmpresa);

            if (empresaExistente == null)
            {
                return StatusCode(404);
            }

            // Actualiza los datos de la empresa con los nuevos valores
            empresaExistente.NombreCliente = empresaActualizada.NombreCliente;
            empresaExistente.ApePaterno = empresaActualizada.ApePaterno;
            empresaExistente.ApeMaterno = empresaActualizada.ApeMaterno;
            empresaExistente.EdadCliente = empresaActualizada.EdadCliente;
            empresaExistente.RutCliente = empresaActualizada.RutCliente;
            empresaExistente.RutEmpresa = empresaActualizada.RutEmpresa;
            empresaExistente.GiroEmpresa = empresaActualizada.GiroEmpresa;
            empresaExistente.TotalVentas = empresaActualizada.TotalVentas;
            empresaExistente.MontoVentas = empresaActualizada.MontoVentas;
            empresaExistente.MontoIVAaPagar = empresaActualizada.MontoIVAaPagar;
            empresaExistente.MontoUtilidades = empresaActualizada.MontoUtilidades;

            return Ok(empresaExistente);
        }

        //Método DELETE para eliminar la empresa
        [HttpDelete("empresas /{rutEmpresa}")]
        

        public IActionResult DeleteEmpresa(string RutEmpresa)
        {
            var emp = empresa.FirstOrDefault(e => e.RutEmpresa == RutEmpresa);
            if (emp == null)
            {
                return NotFound();
            }
            empresa.Remove(emp);

            return NoContent();
        }


        //metodo para calcular Iva
        [HttpPost("calcular-iva")]
        public IActionResult CalcularIva([FromBody] Empresas empresas)
        {
            float montoIva = (float)(empresas.MontoVentas * 0.19); // Suponiendo una tasa de IVA del 19%.
            empresas.MontoIVAaPagar = montoIva;
            return Ok(empresas);
        }
        //metodo para calcular utilidades de la empresa
        [HttpPost("calcular-utilidades")]
        public IActionResult CalcularUtilidades([FromBody] Empresas empresa)
        {
            float montoIva = empresa.MontoVentas * 0.19f; // Suponiendo una tasa de IVA del 19%.
            float montoUtilidades = empresa.MontoVentas - montoIva;
            empresa.MontoUtilidades = montoUtilidades;
            return Ok(empresa);
        }








    }

}

