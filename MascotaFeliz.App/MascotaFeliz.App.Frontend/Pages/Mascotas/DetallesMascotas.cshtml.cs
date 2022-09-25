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
    public class DetallesMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;

        private readonly IRepositorioDueno _repoDueno;

        private readonly IRepositorioVeterinario _repoVeterinario;

        private readonly IRepositorioHistoria _repoHistoria;

        public Mascota mascota { get; set; }

        public Dueno dueno { get; set; }

        public Veterinario veterinario { get; set; }

        public Historia historia { get; set; }

        public DetallesMascotasModel()
        {
            this._repoMascota =
                new RepositorioMascota(new Persistencia.AppContext());

            this._repoDueno =
                new RepositorioDueno(new Persistencia.AppContext());

            this._repoVeterinario =
                new RepositorioVeterinario(new Persistencia.AppContext());

            this._repoHistoria =
                new RepositorioHistoria(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int mascotaId)
        {
        mascota = _repoMascota.GetMascota(mascotaId);
            
            if (mascota == null)
            {
                return RedirectToPage("");
            }
            else
            {
                return Page();
            }
        }



    










    }
}
