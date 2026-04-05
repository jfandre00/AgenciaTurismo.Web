using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Web.Models;
using System;

namespace AgenciaTurismo.Web.Pages
{
    public class PacoteDetailsModel : PageModel
    {
        public PacoteTuristico Pacote { get; set; }

        // O id virá diretamente da URL
        public IActionResult OnGet(int id)
        {

            if (id <= 0)
            {
                return RedirectToPage("/Index"); 
            }

            Pacote = new PacoteTuristico
            {
                Id = id, 
                Titulo = id == 123 ? "Pacote Especial São Paulo" : "Pacote Padrão",
                CapacidadeMaxima = 15,
                Preco = 5400.00m,
                DataInicio = DateTime.Now.AddMonths(2)
            };

            return Page();
        }
    }
}