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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

        }
        int lCount = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            lCount++;
            Label lbl = new Label();
            lbl.Text = "Задание" + lCount.ToString() + "\n Вид Работы:" + DataBank.Text1 + "\n Расход материалов:" + DataBank.Text2 + "\nРаботник:" + DataBank.Text3 + "\nОплата:" + DataBank.Text4;
            lbl.Location = new Point(10, 10 + 100 * (lCount - 1));
            lbl.Size = new System.Drawing.Size(300, 100);
            this.Controls.Add(lbl);

            

        }
    }
}
