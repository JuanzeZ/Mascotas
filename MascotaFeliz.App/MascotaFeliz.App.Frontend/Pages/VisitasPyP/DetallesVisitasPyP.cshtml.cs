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
    public class DetallesVisitasPyPModel : PageModel
    {
        private readonly IRepositorioVisitasPyP _repoVisitasPyP;

        public VisitaPyP visitasPyP { get; set; }

        public DetallesVisitasPyPModel()
        {
            this._repoVisitasPyP =
                new RepositorioVisitasPyP(new Persistencia.AppContext());
        }

        

        public IActionResult OnGet(int visitasPyPId)
        {
            visitasPyP = _repoVisitasPyP.GetVisitasPyP(visitasPyPId);
            if (visitasPyP == null)
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
