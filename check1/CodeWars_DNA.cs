using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace check1
{
    internal class CodeWars_DNA
    {
        public static string MakeComplement(string dna)
        {
            var sb = new StringBuilder();
            
            foreach (var item in dna)
            {
                var letter = item switch
                {
                    'A' => 'T',
                    'T' => 'A',
                    'C' => 'G',
                    'G' => 'C'
                };
                sb.Append(letter);
            }
            return sb.ToString();
        }
    }
}
