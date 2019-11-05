using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Senai.LanHouse.Web.Razor.Contexts;
using Senai.LanHouse.Web.Razor.Models;

namespace Senai.LanHouse.Web.Razor.Controllers
{
    public class RegistrosDefeitosController : Controller
    {
        private readonly LanHouseContext _context;

        public RegistrosDefeitosController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: RegistrosDefeitos
        public async Task<IActionResult> Index()
        {
            var lanHouseContext = _context.RegistrosDefeitos.Include(r => r.IdDefeitoNavigation).Include(r => r.IdEquipamentoNavigation);
            return View(await lanHouseContext.ToListAsync());
        }

        // GET: RegistrosDefeitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrosDefeitos = await _context.RegistrosDefeitos
                .Include(r => r.IdDefeitoNavigation)
                .Include(r => r.IdEquipamentoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrosDefeitos == null)
            {
                return NotFound();
            }

            return View(registrosDefeitos);
        }

        // GET: RegistrosDefeitos/Create
        public IActionResult Create()
        {
            ViewData["IdDefeito"] = new SelectList(_context.TiposDefeito, "Id", "Nome");
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "Id", "Nome");
            return View();
        }

        // POST: RegistrosDefeitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataDefeito,IdEquipamento,IdDefeito,Observacao")] RegistrosDefeitos registrosDefeitos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registrosDefeitos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDefeito"] = new SelectList(_context.TiposDefeito, "Id", "Nome", registrosDefeitos.IdDefeito);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "Id", "Nome", registrosDefeitos.IdEquipamento);
            return View(registrosDefeitos);
        }

        // GET: RegistrosDefeitos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrosDefeitos = await _context.RegistrosDefeitos.FindAsync(id);
            if (registrosDefeitos == null)
            {
                return NotFound();
            }
            ViewData["IdDefeito"] = new SelectList(_context.TiposDefeito, "Id", "Nome", registrosDefeitos.IdDefeito);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "Id", "Nome", registrosDefeitos.IdEquipamento);
            return View(registrosDefeitos);
        }

        // POST: RegistrosDefeitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataDefeito,IdEquipamento,IdDefeito,Observacao")] RegistrosDefeitos registrosDefeitos)
        {
            if (id != registrosDefeitos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registrosDefeitos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrosDefeitosExists(registrosDefeitos.Id))
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
            ViewData["IdDefeito"] = new SelectList(_context.TiposDefeito, "Id", "Nome", registrosDefeitos.IdDefeito);
            ViewData["IdEquipamento"] = new SelectList(_context.Equipamentos, "Id", "Nome", registrosDefeitos.IdEquipamento);
            return View(registrosDefeitos);
        }

        // GET: RegistrosDefeitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrosDefeitos = await _context.RegistrosDefeitos
                .Include(r => r.IdDefeitoNavigation)
                .Include(r => r.IdEquipamentoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registrosDefeitos == null)
            {
                return NotFound();
            }

            return View(registrosDefeitos);
        }

        // POST: RegistrosDefeitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registrosDefeitos = await _context.RegistrosDefeitos.FindAsync(id);
            _context.RegistrosDefeitos.Remove(registrosDefeitos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrosDefeitosExists(int id)
        {
            return _context.RegistrosDefeitos.Any(e => e.Id == id);
        }
    }
}
