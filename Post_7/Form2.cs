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
    public partial class Form2 : Form
    {
        linkDataContext db = new linkDataContext();
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text != null)
            {
                int id;
                
                    id = Convert.ToInt32(textBox1.Text);
                    var r = from item in db.Employees
                            from item1 in db.Departments
                            where item.ssn == id
                            where item1.Dep_Number == item.dep_no                            
                            select new
                            {
                                item.first_name,
                                item.last_name,
                                item1.Dep_Name
                            };
                    if(r.Any())
                    {
                    Form1.name = r.First().first_name.ToString()+"  "+ r.First().last_name.ToString();
                    Form1.department = r.First().Dep_Name.ToString();
                    var x = from item1 in db.Works_Ons
                            from item3 in db.Projects
                            where item1.E_SSN == id
                            where item3.P_Number == item1.P_No
                            select item3.P_Name;
                    
                     foreach(var item in x)       
                    Form1.project += (item.ToString()+"\n");
                    Close();
                    }
                    else
                    {
                        MessageBox.Show("Not Found .");
                    }
                
            }
            else
            {
                MessageBox.Show("Inter A Number .");
            }
        }
    }
}
