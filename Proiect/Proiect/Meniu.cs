using System;
using System.Collections.Generic;
using System.Linq;
using static Materie;


class Program
{
    static List<Materie> materii = new List<Materie>();

    static void Main()                                  // Meniu
    {
        CitesteDateInitiale();
        bool ok = true;
        while (ok)
        {
            Console.WriteLine("\n===== MENIU =====");
            Console.WriteLine("1. Afiseaza materia dorita");
            Console.WriteLine("2. Cauta materie dupa nume");
            Console.WriteLine("3. Incepe test");
            Console.WriteLine("0. Iesire");
            Console.Write("Alegere: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AfiseazaToate();
                    break;

                case "2":
                    Cauta();
                    break;

                case "3":
                    SelecteazaSiIncepeTest();
                    break;

                case "0":
                    ok = false;
                    break;

                default:
                    Console.WriteLine("Alegeti o varianta din meniu");
                    break;

            }
        }
    }
    static void CitesteDateInitiale()
    {
        var info = new Materie("Informatica") { Dificultate = DificultateMaterie.Dificil };              //Informatica
        info.Intrebari.Add(new Intrebare
        {
            Text = "Ce inseamna OOP?",
            A = "Object Oriented Programming",
            B = "Open Office Platform",
            C = "Online Output Protocol",
            D = "None",
            RaspunsCorect = 'a'
        });
        materii.Add(info);

        var mate = new Materie("Matematica") { Dificultate = DificultateMaterie.Mediu };              // Matematica
        mate.Intrebari.Add(new Intrebare
        {
           Text = "Care este formula ariei cercului?", 
            A = "A = 2πr", 
            B = "A = πr^2", 
            C = "A = πd", 
            D = "A = 4πr^2", 
            RaspunsCorect = 'b' 
        });
        materii.Add(mate);

        var bio = new Materie("Biologie") { Dificultate = DificultateMaterie.Usor };                // Biologie
        bio.Intrebari.Add(new Intrebare
        { 
            Text = "Care este functia principala a hemoglobinei?",
            A = "Transportul oxigenului", 
            B = "Digestia alimentelor", 
            C = "Reglarea temperaturii", 
            D = "Protectia impotriva infectiilor", 
            RaspunsCorect = 'a' 
        });
        materii.Add(bio);

        var isto = new Materie("Istorie") { Dificultate = DificultateMaterie.Usor };              // Istorie
        isto.Intrebari.Add(new Intrebare 
        {
            Text = "In ce an a cazut Imperiul Roman de Apus?",
            A = "476 d.Hr.", 
            B = "1453 d.Hr.",
            C = "1492 d.Hr.", 
            D = "1066 d.Hr.", 
            RaspunsCorect = 'a' 
        });
        materii.Add(isto);

        var geo = new Materie("Geografie") { Dificultate = DificultateMaterie.Usor };             //  Geografie
        geo.Intrebari.Add(new Intrebare 
        { 
            Text = "Care este cel mai lung fluviu din lume?",
            A = "Amazon", 
            B = "Nil", 
            C = "Yangtze", 
            D = "Mississippi", 
            RaspunsCorect = 'b' 
        });
        materii.Add(geo);
    }

    static void SelecteazaSiIncepeTest()                //Selectare test
    {
        Console.WriteLine("\n===== SELECTEAZA MATERIA =====");
        for (int i = 0; i < materii.Count; i++)
        {
            Console.WriteLine($"{i + 1} {materii[i].Nume}. Dificultate: {materii[i].Dificultate}");
        }
        Console.Write("Alege numarul materiei: ");

        if (int.TryParse(Console.ReadLine(), out int alegere) && alegere >= 1 && alegere <= materii.Count)
        {
            Materie materiaAleasa = materii[alegere - 1];
            RuleazaTest(materiaAleasa);
        }
        else
        {
            Console.WriteLine("Alegere invalida.");
        }
    }

    static void RuleazaTest(Materie m)                  //  Rulare test
    {
        Console.WriteLine($"\n===== TEST: {m.Nume.ToUpper()} =====");
        int scor = 0;

        for (int i = 0; i < m.Intrebari.Count; i++)
        {
            Intrebare q = m.Intrebari[i];
            Console.WriteLine($"\nIntrebarea {i + 1}: {q.Text}");
            Console.WriteLine($"  a) {q.A}");
            Console.WriteLine($"  b) {q.B}");
            Console.WriteLine($"  c) {q.C}");
            Console.WriteLine($"  d) {q.D}");
            Console.Write("Raspunsul tau : ");

            string input = Console.ReadLine().ToLower();
            if (input.Length == 1 && q.Verifica(input[0]))
            {
                Console.WriteLine("Corect! ✓");
                scor++;
            }
            else
            {
                Console.WriteLine($"Gresit. Raspuns corect: {q.RaspunsCorect})");
            }
        }

        Console.WriteLine($"\n===== REZULTAT =====");
        Console.WriteLine($"Scor final: {scor} / {m.Intrebari.Count}");

        if (scor == m.Intrebari.Count)
            Console.WriteLine("Felicitari! Ai raspuns corect la toate!");
        else if (scor >= m.Intrebari.Count / 2)
            Console.WriteLine("Bine! Mai ai de lucrat.");
        else
            Console.WriteLine("Mai invata si incearca din nou!");
    }


    static void AfiseazaToate()
    {
        Console.WriteLine("Pentru ce materie doriti sa afisati intrebarile?");
        for (int i = 0; i < materii.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {materii[i].Nume}");
        }
        Console.Write("Alege numarul materiei: ");

        if (int.TryParse(Console.ReadLine(), out int alegere) && alegere >= 1 && alegere <= materii.Count)
        {
            Materie materiaAleasa = materii[alegere - 1];
            Console.WriteLine($"\n--- {materiaAleasa.Nume} ({materiaAleasa.Intrebari.Count} intrebari) cu dificultatea {materiaAleasa.Dificultate}");
            materiaAleasa.AfiseazaIntrebari();
        }
        else
        {
            Console.WriteLine("Alegere invalida.");
        }
    }
    static void Cauta()
    {
        Console.Write("Nume materie: ");
        string input = Console.ReadLine().ToLower();
        var rezultat = materii.FirstOrDefault(m => m.Nume.ToLower().Contains(input));
        if (rezultat != null)
            Console.WriteLine($"Gasit: {rezultat.Nume} cu {rezultat.Intrebari.Count} intrebari");
        else
            Console.WriteLine("Materia nu a fost gasita.");
    }
}