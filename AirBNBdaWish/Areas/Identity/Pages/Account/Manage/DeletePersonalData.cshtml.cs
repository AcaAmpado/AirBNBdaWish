using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AirBNBdaWish.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using AirBNBdaWish.Data;
using System.Collections.Generic;
using System.Linq;

namespace AirBNBdaWish.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<Utilizador> _userManager;
        private readonly SignInManager<Utilizador> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly ApplicationDbContext _context;

        public DeletePersonalDataModel(
            UserManager<Utilizador> userManager,
            SignInManager<Utilizador> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            if (User.IsInRole("Funcionario"))
            {
                var funcionario = _context.Funcionario.Where(g => g.UtilizadorId == user.Id).FirstOrDefault();
                List<Imovel> listaImoveis = new List<Imovel>(_context.Imovel.Where(g => g.FuncionarioId == funcionario.Id));
                foreach (Imovel im in listaImoveis)
                {
                    List<Reserva> reservas = new List<Reserva>(_context.Reserva.Where(g => g.ImovelId == im.Id));
                    foreach (Reserva re in reservas)
                    {
                        _context.Reserva.Remove(re);
                    }
                    _context.Imovel.Remove(im);
                }
                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            var result = await _userManager.DeleteAsync(user);
            
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}
