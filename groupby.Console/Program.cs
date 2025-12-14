using System.Linq;
using System.Collections;
using System.Numerics;
namespace GroupBy
{
    class Program
    {
        public static void Main(string[] args)
        {

            
        }



        public static string NoSpace(string input)
        {
            return new string(input.Where(a => a != ' ').ToArray());
        }
    }
}


