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
    public partial class InformationForm : Form
    {
        public InformationForm()
        {
            InitializeComponent();
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            listView1.Items.Add(new ListViewItem(new string[] { "", "\u220F hoặc pi" }, 0));
            listView1.Items.Add(new ListViewItem(new string[] { "", "\u221E hoặc infinity" }, 1));
            listView1.Items.Add(new ListViewItem(new string[] { "", "e" }, 2));
            listView1.Items.Add(new ListViewItem(new string[] { "", "a^b" }, 3));
            listView1.Items.Add(new ListViewItem(new string[] { "", "\u221A(a) hoặc sqrt(a)" }, 4));
            listView1.Items.Add(new ListViewItem(new string[] { "", "\u221B(a) hoặc cbrt(a) hoặc a^(1/3)" }, 5));
            listView1.Items.Add(new ListViewItem(new string[] { "", "a^(1/n)" }, 6));
            listView1.Items.Add(new ListViewItem(new string[] { "", "abs(a)" }, 7));
            listView1.Items.Add(new ListViewItem(new string[] { "", "a!" }, 8));
            listView1.Items.Add(new ListViewItem(new string[] { "", "\u2211(f,i=k..n) hoặc sum(f,i=k..n)" }, 9));
            listView1.Items.Add(new ListViewItem(new string[] { "", "product(f,i=k..n)" }, 10));
            listView1.Items.Add(new ListViewItem(new string[] { "", "ln(a)" }, 11));
            listView1.Items.Add(new ListViewItem(new string[] { "", "log[b](a)" }, 12));
            listView1.Items.Add(new ListViewItem(new string[] { "", "sin(a)" }, 13));
            listView1.Items.Add(new ListViewItem(new string[] { "", "cos(a)" }, 14));
            listView1.Items.Add(new ListViewItem(new string[] { "", "tan(a)" }, 15));
            listView1.Items.Add(new ListViewItem(new string[] { "", "diff(f,x)" }, 16));
            listView1.Items.Add(new ListViewItem(new string[] { "", "int(f,x)" }, 17));
            listView1.Items.Add(new ListViewItem(new string[] { "", "int(f,x=a..b)" }, 18));
            listView1.Items.Add(new ListViewItem(new string[] { "", "limit(f,x=a)" }, 19));
        }
    }
}
