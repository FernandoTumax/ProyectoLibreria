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

namespace Library2021GPD.Authors
{
    public partial class FrmUpdateNewAuthor : Form
    {
        private FrmAuthors Authors { get; set; }
        private Author Author { get; set; }

        private LibraryDBContext DBContext = new LibraryDBContext();
        public FrmUpdateNewAuthor(FrmAuthors authors)
        {
            InitializeComponent();
            this.Authors = authors;
        }

        public FrmUpdateNewAuthor(Author author, FrmAuthors authors)
        {
            InitializeComponent();
            this.Authors = authors;
            this.Author = author;
            this.txtFirstname.Text = this.Author.Firstname;
            this.txtLastname.Text = this.Author.Lastname;
            this.txtEmail.Text = this.Author.Email;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(this.Author == null)
            {
                if(this.txtFirstname.Text == "" || this.txtLastname.Text == "" || this.txtEmail.Text == "")
                {
                    MessageBox.Show(this, "Existen campos vacios, por favor rellene los campos vacios", "Crear Autores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Author = new Author();
                    ExecuteQuery("new", this.Author);
                }
            }
            else
            {
                ExecuteQuery("update", this.Author);
            }
            this.Close();
        }

        private void ExecuteQuery(string type, Author author)
        {
            this.Author.Firstname = this.txtFirstname.Text;
            this.Author.Lastname = this.txtLastname.Text;
            this.Author.Email = this.txtEmail.Text;
            if(type.Equals("new"))
            {
                this.DBContext.Authors.Add(this.Author);
            }
            else if(type.Equals("update"))
            {
                this.DBContext.Entry(this.Author).State = EntityState.Modified;
            }
            this.DBContext.SaveChanges();
            this.Authors.DataUpdate();
        }
    }
}
