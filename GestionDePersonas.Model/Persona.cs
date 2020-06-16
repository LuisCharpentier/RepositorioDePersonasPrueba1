using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [MaxLength(20)]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellidos es requerido")]
        public string  Apellidos { get; set; }

        public Estado Estado { get; set; }

        public string? MotivoEliminacion { get; set; }


    }
}
