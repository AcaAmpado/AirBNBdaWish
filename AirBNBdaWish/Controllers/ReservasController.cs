using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBNBdaWish.Data;
using AirBNBdaWish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace AirBNBdaWish.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public ReservasController(ApplicationDbContext context, UserManager<Utilizador>  userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Cliente"))
            {
                var userAtual = _userManager.GetUserId(User);
                var clienteAt = _context.Cliente.Where(g => g.UtilizadorId == userAtual).FirstOrDefault();
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Imovel).Where(p=>p.ClienteId == clienteAt.Id);
                return View(await applicationDbContext.ToListAsync());
            }
            else if (User.IsInRole("Funcionario"))
            {
                var userAtual = _userManager.GetUserId(User);
                var funcionarioAt = _context.Funcionario.Where(g => g.UtilizadorId == userAtual).FirstOrDefault();
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Imovel).Where(p=>p.ClienteId == funcionarioAt.Id);
                return View(await applicationDbContext.ToListAsync());
            }
            else
            {
                var applicationDbContext = _context.Reserva.Include(r => r.Cliente).Include(r => r.Imovel);
                return View(await applicationDbContext.ToListAsync());
            }
        }

        // GET: Reservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        [Authorize(Policy = "PoliticaParaClientes")]
        // GET: Reservas/Create
        public IActionResult Create(int id)
        {
            if (id == 0)
                return View();
            var userAtual = _userManager.GetUserId(User);
            var clienteAt = _context.Cliente.Where(g => g.UtilizadorId == userAtual).FirstOrDefault();
            ViewData["ImovelId"] = id;
            ViewData["ClienteId"] = clienteAt.Id;
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImovelId,ClienteId,DataInicio,DataFim")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {   
                var userAtual = _userManager.GetUserId(User);
                var clienteAt = _context.Cliente.Where(g => g.UtilizadorId == userAtual).FirstOrDefault();
                reserva.ClienteId = clienteAt.Id;
                /*Imovel imovel = _context.Imovel.Where(p => p.Id == reserva.ImovelId).FirstOrDefault();
                int id = imovel.Id;
                reserva.ImovelId = id;*/
                if (reserva.DataInicio > reserva.DataFim)
                    return RedirectToAction(nameof(Create));
                _context.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", reserva.ClienteId);
            ViewData["ImovelId"] = new SelectList(_context.Imovel, "Id", "Id", reserva.ImovelId);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        [Authorize(Policy = "PoliticaParaFuncionarios")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", reserva.ClienteId);
            ViewData["ImovelId"] = new SelectList(_context.Imovel, "Id", "Id", reserva.ImovelId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImovelId,ClienteId,DataInicio,DataFim")] Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Id", reserva.ClienteId);
            ViewData["ImovelId"] = new SelectList(_context.Imovel, "Id", "Id", reserva.ImovelId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        [Authorize(Policy = "PoliticaParaFuncionarios")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .Include(r => r.Imovel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}
