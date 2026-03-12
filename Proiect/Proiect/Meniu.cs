using System;

class Meniu
{
    static void Main()
    {
        Console.WriteLine("===== TEST DE EVALUARE =====");
        Console.WriteLine("1. Informatica");
        Console.WriteLine("2. Matematica");
        Console.WriteLine("3. Geografie");
        Console.WriteLine("4. Biologie");
        Console.WriteLine("5. Istorie");

        Console.Write("Alege materia: ");

        string alegereInput = Console.ReadLine();
        int.TryParse(alegereInput, out int alegere);


        Materie materiaAleasa = null;

        switch (alegere)
        {
            case 1:
                materiaAleasa = new Informatica();
                break;


            case 2:
                materiaAleasa = new Matematica();
                break;


            case 3:
                materiaAleasa = new Geografie();
                break;


            case 4:
                materiaAleasa = new Biologie();
                break;


            case 5:
                materiaAleasa = new Istorie();
                break;

            default:
                Console.WriteLine();
                return;
        }
        materiaAleasa.StartTest();
        return;
    }
}