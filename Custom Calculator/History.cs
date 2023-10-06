using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Calculator
{
    public class History
    {
        public double firstNumber { get; set; }
        public double secondNumber { get; set; }    
        public string stringOperation { get; set; }

        public string result { get; set; }

        public History(double fstNum, double secNum, string operation)
        {
            firstNumber = fstNum;
            secondNumber = secNum;
            stringOperation = operation;
        }

        // u istoriju upisejus text iz forme, ovu klasu nisi ni upotrebio, trenutno je beskorisna
        // mogao bi da je prsledis kao parametar za saveHistory npr
        // ali za sada ne moras dok ne sredis sve ostale stvari

        // onda napravis metodu koja vraca celu kalkulaciju i cuvas jednu po jednu, npr
        public string ToString()
        {
            return $"{firstNumber} {stringOperation} {secondNumber} = {result}";
        }

        // ako razumes ovaj koncept uradi tako, ako ne ostavi za kasnije
    }
}
