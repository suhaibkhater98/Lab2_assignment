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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var r = from item in Form1.db.Projects
                        where item.P_Number == Convert.ToInt32(textBox1.Text)
                        select item;
                if (r.Count() == 1)
                {
                    foreach (var item in r)
                    {
                        Form1.db.Projects.DeleteOnSubmit(item);
                        Form1.db.SubmitChanges();
                        MessageBox.Show("Deleted From Project .");
                       
                    }

                    var r1 = from item1 in Form1.db.Works_Ons
                             where item1.P_No == Convert.ToInt32(textBox1.Text)
                             select item1;
                    if (r1.Count() >= 1)
                    {
                        foreach (var item2 in r1)
                        {
                            Form1.db.Works_Ons.DeleteOnSubmit(item2);
                            Form1.db.SubmitChanges();
                           
                        }
                        MessageBox.Show("Deleted From WorksOn .");
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("No Project.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Found");
            }
        }
    }
}
