using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDePersonas.UI.Models
{
    public class PersonaParaEliminar
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        [Display(Name ="Motivo de eliminación")]
        public string MotivoEliminacion { get; set; }

    }
}
