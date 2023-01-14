using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EcommerceSite.Data;
using EcommerceSite.Models;

namespace EcommerceSite.Controllers
{
    public class LignePaniersController : Controller
    {
        private readonly EcommerceSiteContext _context;

        public LignePaniersController(EcommerceSiteContext context)
        {
            _context = context;
        }

        // GET: LignePaniers
        public async Task<IActionResult> Index()
        {
            var ecommerceSiteContext = _context.LignePanier.Include(l => l.Panier).Include(l => l.Product);
            return View(await ecommerceSiteContext.ToListAsync());
        }

        // GET: LignePaniers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LignePanier == null)
            {
                return NotFound();
            }

            var lignePanier = await _context.LignePanier
                .Include(l => l.Panier)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lignePanier == null)
            {
                return NotFound();
            }

            return View(lignePanier);
        }

        // GET: LignePaniers/Create
        public IActionResult Create()
        {
            ViewData["PanierId"] = new SelectList(_context.Panier, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id");
            return View();
        }

        // POST: LignePaniers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,quantite,ProductId,PanierId")] LignePanier lignePanier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lignePanier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PanierId"] = new SelectList(_context.Panier, "Id", "Id", lignePanier.PanierId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignePanier.ProductId);
            return View(lignePanier);
        }

        // GET: LignePaniers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LignePanier == null)
            {
                return NotFound();
            }

            var lignePanier = await _context.LignePanier.FindAsync(id);
            if (lignePanier == null)
            {
                return NotFound();
            }
            ViewData["PanierId"] = new SelectList(_context.Panier, "Id", "Id", lignePanier.PanierId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignePanier.ProductId);
            return View(lignePanier);
        }

        // POST: LignePaniers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,quantite,ProductId,PanierId")] LignePanier lignePanier)
        {
            if (id != lignePanier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lignePanier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LignePanierExists(lignePanier.Id))
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
            ViewData["PanierId"] = new SelectList(_context.Panier, "Id", "Id", lignePanier.PanierId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "Id", lignePanier.ProductId);
            return View(lignePanier);
        }

        // GET: LignePaniers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LignePanier == null)
            {
                return NotFound();
            }

            var lignePanier = await _context.LignePanier
                .Include(l => l.Panier)
                .Include(l => l.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lignePanier == null)
            {
                return NotFound();
            }

            return View(lignePanier);
        }

        // POST: LignePaniers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LignePanier == null)
            {
                return Problem("Entity set 'EcommerceSiteContext.LignePanier'  is null.");
            }
            var lignePanier = await _context.LignePanier.FindAsync(id);
            if (lignePanier != null)
            {
                _context.LignePanier.Remove(lignePanier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LignePanierExists(int id)
        {
          return (_context.LignePanier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
