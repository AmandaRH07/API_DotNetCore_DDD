using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variaveis
            int variavelInteira;
            variavelInteira = 123;

            bool variavelBooleana = false;

            if (variavelBooleana == false){
                variavelInteira = 765;
            }

            var testeInteger = 111;
            var testeBool = true;
            var testeString = "aula";

            // testeString = 222;

            Console.WriteLine("O valor da variavel é {0}", variavelInteira);
            Console.WriteLine("O valor da variavel é {0}", testeInteger);
            Console.WriteLine("O valor da variavel é {0}", testeBool);
            Console.WriteLine("O valor da variavel é {0}", testeString);

            //Operadores Aritméticos => +, -, *, %
            int var1, var2 , total = 0;
            var1 = 10;
            var2 = 55;
            total = var2 % var1;
            Console.WriteLine("Total: {0}", total);

            // Incremento e Decremento
            total++;
            Console.WriteLine("Incremento {0}", total);
            total--;
            Console.WriteLine("Decremento {0}", total);

            /*Operadores lógicos
            And = E = &&
            Or = Ou = ||
            Not = Não = !*/

            bool logico1 = true;
            bool logico2 = true;

            Console.WriteLine(logico1 && logico2);
            Console.WriteLine(logico1 || logico2);

            /*Operadores Relacionais
            == igual a
            != diferente de 
            > maior que 
            < menor que 
            >= maior ou igual que
            <= menor ou igual que */

            var relacionais1 = 10;
            var relacionais2 = 50;
            Console.WriteLine(relacionais1 == relacionais2);
            Console.WriteLine(relacionais1 != relacionais2);
            Console.WriteLine(relacionais1 >= relacionais2);
            Console.WriteLine(relacionais1 < relacionais2);

            // IF - Se
            // Else - se não
            int val1 = 10;
            int val2 = 5;

            if (val1 == val2){
                Console.WriteLine("Igual");
            }
            else {
                Console.WriteLine("Não atendeu");
            }

            // for - para cada
            for (int i = 0; i <= 3; i++){
                Console.WriteLine("For: " + i);
            }

            // while - enquanto

            int contador = 0;
            while (contador < 4){
                Console.WriteLine("While: " + contador);
                contador++;
            }

            // switch...case - escolher

            switch (DateTime.Now.DayOfWeek){
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    Console.WriteLine("Final de semana");
                break;
                case DayOfWeek.Monday:
                    Console.WriteLine("Segunda-feira");
                break;
                 case DayOfWeek.Tuesday:
                    Console.WriteLine("Terça-feira");
                break;
                 case DayOfWeek.Wednesday:
                    Console.WriteLine("Quarta-feira");
                break;
                 case DayOfWeek.Thursday:
                    Console.WriteLine("Quinta-feira");
                break;
                 case DayOfWeek.Friday:
                    Console.WriteLine("Sexta-feira");
                break;
                default: 
                    Console.WriteLine("Default");
                break;
            }
        }
    }
}
