
public class Materie
{
    public string NumeMaterie { get; set; }


    public int Scor = 0;

    public void StartTest()
    {
        Console.WriteLine("A inceput testul pentru " + NumeMaterie);
        
    }
}