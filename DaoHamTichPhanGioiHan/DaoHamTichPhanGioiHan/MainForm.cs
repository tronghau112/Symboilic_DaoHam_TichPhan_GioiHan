using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DaoHamTichPhanGioiHan
{
    public partial class MainForm : Form
    {
        const string INFINITY_SYMBOL = "\u221E";
        const string SQRT_SYMBOL = "\u221A";
        const string CBRT_SYMBOL = "\u221B";
        const string SIGMA_SYMBOL = "\u2211";
        const string PI_SYMBOL = "\u220F";

        TextBox focusedTextBox;

        string document;
        string beginDoc = @"
            \documentclass[12pt,a4paper]{report}
            \usepackage{amssymb}
            \usepackage{amsmath}
            \usepackage[utf8]{inputenc}
            \usepackage[vietnamese]{babel}
            \usepackage[landscape,margin=0.5cm]{geometry}
            \begin{document}
            \pagestyle{empty}
            \fussy
            {\Huge";
        string endDoc = @"}\end{document}";

        StreamReader reader;
        StreamWriter writer;

        int displayResultOption = 0;
        int waitingTime = 30000;

        int imageIndex = 0;
        int imageCount = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        public string Solve(string input, int option)
        {
            writer = File.CreateText("input.mpl");
            writer.WriteLine("packageDir:= cat(currentdir(), kernelopts(dirsep) , \"DoAn.mla\"):");
            writer.WriteLine("march('open', packageDir):");        

            switch (option)
            {
                case 0: // display steps with explanation
                    writer.WriteLine("A := " + input + ";");
                    writer.WriteLine("S := GiaiChiTiet(A);");
                    writer.WriteLine("XuatLoiGiai(A, S, true);");
                    break;
                case 1: // display steps
                    writer.WriteLine("A := " + input + ";");
                    writer.WriteLine("S := GiaiChiTiet(A);");
                    writer.WriteLine("XuatLoiGiai(A, S, false);");
                    break;
                case 2: // display result only
                    string result = input.Replace("Diff", "diff")
                        .Replace("Int", "int")
                        .Replace("Limit", "limit");
                    writer.WriteLine("S := " + input + " = " + result + ";");
                    writer.WriteLine("XuatKetQua(S);");
                    break;
            }

            writer.Close();

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "solve.bat";
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            Process process = Process.Start(processInfo);
            process.WaitForExit();

            reader = File.OpenText("input.tex");
            string text = reader.ReadToEnd();
            reader.Close();

            return text;
        }

        public void DisplayText(string text)
        {
            try
            {
                document += text;
                document += endDoc;
                File.WriteAllText("input.tex", document);

                Process process = new Process();
                process.StartInfo.FileName = "display.bat";
                process.StartInfo.Arguments = "input";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit(waitingTime);

                string pattern = "output*.png";
                string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), pattern);
                if (dirs.Length == 0)
                {
                    resultPictureBox.Image = Properties.Resources.error;
                    imageIndex = -1;
                    imageCount = 0;
                }
                else if (dirs.Length == 1)
                {
                    resultPictureBox.ImageLocation = "output.png";
                    imageIndex = 0;
                    imageCount = 1;
                }
                else
                {
                    resultPictureBox.ImageLocation = "output-0.png";
                    imageIndex = 0;
                    imageCount = dirs.Length;
                }
                pageLabel.Text = (imageIndex + 1) + "/" + imageCount;
                previousButton.Enabled = false;
                if (imageCount <= 1)
                    nextButton.Enabled = false;
                else
                    nextButton.Enabled = true;

                document = beginDoc;
            }
            catch
            {
                resultPictureBox.Image = Properties.Resources.error;
            }
        }

        public void InsertSymbol(string symbol, int length)
        {
            if (focusedTextBox != null)
            {
                int selectionStart = focusedTextBox.SelectionStart;
                focusedTextBox.Text = focusedTextBox.Text.Insert(selectionStart, symbol);
                focusedTextBox.Focus();
                focusedTextBox.DeselectAll();
                focusedTextBox.SelectionStart = selectionStart + length;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            document = beginDoc;
            directionComboBox.SelectedIndex = 0;
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            string pattern = "output*.png";
            string[] dirs = Directory.GetFiles(Directory.GetCurrentDirectory(), pattern);
            foreach (string dir in dirs)
                File.Delete(dir);

            waitingLabel.Visible = true;

            string input = "";
            switch (mainTabControl.SelectedIndex)
            {
                case 0: // differential
                    if (diffTextBox2.Text == "")
                        input = "Diff(" + diffTextBox1.Text + ", op(indets(" + diffTextBox1.Text + ", name)))";
                    else
                        input = "Diff(" + diffTextBox1.Text + ", " + diffTextBox2.Text + ")";
                    break;
                case 1: // integral
                    input = "Int(";
                    switch (intTabControl.SelectedIndex)
                    {
                        case 0: // single integral
                            input += (intTextBox3.Text + ", " + intTextBox4.Text);
                            if (intTextBox1.Text != "" && intTextBox2.Text != "")
                                input += ("=" + intTextBox2.Text + ".." + intTextBox1.Text);
                            input += ")";
                                break;
                        case 1: // double integral
                            input += ("Int(" + int2TextBox5.Text + ", " + int2TextBox6.Text);
                            if (int2TextBox3.Text != "" && int2TextBox4.Text != "")
                                input += ("=" + int2TextBox4.Text + ".." + int2TextBox3.Text);
                            input += ("), " + int2TextBox7.Text);
                            if (int2TextBox1.Text != "" && int2TextBox2.Text != "")
                                input += ("=" + int2TextBox2.Text + ".." + int2TextBox1.Text);
                            input += ")";
                            break;
                        case 2: // triple integral
                            input += ("Int(Int(" + int3TextBox7.Text + ", " + int3TextBox8.Text);
                            if (int3TextBox5.Text != "" && int3TextBox6.Text != "")
                                input += ("=" + int3TextBox6.Text + ".." + int3TextBox5.Text);
                            input += ("), " + int3TextBox9.Text);
                            if (int3TextBox3.Text != "" && int3TextBox4.Text != "")
                                input += ("=" + int3TextBox4.Text + ".." + int3TextBox3.Text);
                            input += ("), " + int3TextBox10.Text);
                            if (int3TextBox1.Text != "" && int3TextBox2.Text != "")
                                input += ("=" + int3TextBox2.Text + ".." + int3TextBox1.Text);
                            input += ")";
                            break;
                    }
                    break;
                case 2: // limit
                    input = "Limit(" + limTextBox3.Text + ", " + limTextBox1.Text + " = " + limTextBox2.Text;
                    switch (directionComboBox.SelectedIndex)
                    {
                        case 0: // no direction
                            input += ")";
                            break;
                        case 1: // left direction
                            input += ", left)";
                            break;
                        case 2: // right direction
                            input += ", right)";
                            break;
                    }
                    break;
                case 3: // custom
                    input = customTextBox.Text;
                    break;
            }
            input = input.Replace(INFINITY_SYMBOL, "infinity")
                .Replace(SQRT_SYMBOL, "sqrt")
                .Replace(CBRT_SYMBOL, "cbrt")
                .Replace(PI_SYMBOL, "pi")
                .Replace(SIGMA_SYMBOL, "sum");
            string text = Solve(input, displayResultOption);
            DisplayText(text);

            waitingLabel.Visible = false;
        }

        private void directionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (directionComboBox.SelectedIndex)
            {
                case 0:
                    signLabel.Text = "";
                    break;
                case 1:
                    signLabel.Text = "-";
                    break;
                case 2:
                    signLabel.Text = "+";
                    break;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextBox = (TextBox)sender;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                solveButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void infinityButton_Click(object sender, EventArgs e)
        {
            noteLabel.Visible = false;
            InsertSymbol(INFINITY_SYMBOL, 1);
        }

        private void piButton_Click(object sender, EventArgs e)
        {
            noteLabel.Visible = false;
            InsertSymbol(PI_SYMBOL, 1);
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            noteLabel.Visible = true;
            noteLabel.Text = "Cú pháp : " + SQRT_SYMBOL + " (f)";
            InsertSymbol(SQRT_SYMBOL + "(", 2);
        }

        private void cbrtButton_Click(object sender, EventArgs e)
        {
            noteLabel.Visible = true;
            noteLabel.Text = "Cú pháp : " + CBRT_SYMBOL + " (f)";
            InsertSymbol(CBRT_SYMBOL + "(", 2);
        }     

        private void sigmaButton_Click(object sender, EventArgs e)
        {
            noteLabel.Visible = true;
            noteLabel.Text = "Cú pháp : " + SIGMA_SYMBOL + " (f, i = k .. n)";
            InsertSymbol(SIGMA_SYMBOL + "(", 2);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0:
                    diffTextBox1.Clear();
                    diffTextBox2.Text = "x";
                    break;
                case 1:
                    switch (intTabControl.SelectedIndex)
                    {
                        case 0:
                            intTextBox1.Clear();
                            intTextBox2.Clear();
                            intTextBox3.Clear();
                            intTextBox4.Text = "x";
                            break;
                        case 1:
                            int2TextBox1.Clear();
                            int2TextBox2.Clear();
                            int2TextBox3.Clear();
                            int2TextBox4.Clear();
                            int2TextBox5.Clear();
                            int2TextBox6.Text = "x";
                            int2TextBox7.Text = "y";
                            break;
                        case 2:
                            int3TextBox1.Clear();
                            int3TextBox2.Clear();
                            int3TextBox3.Clear();
                            int3TextBox4.Clear();
                            int3TextBox5.Clear();
                            int3TextBox6.Clear();
                            int3TextBox7.Clear();
                            int3TextBox8.Text = "x";
                            int3TextBox9.Text = "y";
                            int3TextBox10.Text = "z";
                            break;
                    }
                    break;
                case 2:
                    limTextBox1.Text = "x";
                    limTextBox2.Clear();
                    limTextBox3.Clear();
                    directionComboBox.SelectedIndex = 0;
                    break;
                case 3:
                    customTextBox.Clear();
                    break;
            }
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.displayResultOption = this.displayResultOption;
            settingsForm.waitingTime = this.waitingTime;
            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                this.displayResultOption = settingsForm.displayResultOption;
                this.waitingTime = settingsForm.waitingTime;
            }
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            if (imageIndex > 0)
            {
                imageIndex--;
                resultPictureBox.ImageLocation = "output-" + imageIndex + ".png";
                pageLabel.Text = (imageIndex + 1) + "/" + imageCount;
                if (imageIndex == 0)
                    previousButton.Enabled = false;
                nextButton.Enabled = true;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (imageIndex < imageCount - 1)
            {
                imageIndex++;
                resultPictureBox.ImageLocation = "output-" + imageIndex + ".png";
                pageLabel.Text = (imageIndex + 1) + "/" + imageCount;
                if (imageIndex == imageCount - 1)
                    nextButton.Enabled = false;
                previousButton.Enabled = true;
            }
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            new InformationForm().Show();
        }
    }
}
