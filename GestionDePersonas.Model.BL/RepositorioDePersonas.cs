using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionDePersonas.Model;
using GestionDePersonas.DA;

namespace GestionDePersonas.BL
{
    public class RepositorioDePersonas : IRepositorioDePersonas
    {
        private AppDbContext ContextoDeLaApp;

        public RepositorioDePersonas(AppDbContext contexto)
        {
            ContextoDeLaApp = contexto;
        }

        public void Actualizar(Persona persona)
        {
            Persona personaPorActualizar;
            personaPorActualizar = ObtenerPersonaPorId(persona.Id);

            personaPorActualizar.Nombre = persona.Nombre;
            personaPorActualizar.Apellidos = persona.Apellidos;

            ContextoDeLaApp.Personas.Update(personaPorActualizar);
            ContextoDeLaApp.SaveChanges();

        }

        public void Agregar(Persona persona)
        {
            ContextoDeLaApp.Personas.Add(persona);
            ContextoDeLaApp.SaveChanges();
        }

        public void Eliminar(int id, string motivo)
        {
            Persona personaPorEliminar;
            personaPorEliminar = ObtenerPersonaPorId(id);
            
            personaPorEliminar.Estado = Estado.Eliminada;
            personaPorEliminar.MotivoEliminacion = motivo;
            ContextoDeLaApp.Personas.Update(personaPorEliminar);
            ContextoDeLaApp.SaveChanges();

        }

        public void Inactivar(int id)
        {
            Persona persona;
            persona = ObtenerPersonaPorId(id);

            persona.Estado = Estado.InActiva;

            ContextoDeLaApp.Personas.Update(persona);
            ContextoDeLaApp.SaveChanges();
        }

        public List<Persona> ObtenerActivas()
        {

            var resultado = from c in ContextoDeLaApp.Personas
                            where c.Estado == Estado.Activa

                            select c;

            return resultado.ToList();
        }

        public List<Persona> ObtenerInactivas()
        {
            var resultado = from c in ContextoDeLaApp.Personas
                            where c.Estado == Estado.InActiva

                            select c;

            return resultado.ToList();
        }

        public Persona ObtenerPersonaPorId(int id)
        {
            Persona persona;
            persona = ContextoDeLaApp.Personas.Find(id);
            return persona;
        }

        public List<Persona> ObtenerTodasLasPersonas()
        {
            return ContextoDeLaApp.Personas.ToList();
        }
    }
}
