using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopEasyCRM.Models;

namespace ShopEasyCRM.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ShopEasyContext _context;

        public PersonasController(ShopEasyContext context)
        {
            _context = context;
        }

        // GET: Personas
        public async Task<IActionResult> Index()
        {
            var shopEasyContext = _context.Personas.Include(p => p.Provincia).Include(p => p.Rol);
            return View(await shopEasyContext.ToListAsync());
        }

        // GET: Personas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Provincia)
                .Include(p => p.Rol)
                .FirstOrDefaultAsync(m => m.NumeroCedula == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "IdProvincia", "IdProvincia");
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroCedula,Nombre,Apellido1,Apellido2,Email,Telefono,Direccion,ProvinciaId,FechaNacimiento,RolId,Estado")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "IdProvincia", "IdProvincia", persona.ProvinciaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "IdRol", persona.RolId);
            return View(persona);
        }

        // GET: Personas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "IdProvincia", "IdProvincia", persona.ProvinciaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "IdRol", persona.RolId);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NumeroCedula,Nombre,Apellido1,Apellido2,Email,Telefono,Direccion,ProvinciaId,FechaNacimiento,RolId,Estado")] Persona persona)
        {
            if (id != persona.NumeroCedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.NumeroCedula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProvinciaId"] = new SelectList(_context.Provincias, "IdProvincia", "IdProvincia", persona.ProvinciaId);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "IdRol", persona.RolId);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.Provincia)
                .Include(p => p.Rol)
                .FirstOrDefaultAsync(m => m.NumeroCedula == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(string id)
        {
            return _context.Personas.Any(e => e.NumeroCedula == id);
        }
    }
}
