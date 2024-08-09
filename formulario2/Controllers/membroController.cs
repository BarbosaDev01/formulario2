using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using formulario2.Data;
using formulario2.Models;

namespace formulario2.Controllers
{
    public class membroController : Controller
    {
        private readonly formulario2Context _context;

        public membroController(formulario2Context context)
        {
            _context = context;
        }

        // GET: membro
        public async Task<IActionResult> Index()
        {
            return View(await _context.membro.ToListAsync());
        }

        // GET: membro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.membro
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // GET: membro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: membro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Codigo,Nome,UltimoNome,Endereco,Endereco2,Cidade,Est,Postal")] membro membro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membro);
        }

        // GET: membro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.membro.FindAsync(id);
            if (membro == null)
            {
                return NotFound();
            }
            return View(membro);
        }

        // POST: membro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Codigo,Nome,UltimoNome,Endereco,Endereco2,Cidade,Est,Postal")] membro membro)
        {
            if (id != membro.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!membroExists(membro.Codigo))
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
            return View(membro);
        }

        // GET: membro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membro = await _context.membro
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (membro == null)
            {
                return NotFound();
            }

            return View(membro);
        }

        // POST: membro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var membro = await _context.membro.FindAsync(id);
            if (membro != null)
            {
                _context.membro.Remove(membro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool membroExists(int id)
        {
            return _context.membro.Any(e => e.Codigo == id);
        }
    }
}
