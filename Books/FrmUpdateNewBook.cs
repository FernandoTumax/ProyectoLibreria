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
    public partial class FrmUpdateNewBook : Form
    {
        private FrmBooks Books { get; set; }
        private Book Book { get; set; }

        private Author Author { get; set; }

        private AuthorBook AuthorBook { get; set; }

        private LibraryDBContext DBContext = new LibraryDBContext();
        public FrmUpdateNewBook(FrmBooks books, Author author)
        {
            InitializeComponent();
            this.Books = books;
            this.Author = author;
        }

        public FrmUpdateNewBook(Book book, FrmBooks books)
        {
            InitializeComponent();
            this.Books = books;
            this.Book = book;
            this.txtTitle.Text = this.Book.Title;
            this.dtpPublication.Value = this.Book.Publication;
            this.txtPrice.Text = this.Book.Price.ToString();
            this.txtStock.Text = this.Book.Stock.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.Book == null)
            {
                if(this.txtTitle.Text == "" || this.txtPrice.Text == "" || this.txtStock.Text == "")
                {
                    MessageBox.Show(this, "Existen campos vacios, por favor rellene los campos vacios", "Crear Curso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Book = new Book();
                    ExecuteQuery("new", this.Book);
                }
            }
            else
            {
                ExecuteQuery("update", this.Book);
            }
            this.Close();
        }

        private void ExecuteQuery(string type, Book book)
        {
            this.Book.Title = this.txtTitle.Text;
            this.Book.Publication = this.dtpPublication.Value;
            this.Book.Price = double.Parse(this.txtPrice.Text);
            this.Book.Stock = int.Parse(this.txtStock.Text);
            if (type.Equals("new"))
            {
                this.Author.Books.Add(this.Book);
                this.DBContext.SaveChanges();
                /*this.DBContext.Books.Add(this.Book);
                this.DBContext.SaveChanges();
                MessageBox.Show(this.Author.Books.ToList().Count().ToString());*/
                //var lastbook = this.DBContext.Books;
                /*MessageBox.Show(lastbook.Last().BookId.ToString());*/
                /*this.AuthorBook.BookId = lastbook.Last().BookId;
                this.AuthorBook.AuthorId = this.Author.AuthorId;
                this.DBContext.AuthorBooks.Add(this.AuthorBook);
                this.DBContext.SaveChanges();*/

            }
            else if (type.Equals("update"))
            {
                this.DBContext.Entry(this.Book).State = EntityState.Modified;
                this.DBContext.SaveChanges();

            }
            
            this.Books.DataUpdate();
        }

        
    }
}
