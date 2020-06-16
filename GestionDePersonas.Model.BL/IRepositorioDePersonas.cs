using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDePersonas.Model;

namespace GestionDePersonas.BL
{
    public interface IRepositorioDePersonas
    {
       

        List<Persona> ObtenerTodasLasPersonas();


        List<Persona> ObtenerActivas();

        List<Persona> ObtenerInactivas();


        public void Agregar(Persona persona);

        public Persona ObtenerPersonaPorId(int id);

        public void Inactivar(int id);

        public void Actualizar(Persona persona);

        public void Eliminar (int id, string motivo);
    }
}
