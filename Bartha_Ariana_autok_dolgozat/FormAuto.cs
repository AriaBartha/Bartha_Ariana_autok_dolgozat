using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bartha_Ariana_autok_dolgozat
{
    public partial class FormAuto : Form
    {
        string muvelet;
        public FormAuto(string muvelet)
        {
            InitializeComponent();
            this.muvelet = muvelet;
        }


        private void FormAuto_Load(object sender, EventArgs e)
        {
            switch (muvelet)
            {
                case "add":
                    this.Text = "Új autó";
                    button_Muvelet.Text = "Hozzáad";
                    button_Muvelet.BackColor = Color.LightGreen;
                    button_Muvelet.Click += new EventHandler(insertAuto);
                    break;
                case "edit":
                    this.Text = "Adatmódosítás";
                    button_Muvelet.Text = "Módosít";
                    button_Muvelet.BackColor = Color.Aqua;
                    button_Muvelet.Click += new EventHandler(updateAuto);
                    mezokKitoltese();
                    break;
                case "delete":
                    this.Text = "Törlés";
                    button_Muvelet.Text = "Törlés";
                    button_Muvelet.BackColor = Color.Red;
                    button_Muvelet.ForeColor = Color.White;
                    button_Muvelet.Click += new EventHandler(deleteAuto);
                    mezokKitoltese();
                    break;
            }
        }

        private void mezokKitoltese()
        {
            Auto auto = (Auto)Program.formNyito.listBox_Autok.SelectedItem;
            textBox_Rendszam.Text = auto.Rendszam.ToString();
            textBox_Marka.Text = auto.Marka.ToString();
            textBox_Modell.Text = auto.Modell.ToString();
            nu_GyartasiEv.Value = (decimal)auto.GyartasiEv;
            dateTimePicker_Forgalmi.Value = (DateTime)auto.ForgalmiErvenyesseg;
            nu_Ar.Value = (decimal)auto.Ar;
            nu_Km.Value = (decimal)auto.Km;
            nu_Hengerurtartalom.Value = (decimal)auto.Hengerurtartalom;
            nu_Tomeg.Value = (decimal)auto.Tomeg;
            nu_Teljesitmeny.Value = (decimal)auto.Teljesitmeny;
        }

        private Auto createAuto()
        {
            Auto auto = new Auto();
            auto.Rendszam = textBox_Rendszam.Text;
            auto.Marka = textBox_Marka.Text;
            auto.Modell = textBox_Modell.Text;
            auto.GyartasiEv = (int)nu_GyartasiEv.Value;
            auto.ForgalmiErvenyesseg = (DateTime)dateTimePicker_Forgalmi.Value;
            auto.Ar = (int)nu_Ar.Value;
            auto.Km = (int)nu_Km.Value;
            auto.Hengerurtartalom = (int)nu_Hengerurtartalom.Value;
            auto.Tomeg = (int)nu_Tomeg.Value;
            auto.Teljesitmeny = (int)nu_Teljesitmeny.Value;

            return auto;
        }

        private void deleteAuto(object sender, EventArgs e)
        {
            Auto auto = createAuto();
            Program.adatok.deleteAuto(auto);
            this.Close();
        }

        private void updateAuto(object sender, EventArgs e)
        {
            Auto auto = createAuto();
            Program.adatok.updateAuto(auto);
            this.Close();
        }

        private void insertAuto(object sender, EventArgs e)
        {

            Auto auto = createAuto();
            Program.adatok.insertAuto(auto);
            this.Close();
        }

        

    }
}
