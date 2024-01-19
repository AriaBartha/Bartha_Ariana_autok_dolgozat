using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bartha_Ariana_autok_dolgozat
{
    internal static class Program
    {

        public static List<Auto> autok = new List<Auto>();
        public static Adatbazis adatok = null;
        public static FormNyito formNyito = null;
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            adatok = new Adatbazis();
            autok = adatok.getAllAuto();
            formNyito = new FormNyito();
            Application.Run(formNyito);
        }
    }
}
