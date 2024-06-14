﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiObligatorioP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametrosController : ControllerBase
    {
        /*
         -https://localhost:7048/api/Articulo/Listado GET
         -https://localhost:7048/api/TipoMovimiento GET
         -https://localhost:7048/api/Parametros?id=2 GET
         -https://localhost:7048/api/Movimiento/ POST
         */


        // GET: api/<ParametrosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ParametrosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParametrosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParametrosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParametrosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
