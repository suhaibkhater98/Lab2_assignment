using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Post_7
{
    public partial class Form3 : Form
    {
        linkDataContext db = new linkDataContext();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            foreach (var x in db.Employees)
            {
                comboBox1.Items.Add(x.ssn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Department dd = new Department();

            dd.Dep_Name = textBox1.Text;
            dd.Manager_StartDate = dateTimePicker1.Value;
            dd.Manager_ssn = Convert.ToInt32(comboBox1.SelectedItem);
            Form1.db.Departments.InsertOnSubmit(dd);
            Form1.db.SubmitChanges();
            MessageBox.Show("Insert");
            Close();

        }
    }
}
