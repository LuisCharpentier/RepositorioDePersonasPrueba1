using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionDePersonas.UI.Models;
using GestionDePersonas.DA;
using GestionDePersonas.Model;
using GestionDePersonas.BL;

namespace GestionDePersonas.UI.Controllers
{
    public class PersonaActivaController : Controller
    {

        private readonly IRepositorioDePersonas RepositorioDePersonas;

        public PersonaActivaController(IRepositorioDePersonas repositorioDePersona)
        {
            RepositorioDePersonas = repositorioDePersona;
        }


        public ViewResult Listar()
        {
            List<Persona> laLista;
            laLista = RepositorioDePersonas.ObtenerActivas();
            return View(laLista);
        }



        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            Persona persona;
            persona = RepositorioDePersonas.ObtenerPersonaPorId(id);
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    persona.Estado = Estado.Activa;
                    RepositorioDePersonas.Agregar(persona);

                    return RedirectToAction(nameof(Listar));
                }
                else
                {
                    return View();
                }

          
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            Persona persona;
            persona = RepositorioDePersonas.ObtenerPersonaPorId(id);
            return View(persona);
        }

        // POST: Default/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            try
            {

               
              RepositorioDePersonas.Actualizar(persona);

           
                return RedirectToAction(nameof(Listar));
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Inactivar(int id)
        {
           RepositorioDePersonas.Inactivar(id);

            return RedirectToAction(nameof(Listar));


        }

    }
}