using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library2021GPD.Authors;
using Library2021GPD.Books;

namespace Library2021GPD
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void autoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAuthors Authors = new FrmAuthors();
            Authors.ShowDialog();
        }
    }
}
