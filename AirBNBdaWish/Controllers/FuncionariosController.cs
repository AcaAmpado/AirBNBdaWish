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

namespace AirBNBdaWish.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public FuncionariosController(ApplicationDbContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            var userAtual = await _userManager.GetUserAsync(User);
            var gestorAt = _context.Gestor.Where(g => g.UtilizadorId == userAtual.Id).FirstOrDefault();
            var applicationDbContext = _context.Funcionario.Include(f => f.Gestor).Include(f => f.Utilizador);
            return View(await applicationDbContext.Where(b=>b.GestorId == gestorAt.Id).ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Gestor)
                .Include(f => f.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            ViewData["GestorId"] = new SelectList(_context.Gestor, "Id", "Id");
            ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GestorId,UtilizadorId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GestorId"] = new SelectList(_context.Gestor, "Id", "Id", funcionario.GestorId);
            ViewData["UtilizadorId"] = new SelectList(_context.Users, "Id", "Id", funcionario.UtilizadorId);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionario
                .Include(f => f.Gestor)
                .Include(f => f.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionario.FindAsync(id);
            List<Imovel> listaImoveis = new List<Imovel>(_context.Imovel.Where(g => g.FuncionarioId == funcionario.Id));
            foreach(Imovel im in listaImoveis){
                List<Reserva> reservas = new List<Reserva>(_context.Reserva.Where(g => g.ImovelId == im.Id));
                foreach(Reserva re in reservas)
                {
                    _context.Reserva.Remove(re);
                }
                _context.Imovel.Remove(im);
            }
            var utilizador = await _context.Users.FindAsync(funcionario.UtilizadorId);
            _context.Users.Remove(utilizador);
            _context.Funcionario.Remove(funcionario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionario.Any(e => e.Id == id);
        }
    }
}
