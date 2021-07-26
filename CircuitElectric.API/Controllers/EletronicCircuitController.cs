using System;
using System.Collections.Generic;
using System.Linq;
using CircuitElectric.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace CircuitElectric.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CircuitController : ControllerBase
    {

        private static readonly List<EletronicCircuit> circuits = new();
        private static long id = 1;

        [HttpPost]
        public IActionResult AddCircuit([FromBody] EletronicCircuit circuit)
        {
            circuit.Id += 1;
            circuits.Add(circuit);
            Console.WriteLine(circuit.Description);
            return CreatedAtAction(nameof(GetCircuitById), new { Id = circuit.Id }, circuit);
        }

        [HttpGet]
        public IActionResult GetAllCircuit()
        {
            return Ok(circuits);
        }


        [HttpGet("{id}")]
        public IActionResult GetCircuitById(long id)
        {
            var item = circuits.FirstOrDefault(circuit => circuit.Id == id);
            if (item != null)
                return Ok(item);

            return NotFound();
        }

    }
}