using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudWindowsFormsADONET
{
    public partial class FormNew : Form
    {
        private int? Id;
        public FormNew(int? id = null)
        {
            InitializeComponent();
            this.Id = id;

            if(this.Id != null){
                LoadData();
            }
               
        }

        private void LoadData()
        {
            PeopleDb oPeopleDB = new PeopleDb();
            People people = oPeopleDB.Get(Id);
            TxtName.Text = people.Name;
            TxtAge.Text = people.Age.ToString();


        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            PeopleDb oPeopleDb = new PeopleDb();

            try
            {
                if (Id == null)
                {
                    oPeopleDb.Add(TxtName.Text, int.Parse(TxtAge.Text));
                }
                else
                {
                    oPeopleDb.Update(TxtName.Text, int.Parse(TxtAge.Text), (int)Id);
                }
                
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrió un error" + ex.Message);
            }
        }
    }
}
