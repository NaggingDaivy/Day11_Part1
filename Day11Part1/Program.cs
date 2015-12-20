using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11Part1
{
    class Program
    {

        static void Main(string[] args)
        {

            char[] chaine = { 'h', 'x', 'b', 'x', 'w', 'x', 'b', 'a' }; // string non mutable en C#

            bool containThreeFollowLetters = false, doesNotContainForbiddenLetter = false, hasTwoTwoSameLetters = false;

            while (!containThreeFollowLetters || !doesNotContainForbiddenLetter || !hasTwoTwoSameLetters)
            {


                containThreeFollowLetters = HasThreeFollowLetters(chaine);
                doesNotContainForbiddenLetter = DoesNotContainsForbiddenLetter(chaine);
                hasTwoTwoSameLetters = HasTwoTwoSameLetters(chaine);

                if (containThreeFollowLetters && doesNotContainForbiddenLetter && hasTwoTwoSameLetters)
                    break;

                for (int j = chaine.Length - 1; j >= 0; --j)
                {
                    if (chaine[j] == 'z')
                    {
                        chaine[j] = 'a';

                    }
                    else
                    {
                        if (chaine[j] == 'h')
                            chaine[j] = 'j';

                        else if (chaine[j] == 'n')
                            chaine[j] = 'p';

                        else if (chaine[j] == 'k')
                            chaine[j] = 'm';

                        else
                            ++chaine[j];

                        break;
                    }

                }

            }

            Console.WriteLine(chaine);





        }

        private static bool HasThreeFollowLetters(char[] chaine)
        {

            for (int i = 0; i < chaine.Length; ++i)
            {
                if (i + 1 < chaine.Length && i + 2 < chaine.Length)
                {
                    if (chaine[i + 1] == (chaine[i] + 1) && chaine[i + 2] == (chaine[i] + 2))
                    {
                        return true;
                    }

                }

            }

            return false;

        }

        private static bool DoesNotContainsForbiddenLetter(char[] chaine)
        {
            if (!chaine.Contains('i') && !chaine.Contains('o') && !chaine.Contains('l'))
                return true;

            return false;
        }

        private static bool HasTwoTwoSameLetters(char[] chaine)
        {
            int numberOfTwoSameLetters = 0;

            for (int i = 0; i < chaine.Length; ++i)
            {
                if (i + 1 < chaine.Length)
                {
                    if (chaine[i] == chaine[i + 1])
                    {
                        ++numberOfTwoSameLetters;
                        ++i;
                    }

                }
            }


            if (numberOfTwoSameLetters >= 2)
                return true;

            return false;
        }
    }
}
