using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrouveMot.ClassesMétiers
{
    public class Generation
    {
        private List<Individu> sesIndividus;
        private SolutionATrouver but;
        public List<Individu> SesIndividus { get => sesIndividus; }
        public SolutionATrouver But { get => but; }
        public Individu Meilleur { get {
                this.Trier();
                return sesIndividus[0];
            } }
        public Generation(int nbIndividu, SolutionATrouver but)
        {
            this.but = but;
            this.sesIndividus = new List<Individu>();
            for (int i = 0; i < nbIndividu; i++)
            {
                this.sesIndividus.Add(new Individu(but.Length));
            }
        }
        public Generation(Generation depuis, int tauxDeMutation)
        {
            this.but = depuis.But;
            List<Individu> individusSelectionnes = Selection(depuis);
            List<Individu> nouvelleGeneration = new List<Individu>();
            for (int i = 1; i < individusSelectionnes.Count; i++)
            {
                nouvelleGeneration.Add(individusSelectionnes[0].CrossOver(individusSelectionnes[i],false));
                nouvelleGeneration.Add(individusSelectionnes[0].CrossOver(individusSelectionnes[i],true));
            }
            nouvelleGeneration.Add(individusSelectionnes[1].CrossOver(individusSelectionnes[2], false));
            nouvelleGeneration.Add(individusSelectionnes[1].CrossOver(individusSelectionnes[2], true));
            nouvelleGeneration.ForEach(d => d.Muter(tauxDeMutation));
            this.sesIndividus = nouvelleGeneration;
        }
        public void Trier() => sesIndividus.Sort((a, b) => but.Fitness(a) - but.Fitness(b));
        private List<Individu> Selection(Generation depuis)
        {
            List<Individu> classement = depuis.SesIndividus;
            classement.Sort((a, b) => but.Fitness(a) - but.Fitness(b));
            return classement.GetRange(0, 5);
        }
    }
}
