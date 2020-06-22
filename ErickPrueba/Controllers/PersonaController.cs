using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ErickPrueba.Models;
using ErickPrueba.Models.ViewModels;

namespace ErickPrueba.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<ListPersonaViewModel> lst;
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {
               
                lst = (from d in db.Persona
                           select new ListPersonaViewModel
                           {
                               Id = d.ID,
                               Nombre = d.Nombre,
                               FechaDeNacimiento = d.FechaDeNacimiento
                           }).ToList();
            }
                return View(lst);
        }
      
        public ActionResult Nuevo()
        {
            return View();
        }

        //sobre carga de metodos para polimorfismo
        [HttpPost]
        public ActionResult Nuevo(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ERICKPRUEBAEntities db= new ERICKPRUEBAEntities())
                    {
                        var oPersona = new Persona();
                        ///oPersona.ID = model.Id;
                        oPersona.Nombre = model.Nombre;
                        oPersona.FechaDeNacimiento = model.FechaDeNacimiento;

                        db.Persona.Add(oPersona);
                        db.SaveChanges();
                    }
                    return Redirect("~/Persona/");
                }

                return View(model);
                
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public ActionResult Editar(int Id)
        {
            PersonaViewModel model = new PersonaViewModel();
            using (ERICKPRUEBAEntities db=new ERICKPRUEBAEntities())
            {
                var oPersona = db.Persona.Find(Id);
                model.Id = oPersona.ID;
                model.Nombre = oPersona.Nombre;
                model.FechaDeNacimiento = oPersona.FechaDeNacimiento;

            }
             return View(model);
        }
         
        //Editar
        [HttpPost]
        public ActionResult Editar(PersonaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
                    {
                        var oPersona = db.Persona.Find(model.Id);
                        oPersona.Nombre = model.Nombre;
                        oPersona.FechaDeNacimiento = model.FechaDeNacimiento;

                        db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                    return Redirect("~/Persona/");
                }

                return View(model);

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //Eliminar
        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            using (ERICKPRUEBAEntities db = new ERICKPRUEBAEntities())
            {

                var oPersona = db.Persona.Find(Id);
                db.Persona.Remove(oPersona);
                db.SaveChanges();
            }
            return Content("1");
        }

    }
} 