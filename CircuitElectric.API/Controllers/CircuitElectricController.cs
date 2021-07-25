using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CircuitElectric.API.Model;

namespace CircuitElectric.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CircuitController : ControllerBase
    {

        private static readonly List<EletronicCircuit> circuits = new();

        public void AddCircuit(EletronicCircuit circuit)
        {
            circuits.Add(circuit);
            Console.WriteLine(circuit.Description);
        }

    }
}