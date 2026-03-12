using System;

class Meniu
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== TEST DE EVALUARE =====");
        Console.WriteLine("1. Informatica");
        Console.WriteLine("2. Matematica");
        Console.WriteLine("3. Geografie");
        Console.WriteLine("4. Biologie");
        Console.WriteLine("5. Istorie");

        Console.Write("Alege materia: ");

        int alegere = int.Parse(Console.ReadLine());

        Materie test = null;

        switch (alegere)
        {
            case 1:
                test = new Informatica();
                break;

            case 2:
                test = new Matematica();
                break;

            case 3:
                test = new Geografie();
                break;

            case 4:
                test = new Biologie();
                break;

            case 5:
                test = new Istorie();
                break;

            default:
                Console.WriteLine("Alegere invalida!");
                return;
        }

        test.StartTest();
    }
}