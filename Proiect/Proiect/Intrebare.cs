public class Intrebare
{
    public string TextIntrebare { get; set; }

    public string VariantaA { get; set; }
    public string VariantaB { get; set; }
    public string VariantaC { get; set; }
    public string VariantaD { get; set; }

    public char RaspunsCorect { get; set; }

    public string Imagine { get; set; }

    public void AfiseazaIntrebare()
    {
    }

    public bool VerificaRaspuns(char raspuns)
    {
        return true;
    }
}