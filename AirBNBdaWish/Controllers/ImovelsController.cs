﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBNBdaWish.Data;
using AirBNBdaWish.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AirBNBdaWish.Controllers
{
    public class ImovelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Utilizador> _userManager;

        public ImovelsController(ApplicationDbContext context, UserManager<Utilizador> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Imovels
        public async Task<IActionResult> Index()
        {   
            if (User.IsInRole("Gestor")) { 
                var userAtual = await _userManager.GetUserAsync(User);
                var gestorAt = _context.Gestor.Where(g => g.UtilizadorId == userAtual.Id).FirstOrDefault();
                return View(await _context.Imovel.Include(f=>f.Gestor).Include(t=>t.Funcionario).Where(b => b.GestorId == gestorAt.Id).ToListAsync());
            }
            else
                return View(await _context.Imovel.ToListAsync());
        }

        // GET: Imovels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }


        [Authorize(Policy = "PoliticaParaGestores")]
        // GET: Imovels/Create
        public IActionResult Create()
        {
            var userAtual = _userManager.GetUserId(User);
            var gestorAt = _context.Gestor.Where(g => g.UtilizadorId == userAtual).FirstOrDefault();
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario.Include(f=>f.Gestor).Where(t=>t.GestorId == gestorAt.Id), "Id", "Id", _context.Funcionario.Include(f => f.Gestor).Where(t => t.GestorId == gestorAt.Id));
            return View();
        }

        // POST: Imovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FuncionarioId,GestorId,Nome,Descricao,Cidade,Rua,CodigoPostal,Localidade,Porta,Preco,Comodidades")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                var userAtual = await _userManager.GetUserAsync(User);
                var gestorAt = _context.Gestor.Where(g => g.UtilizadorId == userAtual.Id).FirstOrDefault();
                imovel.GestorId = gestorAt.Id;
                _context.Add(imovel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(imovel);
        }

        // GET: Imovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionario, "Id", "Id", _context.Funcionario);
            var imovel = await _context.Imovel.FindAsync(id);
            if (imovel == null)
            {
                return NotFound();
            }
            return View(imovel);
        }

        // POST: Imovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionarioId,GestorId,Nome,Descricao,Cidade,Rua,CodigoPostal,Localidade,Porta,Preco,Comodidades")] Imovel imovel)
        {
            if (id != imovel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userAtual = await _userManager.GetUserAsync(User);
                    var gestorAt = _context.Gestor.Where(g => g.UtilizadorId == userAtual.Id).FirstOrDefault();
                    imovel.GestorId = gestorAt.Id;
                    _context.Update(imovel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.Id))
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
            return View(imovel);
        }

        // GET: Imovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _context.Imovel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imovel = await _context.Imovel.FindAsync(id);
            _context.Imovel.Remove(imovel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _context.Imovel.Any(e => e.Id == id);
        }
    }
}
