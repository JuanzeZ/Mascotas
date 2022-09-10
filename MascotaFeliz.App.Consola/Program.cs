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
        static void Main(string[] args)
        {
            Console.WriteLine("Estamos haciendo prueba en Edna Rocio!");
            AddDueno();
            AddVeterinario();
            AddMascota();
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
                Nombre = "Nacho",
                Color = "Gris",
                Especie = "Perro",
                Raza = "Snaucer miniatura",
                
            };
            _repoMascotas.AddMascota(mascota);
        }

    }
}
