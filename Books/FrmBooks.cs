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
using System.Data.Entity;

namespace Library2021GPD.Books
{
    public partial class FrmBooks : Form
    {
        private Author Author { get; set; }
        private LibraryDBContext DBContext = new LibraryDBContext();
        private List<Book> dsBooks = null;
        public FrmBooks(Author author)
        {
            InitializeComponent();
            this.Author = author;
            DataUpdate();
        }

        public void DataUpdate()
        {
            /*this.dsBooks = this.DBContext.Books.ToList();*/
            //this.dsBooks = this.DBContext.AuthorBooks.Where(x => x.AuthorId == this.Author.AuthorId).Include(x => x.Book).ToList();
            this.dsBooks = this.Author.Books.ToList();
            this.dgwBooks.DataSource = this.dsBooks;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "¿Esta seguro/a de eliminar el libro?", "Eliminar Libro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == result)
            {
                /*Book delete = this.dsBooks[this.dgwBooks.CurrentRow.Index];
                this.DBContext.Books.Remove(delete);
                this.DBContext.SaveChanges();
                DataUpdate();*/
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUpdateNewBook NewBook = new FrmUpdateNewBook(this, this.Author);
            NewBook.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(this.dgwBooks.CurrentRow.Selected)
            {
                /*Book book = this.dsBooks[this.dgwBooks.CurrentRow.Index];
                FrmUpdateNewBook UpdateBook = new FrmUpdateNewBook(book, this);
                UpdateBook.ShowDialog();*/
            }
        }
    }
}
