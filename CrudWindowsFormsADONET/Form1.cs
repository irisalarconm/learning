using System.Windows.Forms;

namespace CrudWindowsFormsADONET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            PeopleDb oPeopleDb = new PeopleDb();
            dataGridView1.DataSource = oPeopleDb.Get();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNew frm = new FormNew();
            frm.ShowDialog();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                FormNew frmEdit = new FormNew(Id);
                frmEdit.ShowDialog();
                Refresh();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //delete
        }
        // region Helper
        private int GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return 0;
            }
            
        }
        //endregion
        

       
    }
}