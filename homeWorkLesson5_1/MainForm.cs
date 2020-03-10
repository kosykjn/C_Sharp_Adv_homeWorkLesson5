using System.Data.Entity;
using System.Windows.Forms;

namespace homeWorkLesson5_1
{
    public partial class MainForm : Form
    {
        MyDatabaseEntities context;

        public MainForm()
        {
            InitializeComponent();
            context = new MyDatabaseEntities();
        }

        private void btnShowData_Click(object sender, System.EventArgs e)
        {
            context.MyTable.Load();
            dgView.DataSource = context.MyTable.Local.ToBindingList();
        }
    }
}
