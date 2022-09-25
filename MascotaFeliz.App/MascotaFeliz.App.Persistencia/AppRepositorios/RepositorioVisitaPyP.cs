using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitasPyP : IRepositorioVisitasPyP
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
        
        public RepositorioVisitasPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        public VisitaPyP AddVisitasPyP(VisitaPyP visitasPyP)
        {
            var visitasPyPAdicionado = _appContext.VisitasPyP.Add(visitasPyP);
            _appContext.SaveChanges();
            return visitasPyPAdicionado.Entity;
        }

        

        public void DeleteVisitasPyP(int idVisitasPyP)
        {
            var visitasPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitasPyP);
            if (visitasPyPEncontrado == null)
                return;
            _appContext.VisitasPyP.Remove(visitasPyPEncontrado);
            _appContext.SaveChanges();
        }

    
        public VisitaPyP GetVisitasPyP(int idVisitasPyP)
        {
            return _appContext.VisitasPyP.FirstOrDefault(d => d.Id == idVisitasPyP);
        }

        public VisitaPyP UpdateVisitasPyP(VisitaPyP visitasPyP)
        {
            var visitasPyPEncontrado = _appContext.VisitasPyP.FirstOrDefault(d => d.Id == visitasPyP.Id);
            if (visitasPyPEncontrado != null)
            {
                visitasPyPEncontrado.FechaVisita = visitasPyP.FechaVisita;
                visitasPyPEncontrado.Temperatura = visitasPyP.Temperatura;
                visitasPyPEncontrado.Peso = visitasPyP.Peso;
                visitasPyPEncontrado.FrecuenciaRespiratoria = visitasPyP.FrecuenciaRespiratoria;
                visitasPyPEncontrado.FrecuenciaCardiaca = visitasPyP.FrecuenciaCardiaca;
                visitasPyPEncontrado.EstadoAnimo = visitasPyP.EstadoAnimo;
                visitasPyPEncontrado.CedulaVeterinario = visitasPyP.CedulaVeterinario;
                visitasPyPEncontrado.Recomendaciones = visitasPyP.Recomendaciones;
                _appContext.SaveChanges();
            }
            return visitasPyPEncontrado;
        }     
    }
}