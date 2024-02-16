using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Liivamägi_OOP_KT3
{
    
    public partial class Täring : Form
    {
        int dice1;
        int dice2;
        int dice3;
        int dice4;
        int p1Result;
        int p2Result;
        Random random = new Random();

        private void ClearAllFields()
        {
            foreach(Control control in Controls)
            {
                if(control is Label)
                {
                    Label label = (Label)control;
                    if (label.Name.StartsWith("TL_lblJuku") || label.Name.StartsWith("TL_lblPeeter") || label.Name.StartsWith("TL_lblTulemus"))
                    {
                        label.Text = "";
                    }
                }
            }
        }
        public Täring()
        {
            InitializeComponent();
            TL_btnP1.Enabled = false;
            TL_btnP2.Enabled = false;
        }

        private void TL_btnP1_Click(object sender, EventArgs e)
        {
            
            dice1 = random.Next(1, 7);
            dice2 = random.Next(1, 7);
            TL_lblJukuTaring1.Text = Convert.ToString(dice1);
            TL_lblJukuTaring2.Text = Convert.ToString(dice2);
            p1Result = dice1 + dice2;
            TL_lblJukuTulemus.Text = Convert.ToString(p1Result);
            TL_btnP1.Enabled = false;
            TL_btnP2.Enabled = true;
        }

        private void TL_btnP2_Click(object sender, EventArgs e)
        {
            dice3 = random.Next(1, 7);
            dice4 = random.Next(1, 7);
            TL_lblPeeterTaring1.Text = Convert.ToString(dice3);
            TL_lblPeeterTaring2.Text = Convert.ToString(dice4);
            p2Result = dice3 + dice4;
            TL_lblPeeterTulemus.Text = Convert.ToString(p2Result);
            TL_btnP2.Enabled = false;
            
            if(p2Result < p1Result) 
            {
                TL_lblTulemus.Text = "Võitis Juku!";
                TL_lblJukuTulemus.ForeColor = Color.White;
                TL_lblJukuTulemus.BackColor = Color.Teal;
            }
            else if(p2Result > p1Result)
            {
                TL_lblTulemus.Text = "Võitis Peeter!";
                TL_lblPeeterTulemus.ForeColor = Color.White;
                TL_lblPeeterTulemus.BackColor = Color.Teal;
            }
            else
            {
                TL_lblTulemus.Text = "Viik!";
            }
            TL_startBtn.Enabled = true;
            TL_startBtn.Focus();
        }

        private void TL_startBtn_Click(object sender, EventArgs e)
        {
            TL_btnP1.Enabled = true;
            TL_startBtn.Enabled = false;
            TL_lblJukuTulemus.ForeColor = Color.Teal;
            TL_lblJukuTulemus.BackColor = Color.White;
            TL_lblPeeterTulemus.ForeColor = Color.Teal;
            TL_lblPeeterTulemus.BackColor = Color.White;
            ClearAllFields();
            
        }
    }
}
