using System;

namespace CampañaVacunacionCovid_19CSharp
{
    public class Ciudadano
    {
        public string Nombre { get; set; }
        public string Id { get; set; }

        public Ciudadano(string nombre, string id)
        {
            Nombre = nombre;
            Id = id;
        }

        // Permite que HashSet compare por ID
        public override bool Equals(object obj)
        {
            if (obj is Ciudadano c)
                return Id == c.Id;
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Nombre} ({Id})";
        }
    }
}