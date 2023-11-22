using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dadadanet.Models;

namespace dadadanet.Controllers
{
    [ApiController]
    [Route("/Bilders")]
    public class BildersControllers : Controller
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            var db = new GavmeawContext();
            return Ok(db.Bilders);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var db = new GavmeawContext();
            var Bilder = db.Bilders.SingleOrDefault(s => s.Id == id);
            if (Bilder == null)
                return NotFound();
            return Ok(Bilder);
        }
        [HttpPost]
        public IActionResult Add(Bilder Bilder)
        {
            var db = new GavmeawContext();
            db.Bilders.Add(Bilder);
            db.SaveChanges();
            return Ok(Bilder);
        }
        [HttpPut]
        public IActionResult Edit(Bilder Bilders)
        {
            var db = new GavmeawContext();
            db.Bilders.Update(Bilders);
            db.SaveChanges();
            return Ok(Bilders);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new GavmeawContext();
            var Bilder = db.Bilders.SingleOrDefault(s => s.Id == id);
            if (Bilder == null)
                return NotFound();
            db.Bilders.Remove(Bilder);
            db.SaveChanges();
            return Ok(Bilder);
        }
    }
}