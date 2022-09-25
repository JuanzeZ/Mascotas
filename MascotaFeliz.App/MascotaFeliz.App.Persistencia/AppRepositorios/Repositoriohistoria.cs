using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        

        /// <summary>
        /// Metodo Constructor Utiiza

        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Historia AddHistoria(Historia historia)
        {
            var historiaAdicionado = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAdicionado.Entity;
        }

        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrado =
                _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrado == null) return;
            _appContext.Historias.Remove (historiaEncontrado);
            _appContext.SaveChanges();
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrado =
                _appContext.Historias.FirstOrDefault(d => d.Id == historia.Id);
            if (historiaEncontrado != null)
            {
                historiaEncontrado.FechaInicial = historia.FechaInicial;
                historiaEncontrado.VisitasPyP = historia.VisitasPyP;
                _appContext.SaveChanges();
            }
            return historiaEncontrado;
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext
                .Historias
                .FirstOrDefault(d => d.Id == idHistoria);
        }

        public Historia AsignarHistoria(int idMascota, int idHistoria)
        {
            var mascotaEncontrado =
                _appContext.Mascotas.FirstOrDefault(m => m.Id == idMascota);
            if (mascotaEncontrado != null)
            {
                var historiaEncontrada =
                    _appContext
                        .Historias
                        .FirstOrDefault(v => v.Id == idHistoria);
                if (historiaEncontrada != null)
                {
                    mascotaEncontrado.Historia = historiaEncontrada;
                    _appContext.SaveChanges();
                }
                return historiaEncontrada;
            }
            return null;
        }

        public IEnumerable<Historia> GetAllHistorias_()
        {
            return _appContext.Historias;
        }










    }
}
