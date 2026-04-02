public class Materie
{
    public enum DificultateMaterie
    {
        Usor = 1,
        Mediu = 2,
        Dificil = 3
    }

    public string Nume { get; set; }
    public List<Intrebare> Intrebari { get; set; } = new List<Intrebare>();
    public int Scor { get; set; } = 0;
    public DificultateMaterie Dificultate { get; set; }

    public Materie(string nume) 
    { 
        Nume = nume; 
    }

    public void AfiseazaIntrebari()
    {
        foreach (var i in Intrebari)
            i.Afiseaza();
    }

}