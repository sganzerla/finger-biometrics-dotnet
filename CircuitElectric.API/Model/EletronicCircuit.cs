using System;
using System.ComponentModel.DataAnnotations;

namespace CircuitElectric.API.Model
{
    public class EletronicCircuit
    {

        public long Id { get;   set; }

        public float Tension { get; set; }

        public float Current { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "Resistance has > 0.0")]
        public float Resistance { get; set; }

        public float Power { get; set; }

        [Required]
        public string Description { get; set; }

        
        
    }
}