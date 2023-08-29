using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrouveMot.ClassesMétiers
{
    public class SolutionATrouver
    {
        private char[] motATrouver;
        public int Length { get => motATrouver.Length; }
        public SolutionATrouver(string mot)
        {
            motATrouver = mot.ToCharArray();
        }
        public int Fitness(Individu proposition)
        {
            int result = 0; 
            for(int i = 0; i < motATrouver.Length; i++)
            {
                result+=Math.Abs((int)motATrouver[i] - (int)proposition.Mot[i]);
            }
            return result;
        }
    }
}
