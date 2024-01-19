using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bartha_Ariana_autok_dolgozat
{
    public partial class FormNyito : Form
    {
        public FormNyito()
        {
            InitializeComponent();
        }


        private void FormNyito_Load_1(object sender, EventArgs e)
        {
            foreach (string marka in Program.autok.Select(s => s.Marka).Distinct())
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Checked = true;
                checkBox.Text = marka;
                checkBox.Location = new Point(10, panel_Marka.Controls.Count * 20);
                checkBox.CheckedChanged += new EventHandler(pipaValtozott);
                panel_Marka.Controls.Add(checkBox);
            }
            updateAutoLista();

        }

        private void pipaValtozott(object sender, EventArgs e)
        {
            updateAutoLista();
        }

        private void updateAutoLista()
        {
            
            listBox_Autok.Items.Clear();
            List<string> kipipaltak = new List<string>();
            foreach (CheckBox item in panel_Marka.Controls)
            {
                if(item.Checked)
                {
                    kipipaltak.Add(item.Text);
                }
            }
            foreach (Auto item in Program.autok)
            {
                if(kipipaltak.Contains(item.Marka))
                {
                    listBox_Autok.Items.Add(item);
                }
            }
        }

        private void újToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAuto formAuto = new FormAuto("add");
            formAuto.ShowDialog();
        }

        private void módosítToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox_Autok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválaszttott elem");
                return;
            }
            FormAuto formAuto = new FormAuto("edit");
            formAuto.ShowDialog();
        }

        private void törölToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox_Autok.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválaszttott elem");
                return;
            }
            FormAuto formAuto = new FormAuto("delete");
            formAuto.ShowDialog();
        }
    }
}
