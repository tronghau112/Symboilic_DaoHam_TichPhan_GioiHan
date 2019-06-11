using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaoHamTichPhanGioiHan
{
    public partial class SettingsForm : Form
    {
        public int displayResultOption = 0;
        public int waitingTime = 30000;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            switch (displayResultOption)
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
            }
            numericUpDown1.Value = (waitingTime / 1000);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                displayResultOption = 0;
            else if (radioButton2.Checked)
                displayResultOption = 1;
            else
                displayResultOption = 2;

            waitingTime = (int)numericUpDown1.Value * 1000;

            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
