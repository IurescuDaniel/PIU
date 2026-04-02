using System.IO;
using System.Threading;
using static Materie;

namespace NivelStocareDate
{
    public class AdministrareMaterii_FisierText : IStocareData
    {
        private string numeFisier;

        public AdministrareMaterii_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddMaterie(Materie m)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                foreach (var intrebare in m.Intrebari)
                {
                    sw.WriteLine(intrebare.ConversieLaSirPtFisier(m.Nume, (int)m.Dificultate));
                }
            }
        }

        public List<Materie> GetMaterii()
        {
            List<Materie> listaMaterii = new List<Materie>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    Intrebare i = new Intrebare(linie);
                    var materieExistenta = listaMaterii.FirstOrDefault(m => m.Nume == i.NumeMaterie);

                    if (materieExistenta == null)
                    {
                        Materie materieNoua = new Materie(i.NumeMaterie);
                        materieNoua.Dificultate = (DificultateMaterie)i.DificultateDinFisier;
                        materieNoua.Intrebari.Add(i);
                        listaMaterii.Add(materieNoua);
                    }
                    else
                    {
                        materieExistenta.Intrebari.Add(i);
                    }
                }
            }
            return listaMaterii;
        }
        public Materie GetMaterie(string nume) => null;
        public bool UpdateMaterie(Materie m) => false;
    }
}