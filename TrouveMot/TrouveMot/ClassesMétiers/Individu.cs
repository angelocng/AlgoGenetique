using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrouveMot.ClassesMétiers
{
    public class Individu
    {
        private char[] mot;
        public char[] Mot { get => mot; }
        public Individu(int nbLettre)
        {
            mot = new char[nbLettre];
            for(int i= 0; i < nbLettre; i++)
            {
                mot[i] = this.GenererGene();
            }
        }
        public Individu(char[] mot)
        {
            this.mot = mot;
        }
        private char GenererGene()
        {
            return (char)((int)'A' + (int)Alea.GetInstance().Next(0, 26));
        }
        private void Mutation(int numGene)
        {
            if (numGene < 0 || numGene >= mot.Length)
            {
                throw new ArgumentException("Numéro du gène invalide");
            }
            char nouveau;
            do
            {
                nouveau = this.GenererGene();
            }
            while (mot[numGene] == nouveau);
            mot[numGene] = nouveau;
        }
        public void Muter(int taux)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                int rnd = Alea.GetInstance().Next(1, 101);
                if (rnd <= taux)
                {
                    Mutation(i);
                }
            }
        }
        public Individu CrossOver(Individu avec) => CrossOver(avec, Alea.GetInstance().Next(0, 2) == 0);
        public Individu CrossOver(Individu avec, bool estParentFort)
        {
            int positionCurseur = mot.Length / 2;
            List<char> nouveau = new List<char>();
            Individu parentDonneur;
            for (int i = 0; i < mot.Length; i++)
            {
                if (i <= positionCurseur)
                {
                    parentDonneur = estParentFort ? this : avec;
                }
                else
                {
                    parentDonneur = estParentFort ? avec : this;
                }
                nouveau.Add(parentDonneur.Mot[i]);
            }
            return new Individu(nouveau.ToArray());
        }
    }
}
