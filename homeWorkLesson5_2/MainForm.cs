using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homeWorkLesson5_2
{
    public partial class MainForm : Form
    {
        Model1Container context;

        public MainForm()
        {
            InitializeComponent();
            context = new Model1Container();
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            context.CarSet.Load();
            dgView.DataSource = context.CarSet.Local.ToBindingList();
        }
    }
}
