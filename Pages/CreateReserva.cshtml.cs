using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Web.Models;

namespace AgenciaTurismo.Web.Pages
{
    public class CreateReservaModel : PageModel
    {
        [BindProperty]
        public Reserva NovaReserva { get; set; }

        public bool CadastradoComSucesso { get; set; } = false;

        public void OnGet() { }

        public IActionResult OnPost()
        {

            ModelState.Remove("NovaReserva.PacoteTuristico");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            CadastradoComSucesso = true;
            return Page();
        }
    }
}