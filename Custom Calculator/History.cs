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

        public History(double fstNum, double secNum, string operation)
        {
            firstNumber = fstNum;
            secondNumber = secNum;
            stringOperation = operation;
        }
    }
}
