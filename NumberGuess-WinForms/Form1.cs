using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberGuess_WinForms
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<Label> lblResults = new List<Label>();
        List<PictureBox> picResults = new List<PictureBox>();

        int answer = 0;
        int numGuess = 0;
        int randomMax = 0;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
            ResetGame();
        }

        private void InitializeGame()
        {
            lblResults.Add(label1);
            lblResults.Add(label2);
            lblResults.Add(label3);
            lblResults.Add(label4);
            lblResults.Add(label5);

            picResults.Add(pictureBox1);
            picResults.Add(pictureBox2);
            picResults.Add(pictureBox3);
            picResults.Add(pictureBox4);
            picResults.Add(pictureBox5);
        }

        private void ResetGame()
        {
            foreach (Label label in lblResults) label.Text = "";
            foreach (PictureBox pic in picResults) pic.Image = null;
            txtGuess.Enabled = false;
            btnStart.Enabled = true;
            btnStart.Text = "Start";
            txtGuess.Text = "00";
            numGuess = 0;
            txtLastGuess.Text = "";
        }

        private void StartGame()
        {
            answer = random.Next(1, randomMax + 1);
            txtGuess.Enabled = true;
            btnStart.Text = "Reset";
            txtGuess.Text = "";
            txtGuess.Focus();
        }

        private void GameWon()
        {
            txtGuess.Enabled = false;
        }

        private void GameLost()
        {
            txtGuess.Enabled = false;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Equals("Start")) StartGame();
            else ResetGame();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 10;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 15;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                randomMax = 20;
            }
        }

        private void txtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGuess_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = txtGuess.Text;
                txtGuess.Text = "";
                int guess;
                int.TryParse(text, out guess);
                txtLastGuess.Text = text;
                if (guess == answer)
                {
                    lblResults[numGuess].ForeColor = Color.Green;
                    lblResults[numGuess].Text = text + " correct!";
                    picResults[numGuess].Image = Properties.Resources.correct_icon;
                    txtLastGuess.ForeColor = Color.Green;
                    GameWon();
                }
                else
                {
                    lblResults[numGuess].ForeColor = Color.Red;
                    lblResults[numGuess].Text = guess > answer ? "Too high": "Too Low";
                    picResults[numGuess].Image = Properties.Resources.incorrect_icon;
                    txtLastGuess.ForeColor = Color.Red;
                    if (numGuess > 4) GameLost();
                }
                numGuess++;
            }
        }
    }
}
