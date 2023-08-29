using TrouveMot.ClassesMétiers;

namespace TrouveMot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SolutionATrouver sol = new SolutionATrouver("ANTICONSTITUTIONNELLEMENT");
            List<Generation> gen = new List<Generation>();
            
            do
            {
                if(gen.Count == 0)
                {
                    gen.Add(new Generation(10, sol));
                }
                else
                {
                    gen.Add(new Generation(gen.Last(), 1));
                }
                Console.WriteLine(gen.Count-1 + " " + new string(gen.Last().Meilleur.Mot) + " " + sol.Fitness(gen.Last().Meilleur));
            }
            while(sol.Fitness(gen.Last().Meilleur) != 0);
        }
    }
}