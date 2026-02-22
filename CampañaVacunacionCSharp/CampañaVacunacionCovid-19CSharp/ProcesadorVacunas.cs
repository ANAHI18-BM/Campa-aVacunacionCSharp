using System;
using System.Collections.Generic;
using System.Linq;

namespace CampañaVacunacionCovid_19CSharp
{
    public class ProcesadorVacunas
    {
        public void EjecutarProcesamiento()
        {
            // Universo (500 ciudadanos)
            var universo = Enumerable.Range(1, 500)
                .Select(i => new Ciudadano($"Ciudadano {i}", $"ID-{i}"))
                .ToHashSet();

            // Pfizer (75 ciudadanos: 1–75)
            var pfizer = Enumerable.Range(1, 75)
                .Select(i => new Ciudadano($"Ciudadano {i}", $"ID-{i}"))
                .ToHashSet();

            // AstraZeneca (75 ciudadanos: 50–124)
            var astraZeneca = Enumerable.Range(50, 75)
                .Select(i => new Ciudadano($"Ciudadano {i}", $"ID-{i}"))
                .ToHashSet();

            // Intersección (Ambas dosis) → P ∩ A
            var ambasDosis = new HashSet<Ciudadano>(pfizer);
            ambasDosis.IntersectWith(astraZeneca);

            // Unión (Vacunados) → P ∪ A
            var vacunados = new HashSet<Ciudadano>(pfizer);
            vacunados.UnionWith(astraZeneca);

            // No vacunados → U - (P ∪ A)
            var noVacunados = new HashSet<Ciudadano>(universo);
            noVacunados.ExceptWith(vacunados);

            // Solo Pfizer → P - A
            var soloPfizer = new HashSet<Ciudadano>(pfizer);
            soloPfizer.ExceptWith(astraZeneca);

            // Solo AstraZeneca → A - P
            var soloAstra = new HashSet<Ciudadano>(astraZeneca);
            soloAstra.ExceptWith(pfizer);

            Console.WriteLine("===== RESULTADOS =====\n");

            Console.WriteLine($"Total ciudadanos: {universo.Count}");
            Console.WriteLine($"Total Pfizer: {pfizer.Count}");
            Console.WriteLine($"Total AstraZeneca: {astraZeneca.Count}");
            Console.WriteLine($"Ciudadanos con ambas dosis: {ambasDosis.Count}");
            Console.WriteLine($"Ciudadanos solo Pfizer: {soloPfizer.Count}");
            Console.WriteLine($"Ciudadanos solo AstraZeneca: {soloAstra.Count}");
            Console.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
        }
    }
}