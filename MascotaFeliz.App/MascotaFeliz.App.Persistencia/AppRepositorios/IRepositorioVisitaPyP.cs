using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitasPyP
    {
        
        VisitaPyP AddVisitasPyP(VisitaPyP visitasPyP);
        VisitaPyP UpdateVisitasPyP(VisitaPyP visitasPyP);
        void DeleteVisitasPyP(int idVisitasPyP);
        VisitaPyP GetVisitasPyP(int idVisitasPyP);
        
    }
}