using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCipher
{
    class Cipher 
    {
        public string Encrypt(string textToEncode, char[,] key)
        {
            string result = String.Empty;
            
            int m = key.GetLength(0);
            int n = key.GetLength(1);
            int letter = 0;
            int problem = 0;
            string numi = String.Empty;
            string numj = String.Empty;
            char[] text = textToEncode.ToArray();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (text[letter] == key[i, j])
                    {
                        if (i.ToString().Length == 1 && i!=9)
                            numi = "0" + (i+1).ToString();
                        else numi = (i+1).ToString();
                        if (j.ToString().Length == 1 && j!=9)
                            numj = "0" + (j+1).ToString();
                        else numj = (j+1).ToString();
                        result += numi + "/" + numj + ", ";
                        letter++;
                    }
                    if (letter >= textToEncode.Length && result.Length>=text.Length*7)
                        return result;
                    
                    else if (letter < textToEncode.Length && j == n-1 && i == m-1)
                    {
                        i = 0;
                        j = 0;
                        problem++;
                    }
                    if (problem > 1)
                    {
                        result += numi + "/" + numj + ", ";
                        letter++;
                    }
                }
            }
            
            return result;
        }

        public string Decrypt(char[] textToDecode, char[,] key)
        {
            string result = "";
            
            int k = 0;
            int p = 0;
            for (int i = 0; i < textToDecode.Length; i+=4)
            {
                k = int.Parse(textToDecode[i].ToString() + textToDecode[i+1].ToString());
                p = int.Parse(textToDecode[i+2].ToString()+textToDecode[i+3].ToString());
                result += key[k-1, p-1];
                
            }

            return result;
        }
    }
}
