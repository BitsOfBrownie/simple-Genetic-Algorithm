using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo1._1
{
    internal class CreatePop
    {
        //creating key word
        public string keyWord;
        public int score = 0;
        public int score1 = 0;
        public int score2 = 0;
        public int score3 = 0;

        public void Elements(int[] generationArray1,int[] generationArray2,int[] generationArray3,string element1, string element2, string element3)
        {
            // establishing strings to be built
            StringBuilder element1temp = new StringBuilder();
            StringBuilder element2temp = new StringBuilder();
            StringBuilder element3temp = new StringBuilder();

            //resetting temporary element
            element1temp.Clear();
            element2temp.Clear();
            element3temp.Clear();
            element1temp.AppendLine(element1);
            element2temp.AppendLine(element2);
            element3temp.AppendLine(element3);


            //Creating random strings
            for (int i = 0; i < keyWord.Length; i++)    
            {
                if (generationArray1[i] == 0)
                {
                    element1temp[i] = AlphabetGenerator()[0];
                }
                else if (generationArray1[i] == 1)
                { 
                    continue;
                }
            }
            for (int i = 0; i < keyWord.Length; i++)
            {
                if (generationArray2[i] == 0)
                {
                    element2temp[i] = AlphabetGenerator()[0];
                }
                else if (generationArray2[i] == 1)
                {
                    continue;
                }

            }
            for (int i = 0; i < keyWord.Length; i++)
            {
                if (generationArray3[i] == 0)
                {
                    element3temp[i] = AlphabetGenerator()[0];
                }
                else if (generationArray3[i] == 1)
                {
                    continue;
                }

            }
            //Console.WriteLine(element1temp);
            element1 = element1temp.ToString();
            element2 = element2temp.ToString();
            element3 = element3temp.ToString();

            //setting generation modifiers to correspond with correct letters
            for (int i = 0; i < keyWord.Length; i++)
            {
                if (element1[i] == keyWord[i])
                { generationArray1[i] = 1; }
            }
            for (int i = 0; i < keyWord.Length; i++)
            {
                if (element2[i] == keyWord[i])
                { generationArray2[i] = 1; }
            }
            for (int i = 0; i < keyWord.Length; i++)
            {
                if (element3[i] == keyWord[i])
                { generationArray3[i] = 1; }
            }


        }
        public string AlphabetGenerator()
        {
            string letter = string.Empty;//setting return to nothing
            Random random = new Random(Guid.NewGuid().GetHashCode()); //getting random modifying time
            string alphabet = "abcdefghijklmnopqrstuvwxyz"; //setting to alphabet
            int place = random.Next(26); // getting random place in the alphabet
            letter = letter + alphabet.ElementAt(place); // setting return value to random letter
            return letter;

        }

        public void Controller()
        {
            string element1 = " ";
            string element2 = " ";
            string element3 = " ";

            int Generations = 1;

            for (int i = 0; i < keyWord.Length - 1; i++)
            {
                element1 = element1 + " ";
                element2 = element2 + " ";
                element3 = element3 + " ";
            }

            //creating generation modifiers
            int[] generationArray1 =new int[keyWord.Length];
            int[] generationArray2 = new int[keyWord.Length];
            int[] generationArray3 = new int[keyWord.Length];

            // setting all of the generation modifiers to off
            for (int i = 0; i < keyWord.Length; i++)
            {
                generationArray1[i] = 0;
                generationArray2[i] = 0;
                generationArray3[i] = 0;
            }
            while (score < keyWord.Length)
            {
                //passing nesscecary arguments and calling function to create data
                Elements(generationArray1, generationArray2, generationArray3, element1, element2, element3);
                //scoring generation and setting modifiers
                Scoring(generationArray1, generationArray2, generationArray3);
                Generations++;
               // Console.WriteLine(Generations);
            }
            Console.WriteLine($"This algorithm found your string in {Generations} Generations");

        }
        public void Scoring(int[] generationArray1, int[] generationArray2, int[] generationArray3)
        {


            //getting scores
            for (int i = 0; i < keyWord.Length; i++)
            {
                score1 = score1 + generationArray1[i];
                score2 = score2 + generationArray2[i];
                score3 = score3 + generationArray3[i];
            }

            //setting strongest to survive
            if (score1 >= score2 && score1 >= score3)
            {
                for (int i = 0; i < keyWord.Length; i++)
                {
                    generationArray2[i] = generationArray1[i];
                    generationArray3[i] = generationArray1[i];

                }
            }
            else if (score2 >= score1 && score2 >= score3)
            {
                for (int i = 0; i < keyWord.Length; i++)
                {
                    generationArray1[i] = generationArray2[i];
                    generationArray3[i] = generationArray2[i];
                }
            }
            else if (score3 >= score1 && score3 >= score2)
                
                for (int i = 0; i < keyWord.Length; i++)
                {
                    generationArray2[i] = generationArray3[i];
                    generationArray1[i] = generationArray3[i];

                }
            Console.WriteLine( $"{score1}, {score2}, {score3}");
            
            //showing which Generation got it
            if (score1 == keyWord.Length)
            {
                Console.WriteLine("Generation 1 got it!");
                score = score1;
            }
            else if (score2 == keyWord.Length)
            {
                Console.WriteLine("Generation 2 got it!");
                score = score2;
            }
            else if (score3 == keyWord.Length)
            {
                Console.WriteLine("Generation 3 got it!");
                score = score3;
            }
            score1 = 0;
            score2 = 0;
            score3 = 0;
        }

     
    }

}
