using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgo1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            CreatePop pop = new CreatePop();
            pop.keyWord=Console.ReadLine();
            pop.Controller();
            Console.ReadLine();
        }
    }
}
