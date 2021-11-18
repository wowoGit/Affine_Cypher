using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddMulti
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<char> alpha = new List<char> { 'А', 'Б', 'В', 'Г', 'Д', 'Е',
                'Ё', 'Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р',
                'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю','Я'};
            KeyValuePair<int, int> multiKey = new KeyValuePair<int, int>(5,20);
            string res  = addCypher(alpha, "ФАМИЛИЯ", 23,true);
            
            Console.WriteLine("Add cypher: " +  res);
            res = addCypher(alpha, res, 23, false);
            Console.WriteLine("Add decypher: " + res);
            string res1 = multiCypher(alpha, "ФАМИЛИЯ", multiKey, true);
            Console.WriteLine("Multi cypher: " + res1);
            res1 = multiCypher(alpha, res1, multiKey, false);
            Console.WriteLine("Multi decypher: " + res1);
            int add_key = 4;
            KeyValuePair<int, int> mult_key = new KeyValuePair<int, int>(7,19);
            string combined_res = CombinedCypher(alpha, "ФАМИЛИЯ",add_key, mult_key, true);
            Console.WriteLine("Combined cypher: " + combined_res);
            combined_res = CombinedCypher(alpha, combined_res, add_key, mult_key, false);
            Console.WriteLine("Combined decypher: " + combined_res);
            Console.ReadLine();
        }
        static int mod(float a, float b)
        {
            return (int)(a - b * Math.Floor(a / b));
        }
        public static string addCypher(List<char> alpha, string word, int key, bool doCypher)
        {
            string res = "";
            if(doCypher)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int index = (alpha.IndexOf(word[i]) + key);
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int index = (alpha.IndexOf(word[i]) - key);
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }
            }
            Console.WriteLine();
            return res;
        }

        public static string multiCypher(List<char> alpha, string word, KeyValuePair<int,int> key, bool doCypher)
        {
            string res = "";
            if (doCypher)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int index = (alpha.IndexOf(word[i]) * key.Key);
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    int index = (alpha.IndexOf(word[i]) * key.Value);
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }
            }
            Console.WriteLine();
            return res;
        }
        public static string CombinedCypher(List<char> alpha, string message, int key_add, KeyValuePair<int, int> key_multi, bool doCypher)
        {
            string res="";
            if(doCypher)
            {
                //string cypher_multi = multiCypher(alpha, message, key_multi, true);
                //string cypher_add = addCypher(alpha, cypher_multi, key_add.Key, true);
                //res = cypher_add;
                for (int i = 0; i < message.Length; i++)
                {
                    int index = (alpha.IndexOf(message[i]) * key_multi.Key + key_add);
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }

            }
            else
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int index = (alpha.IndexOf(message[i]) - key_add) * key_multi.Value;
                    int char_idx = mod(index, alpha.Count);
                    Console.Write(char_idx);
                    Console.Write(' ');
                    res += alpha[char_idx];
                }
            }
            return res;
        }
    }
}
