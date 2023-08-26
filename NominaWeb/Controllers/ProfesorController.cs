using Microsoft.AspNetCore.Mvc;
using NominaWeb.Data;
using NominaWeb.Models;

namespace NominaWeb.Controllers
{
    public class ProfesorController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProfesorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Profesor> objProfesorList = _db.Profesores;
            return View(objProfesorList);
        }

        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Profesor obj)
        {
            if (ModelState.IsValid)
            {
                obj.MontoGanado = obj.PrecioHora * obj.CantidadHoras;
                if(obj.MontoGanado >= 15000){
                    obj.Incentivos = obj.MontoGanado * 0.15;
                }
                else
                {
                    obj.Incentivos = obj.MontoGanado * 0.05;
                }
                obj.TotalGanado = obj.MontoGanado + obj.Incentivos;

                if (obj.TotalGanado <= 10000) 
                { 
                    obj.ISR = 0; 
                }
                else if (obj.TotalGanado > 10000 && obj.TotalGanado <= 15000) 
                { 
                    obj.ISR = 0.004; 
                }
                else if (obj.TotalGanado > 15000)
                { 
                    obj.ISR = 0.015;
                }

                obj.ISR *= obj.TotalGanado;

                _db.Profesores.Add(obj);
                _db.SaveChanges();

                if (obj.Id == 1 || obj.Id == 2 || obj.Id == 7)
                {
                    obj.Avances = 5000;
                }

                obj.TotalDeducciones = obj.ISR + obj.Avances;
                obj.TotalRecibir = obj.TotalGanado - obj.TotalDeducciones;

                _db.Profesores.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var profesorFromDb = _db.Profesores.Find(id);

            if (profesorFromDb == null)
            {
                return NotFound();
            }

            return View(profesorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Profesor obj)
        {
            if (ModelState.IsValid)
            {
                obj.MontoGanado = obj.PrecioHora * obj.CantidadHoras;
                if (obj.MontoGanado >= 15000)
                {
                    obj.Incentivos = obj.MontoGanado * 0.15;
                }
                else
                {
                    obj.Incentivos = obj.MontoGanado * 0.05;
                }
                obj.TotalGanado = obj.MontoGanado + obj.Incentivos;

                if (obj.TotalGanado <= 10000)
                {
                    obj.ISR = 0;
                }
                else if (obj.TotalGanado > 10000 && obj.TotalGanado <= 15000)
                {
                    obj.ISR = 0.004;
                }
                else if (obj.TotalGanado > 15000)
                {
                    obj.ISR = 0.015;
                }

                obj.ISR *= obj.TotalGanado;

                if (obj.Id == 1 || obj.Id == 2 || obj.Id == 7)
                {
                    obj.Avances = 5000;
                }
                obj.TotalDeducciones = obj.ISR + obj.Avances;
                obj.TotalRecibir = obj.TotalGanado - obj.TotalDeducciones;
                _db.Profesores.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var profesorFromDb = _db.Profesores.Find(id);

            if (profesorFromDb == null)
            {
                return NotFound();
            }

            return View(profesorFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Profesores.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Profesores.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
