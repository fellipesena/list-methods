using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace list_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo");
            Console.WriteLine("Escolha uma opção abaixo:");
            Console.WriteLine("1 - Imprimir a média dos elementos de uma lista de inteiros e o número de ellementos maiores do que a média.");
            Console.WriteLine("2 - Imprimir uma lista de formaa invertida.");

            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 9, 5 };

            string input = Console.ReadLine();

            static int Input(string input)
            {
                int option;
                if (!Int32.TryParse(input, out option))
                {
                    Console.WriteLine("Digite um inteiro!");
                    string newInput = Console.ReadLine();
                    return Input(newInput);
                }
                else
                {
                    if(option != 1 && option != 2)
                    {
                        Console.WriteLine("Digite uma opção válida!");
                        string newInput = Console.ReadLine();
                        return Input(newInput);
                    }
                    return option;
                }
            }

            int option = Input(input);
            
            switch (option)
            {
                case 1:
                    Console.WriteLine("Imprimir a média dos elementos de uma lista de inteiros e o número de ellementos maiores do que a média.");
                    Console.WriteLine("Lista de entrada:");
                    foreach (int x in list)
                    {
                        Console.Write(x);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    Console.WriteLine(Average(list, list.Count() - 1, 0, list.Count()));
                    break;
                case 2:
                    Console.WriteLine("Imprimir uma lista de forma invertida.");
                    List<int> aux = new List<int>();

                    Console.WriteLine("Lista de entrada:");
                    foreach (int x in list)
                    {
                        Console.Write(x);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                    Reverse(list, aux);
                    
                    Console.WriteLine("Lista de saída:");
                    foreach(int x in aux)
                    {
                        Console.Write(x);
                        Console.Write(" ");
                    }
                    break;
            }

            float Average(List<int> list, int range, float sum, int size)
            {
                if(range >= 0)
                {
                    sum += list[range];
                    return Average(list, range - 1, sum, size);
                }
                else
                {
                    float media = sum / size;
                    int count = 0;
                    foreach(int x in list)
                    {
                        if(x > media)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine("Total de elementos maiores que a média:");
                    Console.WriteLine(count);
                    Console.WriteLine("Media:");
                    return media;
                }
            }

            List<int> Reverse(List<int> list, List<int> aux)
            {
                if (list.Count() == 0)
                {
                    return list;
                }
                else
                {
                    int index = (list.Count() - 1);
                    aux.Add(list[index]);
                    list.RemoveAt(index);
                    return Reverse(list, aux);
                }
            }

        }
    }
}
