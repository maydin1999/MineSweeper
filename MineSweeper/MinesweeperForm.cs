using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MinesweeperForm : Form
    {
        public MinesweeperForm()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblScoreBoard.Text = "0";
            lblHeartScore.Text = "3";
            flowLayoutPanel1.Controls.Clear();
            int mine1 = 0;
            int mine2 = 0;
            int mine3 = 0;

            Random rnd = new Random();
            mine1 = rnd.Next(1,21);
            mine2 = rnd.Next(22,42);
            mine3 = rnd.Next(43, 64);

            for (int i = 1; i <= 64; i++) 
            { 
                Button buttonMine = new Button();
                buttonMine.Name = "btn"+i.ToString();
                buttonMine.Size = new System.Drawing.Size(35, 35);
                buttonMine.Text = i.ToString();
                buttonMine.UseVisualStyleBackColor = true;
                if (mine1 == i || mine2 == i || mine3 == i)
                {
                    buttonMine.Tag = true;
                }
                else
                {
                    buttonMine.Tag= false;
                }
                buttonMine.Click += ButtonMine_Click;
                flowLayoutPanel1.Controls.Add(buttonMine);
            }
        }

        private void ButtonMine_Click(object sender, EventArgs e)
        {
            Button clickedButton = ((Button)sender);
            bool didFindMine = (bool)clickedButton.Tag;
            if (didFindMine)
            {
                MessageBox.Show("Mine Found!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                clickedButton.BackColor = Color.Red;
                int heartInt = int.Parse(lblHeartScore.Text);
                heartInt--;
                lblHeartScore.Text = heartInt.ToString();
                if (heartInt == 0)
                {
                    MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Visible = false
                    // Tüm butonları gizlemek
                    foreach (Control control in flowLayoutPanel1.Controls)
                    {
                        if (control is Button)
                        {
                            control.Visible = false;
                        }
                    }

                    // Yeniden başlatmak için btnStart'ı göstermek
                    btnStart.Visible = true;
                }
            }
            else
            {
                clickedButton.BackColor= Color.Green;
                int scoreInt = int.Parse(lblScoreBoard.Text);
                scoreInt++;
                lblScoreBoard.Text = scoreInt.ToString();

                //clickedButton.Visible = false;
            }
        }
        // public 
    }
}
