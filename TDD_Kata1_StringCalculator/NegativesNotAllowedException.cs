using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Kata1_StringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public int[] Negatives
        {
            get;
            set;
        }
    }
}
