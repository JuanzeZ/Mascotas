using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario _repoVeterinario;

        public Veterinario veterinario { get; set; }

        public DetallesVeterinarioModel()
        {
            this._repoVeterinario =
                new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int veterinarioId)
        {
            veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
            if (veterinario == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
