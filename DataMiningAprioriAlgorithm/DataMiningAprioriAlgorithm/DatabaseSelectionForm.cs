using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataMiningAprioriAlgorithm
{
    public partial class DatabaseSelectionForm : Form
    {
        static List<String> database = new List<string>();
        public DatabaseSelectionForm()
        {
            InitializeComponent();
        }

        private void DatabaseSelectionForm_Load(object sender, EventArgs e)
        {
            
            database.Add("Electronic Store");
            database.Add("Music Store");
            database.Add("Apple Store");
            database.Add("Cycle Store");
            database.Add("Baby Store");



            for(int i=0;i<database.Count;i++)
            comboBox1.Items.Add(database[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value = (int)comboBox1.SelectedIndex;
            String valuedatabase = database.ElementAt(value);
            int support = Convert.ToInt32(textBox1.Text);
            int confidence = Convert.ToInt32(textBox2.Text);
            Form1 form1 = new Form1(valuedatabase,support,confidence);
            form1.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

    }
}
