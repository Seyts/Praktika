using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {


            DataBank.Text1 = textBox2.Text;
            DataBank.Text2 = textBox3.Text;
            DataBank.Text3 = textBox4.Text;
            DataBank.Text4 = textBox5.Text;

            string ConnectionString = @"Data Source=HOME-PC\SQL_EXPRESS;Initial Catalog=bd;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO praktika (job,materiali,FIO,Oplata) values (@job,@materiali,@FIO,@Oplata)");
                command.Connection = conn;
                
                command.Parameters.AddWithValue("job", textBox2.Text);
                command.Parameters.AddWithValue("materiali", textBox3.Text);
                command.Parameters.AddWithValue("FIO", textBox4.Text);
                command.Parameters.AddWithValue("Oplata", textBox5.Text);
                command.ExecuteNonQuery();

                

            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bdDataSet.praktika". При необходимости она может быть перемещена или удалена.
            this.praktikaTableAdapter.Fill(this.bdDataSet.praktika);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form main = new Form2();
            main.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.tsx";
            saveFile1.Filter = "Test files|*.tsx";
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                saveFile1.FileName.Length > 0)
            {
                using (StreamWriter sw = new StreamWriter(saveFile1.FileName, true))
                {
                    sw.WriteLine("Задание"+ "\n Вид Работы: " + textBox2.Text + "\n Расход материалов: " + textBox3.Text + "\nРаботник: " + textBox4.Text + "\nОплата: " + textBox5.Text);
                    sw.Close();
                }
            }
        }
    }
}
