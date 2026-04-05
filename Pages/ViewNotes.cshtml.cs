using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AgenciaTurismo.Web.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        [BindProperty]
        public string TituloNota { get; set; }

        [BindProperty]
        public string ConteudoNota { get; set; }

        public List<string> ArquivosDisponiveis { get; set; } = new List<string>();
        public string NotaSelecionadaNome { get; set; }
        public string NotaSelecionadaConteudo { get; set; }

        public void OnGet(string lerArquivo)
        {
            PrepararPastaEListarArquivos();

            if (!string.IsNullOrEmpty(lerArquivo))
            {
                LerConteudoArquivoSeguro(lerArquivo);
            }
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(TituloNota) && !string.IsNullOrWhiteSpace(ConteudoNota))
            {
                var pastaDestino = Path.Combine(_env.WebRootPath, "files");
                Directory.CreateDirectory(pastaDestino);

                var nomeSeguro = Path.GetFileNameWithoutExtension(TituloNota) + ".txt";
                var caminhoCompleto = Path.Combine(pastaDestino, nomeSeguro);


                System.IO.File.WriteAllText(caminhoCompleto, ConteudoNota);
            }

            return RedirectToPage(); 
        }

        private void PrepararPastaEListarArquivos()
        {
            var pastaDestino = Path.Combine(_env.WebRootPath, "files");
            if (!Directory.Exists(pastaDestino))
            {
                Directory.CreateDirectory(pastaDestino);
            }

            var arquivosInfo = new DirectoryInfo(pastaDestino).GetFiles("*.txt");
            ArquivosDisponiveis = arquivosInfo.Select(f => f.Name).ToList();
        }

        private void LerConteudoArquivoSeguro(string nomeArquivo)
        {

            var nomeSeguro = Path.GetFileName(nomeArquivo);
            var caminhoCompleto = Path.Combine(_env.WebRootPath, "files", nomeSeguro);

            if (System.IO.File.Exists(caminhoCompleto))
            {
                NotaSelecionadaNome = nomeSeguro;
                
                NotaSelecionadaConteudo = System.IO.File.ReadAllText(caminhoCompleto);
            }
        }
    }
}