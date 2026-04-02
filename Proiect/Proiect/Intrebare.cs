public class Intrebare
{

    private const char SEPARATOR_PRINCIPAL = '|';
    private const int MATERIE = 0;
    private const int DIFICULTATE = 1; 
    private const int TEXT = 2;
    private const int VARIANTA_A = 3;
    private const int VARIANTA_B = 4;
    private const int VARIANTA_C = 5;
    private const int VARIANTA_D = 6;
    private const int RASPUNS_CORECT = 7; 
    public string NumeMaterie { get; set; }

    public string Text { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public char RaspunsCorect { get; set; }

    public int DificultateDinFisier { get; set; }

    public void Afiseaza()
    {
        Console.WriteLine(Text);
        Console.WriteLine($"a) {A}  b) {B}  c) {C}  d) {D}");
    }

    public bool Verifica(char r)
    {
        return char.ToLower(r) == char.ToLower(RaspunsCorect);
    }

    public string ConversieLaSirPtFisier(string numeMaterie,int dificultate)
    {
        return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}",
            SEPARATOR_PRINCIPAL,
            numeMaterie,
            dificultate,
            (Text ?? "Necunoscut"),
            (A ?? "Necunoscut"),
            (B ?? "Necunoscut"),
            (C ?? "Necunoscut"),
            (D ?? "Necunoscut"),
            RaspunsCorect);
    }

    public Intrebare()
    {
        NumeMaterie = string.Empty;
        Text = string.Empty;
        A = string.Empty;
        B = string.Empty;
        C = string.Empty;
        D = string.Empty;
        RaspunsCorect = ' ';
    }

    public Intrebare(string linieFisier)
    {
        string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL);

        if (dateFisier.Length > RASPUNS_CORECT)
        {
            this.NumeMaterie = dateFisier[MATERIE];
            this.Text = dateFisier[TEXT];
            this.A = dateFisier[VARIANTA_A];
            this.B = dateFisier[VARIANTA_B];
            this.C = dateFisier[VARIANTA_C];
            this.D = dateFisier[VARIANTA_D];
            this.DificultateDinFisier = int.Parse(dateFisier[DIFICULTATE]);
            this.Text = dateFisier[TEXT];
            this.RaspunsCorect = dateFisier[RASPUNS_CORECT].Trim()[0];
        }
    }

}
