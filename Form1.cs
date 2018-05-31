using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Forma : Form
    {
        Label Klik1 = null;

        Label Klik2 = null;
        
        Random rend = new Random();

        //список символiв

        List<string> znaki = new List<string>() 
        { 
            "A", "A", "B", "B", "C", "C", "D", "D",
            "E", "E", "F", "F", "G", "G", "H", "H"
        };

        //пiдстановка значкiв в квадрати

        private void ZnakiVkvadr()
        {
            foreach (Control contrl in Panel1.Controls)
            {
                Label znakLabel = contrl as Label;
                if (znakLabel != null)
                {
                    int randomNumber = rend.Next(znaki.Count);
                    znakLabel.Text = znaki[randomNumber];
                    znakLabel.ForeColor = znakLabel.BackColor;
                    znaki.RemoveAt(randomNumber);
                }
            }
        } 


        public Forma()
        {
            InitializeComponent();
            ZnakiVkvadr();
        }

        //обробка клiкiв

        private void Clicked(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return; 
            
            Label clicktoLabel = sender as Label;

            if (clicktoLabel != null)
            {
                if (clicktoLabel.ForeColor == Color.Black)
                    return;
                if (Klik1 == null)
                {
                    Klik1 = clicktoLabel;
                    Klik1.ForeColor = Color.Black;
                    return;
                }
                Klik2 = clicktoLabel;
                Klik2.ForeColor = Color.Black;
                Peremoga();

                if (Klik1.Text == Klik2.Text)
                {
                    Klik1 = null;
                    Klik2 = null;
                    return;
                }
                
                timer1.Start();
            }
        }

        private void Time(object sender, EventArgs e)
        {
            timer1.Stop();
            
            Klik1.ForeColor = Klik1.BackColor;
            Klik2.ForeColor = Klik2.BackColor;
            
            Klik1 = null;
            Klik2 = null;
        }

        //перевiрка на перемогу

        private void Peremoga()
        {
            foreach (Control control in Panel1.Controls)
            {
                Label ZnakiLabel = control as Label;

                if (ZnakiLabel != null)
                {
                    if (ZnakiLabel.ForeColor == ZnakiLabel.BackColor)
                        return;
                }
            }
            MessageBox.Show("Ти знайшов всі пари! Перемога!");
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
