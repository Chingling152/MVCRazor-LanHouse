using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Contexts;
using Senai.LanHouse.Web.Razor.Models;

namespace Senai.LanHouse.Web.Razor.Controllers
{
    public class TiposDefeitosController : Controller
    {
        private readonly LanHouseContext _context;

        public TiposDefeitosController(LanHouseContext context)
        {
            _context = context;
        }

        #region Listagem de defeitos
        // GET: TiposDefeitos
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDefeito.ToListAsync());
        }

        // GET: TiposDefeitos/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDefeito = await _context.TiposDefeito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDefeito == null)
            {
                return NotFound();
            }

            return View(tiposDefeito);
        }
        #endregion

        #region Cadastro de defeitos
        // GET: TiposDefeitos/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposDefeitos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TiposDefeito tiposDefeito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposDefeito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposDefeito);
        }
        #endregion

        #region Edição de defeitos 
        // GET: TiposDefeitos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDefeito = await _context.TiposDefeito.FindAsync(id);
            if (tiposDefeito == null)
            {
                return NotFound();
            }
            return View(tiposDefeito);
        }
        // POST: TiposDefeitos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TiposDefeito tiposDefeito)
        {
            if (id != tiposDefeito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposDefeito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposDefeitoExists(tiposDefeito.Id))
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
            return View(tiposDefeito);
        }
        #endregion

        #region Remoção de defeitos
        // GET: TiposDefeitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposDefeito = await _context.TiposDefeito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tiposDefeito == null)
            {
                return NotFound();
            }

            return View(tiposDefeito);
        }

        // POST: TiposDefeitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposDefeito = await _context.TiposDefeito.FindAsync(id);
            _context.TiposDefeito.Remove(tiposDefeito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposDefeitoExists(int id)
        {
            return _context.TiposDefeito.Any(e => e.Id == id);
        }
        #endregion
    }
}
