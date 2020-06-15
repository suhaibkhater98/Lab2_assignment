using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;



namespace Post_7
{
    public partial class Form1 : Form
    {
        public static linkDataContext db = new linkDataContext();
        public static string name, department, project;
        public Form1()
        {
            InitializeComponent();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = from item in db.Employees
                    from item2 in db.Departments
                    where item.dep_no == item2.Dep_Number
                    select new
                    {
                        item.ssn,
                        item.first_name,
                        item.last_name,
                        item.salary,
                        item2.Dep_Name
                    };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = r.ToArray();
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = from item in db.Departments
                    from item2 in db.Employees
                    where item.Manager_ssn == item2.ssn
                    select new
                    {
                       
                        item.Dep_Number,
                        item2.first_name,
                        item2.last_name,
                        item.Dep_Name,
                    };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = r.ToArray();
        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var r = from item in db.Projects
                    from item2 in db.Departments
                    where item.D_NO == item2.Dep_Number
                    select new
                    {
                        item.P_Name,
                        item.P_Number,
                        item2.Dep_Name
                    };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = r.ToArray();
        }

        private void insertSSNForEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            textBox1.Text = name;
            textBox2.Text = department;
            textBox3.Text = project;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private  void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void departmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 form1 = new Form3();
            form1.ShowDialog();
            var r = from item in db.Departments
                    select new
                    {
                        item.Dep_Name,
                        item.Dep_Number,
                        item.Manager_ssn
                    };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = r.ToArray();
        }

        private void projectToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 form3 = new Form4();
            form3.ShowDialog();
            var r = from item in db.Works_Ons
                    select new
                    {
                        item.E_SSN,
                        item.Hours,
                        item.P_No
                    };
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = r.ToArray();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private  void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
