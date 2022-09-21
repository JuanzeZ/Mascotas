using System;
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
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos");
            //AddDueno();
            //GetDueno(1);
            

            //AddVeterinario();
            GetVeterinario(4);


            //AddMascota();
            //GetMascota(1);
            //GetAllMascotas();
        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombre = "Neyda",
                Apellidos = "Leon",
                Direccion = "Carrera 32",
                Telefono = "3002796563",
                Correo = "NeydaLeon13@hotmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombre = "Juan",
                Apellidos = "Ramirez",
                Direccion = "Calle 18",
                Telefono = "3115727575",
                TarjetaProfesional  = "jr2233@gmail.com"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }
        

        private static void AddMascota()
        {
            var mascota = new Mascota
            {
                Nombre = "Loki",
                Color = "Blanco y Negro",
                Especie = "Felino",
                Raza = "Smoking",
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void GetDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombre + " " + dueno.Apellidos +" "+dueno.Direccion+" "+dueno.Telefono+" "+dueno.Correo);
        }

        private static void GetVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombre + " " + veterinario.Apellidos +" "+veterinario.Direccion+" "+veterinario.Telefono+" "+veterinario.TarjetaProfesional);
        }

        private static void GetMascota(int idMascota)
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color +" "+mascota.Especie+" "+mascota.Raza);
        }

        private static void GetAllMascotas()
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota e in mascotas)
            {
                Console.WriteLine(e.Nombre + " " + e.Color +" "+e.Especie+" "+e.Raza);
            }
        }


        
        
        
    }
}