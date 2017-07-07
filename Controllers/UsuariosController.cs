using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba1.Models;

namespace Prueba1.Controllers
{
    public class UsuariosController : Controller
    {
        private TestEntities db = new TestEntities();
        
        public async Task<ActionResult> Index()
        {
            return View(await db.Usuarios.ToListAsync());
        }
        
        public ActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdUsuario,Nombre,ApellidoP,ApellidoM,Telefono,Direccion")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuarios);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
