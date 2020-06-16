using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionDePersonas.UI.Models;
using GestionDePersonas.BL;
using GestionDePersonas.Model;


namespace GestionDePersonas.UI.Controllers
{
    public class PersonaInactivaController : Controller
    {

        private readonly IRepositorioDePersonas RepositorioDePersonas;

        public PersonaInactivaController(IRepositorioDePersonas repositorioDePersona)
        {
            RepositorioDePersonas = repositorioDePersona;
        }


        // GET: PersonaInactiva
        public ActionResult Listar()
        {
            List<Persona> laLista;
            laLista = RepositorioDePersonas.ObtenerInactivas();
            return View(laLista);
        }

        // GET: PersonaInactiva/Delete/5
        public ActionResult Delete(int id)
        {
            PersonaParaEliminar persona = new PersonaParaEliminar();
            persona.Id = id;

            return View(persona);
        }

        // POST: PersonaInactiva/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PersonaParaEliminar persona)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    RepositorioDePersonas.Eliminar(persona.Id, persona.MotivoEliminacion);
                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                } 
            
            }
            catch
            {
                return View();
            }
        }
    }
}