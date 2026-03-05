using System;
namespace Salariu
{
    class Program
    {
        static void Main()
        {
            double tarif_pe_ora;
            int numar_ore;

            Console.WriteLine("Introduceti tariful pe ora: ");
            tarif_pe_ora = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Introduceti numarul de ore lucrate: ");
            numar_ore = Convert.ToInt32(Console.ReadLine());

            double salariu = tarif_pe_ora * numar_ore;

            Console.WriteLine("Salariul este: " + salariu + " lei");

            if (salariu > 3000)
            {
                Console.WriteLine("Salariu Mare");
            }
            else
            {
                Console.WriteLine("Ati lucrat prea putine ore pentru a avea un salariu mare!");
            }
        }
    }
}