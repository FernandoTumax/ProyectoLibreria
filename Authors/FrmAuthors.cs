using Library2021GPD.Books;
using Library2021GPD.DBContexts;
using Library2021GPD.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library2021GPD.Authors
{
    public partial class FrmAuthors : Form
    {
        private LibraryDBContext DBContext = new LibraryDBContext();

        private List<Author> dsAuthors = null;
        public FrmAuthors()
        {
            InitializeComponent();
            DataUpdate();
        }

        public void DataUpdate()
        {
            this.dsAuthors = this.DBContext.Authors.ToList();
            this.dgwAuthors.DataSource = this.dsAuthors;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUpdateNewAuthor NewAuthor = new FrmUpdateNewAuthor(this);
            NewAuthor.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(this.dgwAuthors.CurrentRow.Selected)
            {
                Author author = this.dsAuthors[this.dgwAuthors.CurrentRow.Index];
                FrmUpdateNewAuthor UpdateAuthor = new FrmUpdateNewAuthor(author, this);
                UpdateAuthor.ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "¿Está seguro/a de eliminar este autor?", "Eliminar autor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == result)
            {
                Author delete = this.dsAuthors[this.dgwAuthors.CurrentRow.Index];
                this.DBContext.Authors.Remove(delete);
                this.DBContext.SaveChanges();
                DataUpdate();
            }
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            Author author = this.dsAuthors[this.dgwAuthors.CurrentRow.Index];
            FrmBooks Books = new FrmBooks(author);
            Books.ShowDialog();
        }
    }
}
