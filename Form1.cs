using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turne, false O turn
        int turne_cont = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Łukasz","Tic Tak Toe about");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn) b.Text = "X";
            else b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turne_cont++;

            checkTheWiner();
        }

        private void checkTheWiner()
        {

            
            bool thereIsWiner = false;

            // HORIZONTAL WINER
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsWiner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsWiner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsWiner = true;

            // Vertical WINER
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsWiner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsWiner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsWiner = true;

            // Crose WINER
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsWiner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                thereIsWiner = true;

            if (thereIsWiner)
            {
                disebleButtons();

                string winer = "";
                if (turn)
                    winer = "O";
                else
                    winer = "X";
                MessageBox.Show(winer + " Wins!","Fuck yeee");
            }
             else
            {
                if (turne_cont == 9)
                    MessageBox.Show("Draw!", "Buuuuu");

            }
        }//end check the winer

        private void disebleButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }//end foreach
            }
            catch { }

        }//end of diseble_bittons

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turne_cont = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//end foreach
            }
            catch
            {
                A1.Text = "";
                A1.Enabled = true;
            }
        }
       

       
    }
}
