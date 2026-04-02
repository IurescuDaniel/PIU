public class Intrebare
{
    public string Text { get; set; }
    public string A { get; set; }
    public string B { get; set; }
    public string C { get; set; }
    public string D { get; set; }
    public char RaspunsCorect { get; set; }

    public void Afiseaza()
    {
        Console.WriteLine(Text);
        Console.WriteLine($"a) {A}  b) {B}  c) {C}  d) {D}");
    }

    public bool Verifica(char r)
    {
        return char.ToLower(r) == char.ToLower(RaspunsCorect);
    }
}