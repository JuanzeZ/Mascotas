﻿using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;


namespace MascotaFeliz.App.Consola
{
    class Program
    {
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Estamos haciendo prueba en Edna Rocio!");
         //   AddDueno();
         //   AddVeterinario();
         //   AddMascota();
         //   ListarDuenos();
         //   listarMascotas();
         BuscarMascota(2);
        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Cedula = "1212",
                Nombres = "Juan",
                Apellidos = "Sin Miedo",
                Direccion = "Bajo un puente",
                Telefono = "1234567891",
                Correo = "juansinmiedo@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Cedula = "1555",
                Nombres = "Peter",
                Apellidos = "Pan Barajas",
                Direccion = "Sobre el rio",
                Telefono = "1234568888",
                TarjetaProfesional = "TP-2222"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }
        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Narco Jose",
                Color = "Negro",
                Especie = "Perro",
                Raza = "Pastor Aleman",
                
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void ListarDuenos()
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
                {
                    Console.WriteLine(d.Nombres + " " + d.Apellidos);  
                }
            
        }

        private static void listarMascotas()
        {
            Console.WriteLine( "          LISTADO DE MASCOTAS ");
            Console.WriteLine( "           ");
            Console.WriteLine("Nombre "+ "         Raza    "+ "     Especie "+"    Color");
            Console.WriteLine("================================================");
           var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota e in mascotas)
            {
            Console.WriteLine(e.Nombre+ "         "+e.Raza+ "   "+e.Especie+"    "+e.Color);
            }
        }

        private static void BuscarMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre+ "    "+mascota.Raza+ "   "+mascota.Especie+"    "+mascota.Color);
        }
        
        private static void AsignarVisitaPyP(int idHistoria)
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }

        private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(1, 15);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

     
        
    }
}
