using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AgenciaTurismo.Web.Models;

namespace AgenciaTurismo.Web.Pages
{
    public class CreatePacoteTuristicoModel : PageModel
    {
        [BindProperty]
        public PacoteTuristico Pacote { get; set; }

        public bool CadastradoComSucesso { get; set; } = false;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Se a validação falhar, devolve a página com os erros
            }

            CadastradoComSucesso = true; // Simula que salvou no banco
            return Page();
        }
    }
}