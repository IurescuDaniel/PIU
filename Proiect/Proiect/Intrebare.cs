public class Intrebare :Materie
{
    public string TextIntrebare { get; set; }

    public string VariantaA { get; set; }
    public string VariantaB { get; set; }
    public string VariantaC { get; set; }
    public string VariantaD { get; set; }

    public char RaspunsCorect { get; set; }

    public void AfiseazaIntrebare()
    {
        Console.WriteLine(TextIntrebare);
        Console.WriteLine("a) " + VariantaA);
        Console.WriteLine("b) " + VariantaB);
        Console.WriteLine("c) " + VariantaC);
        Console.WriteLine("d) " + VariantaD);
    }

    public bool VerificaRaspuns(char raspuns)
    {
        return raspuns == RaspunsCorect;
    }
}