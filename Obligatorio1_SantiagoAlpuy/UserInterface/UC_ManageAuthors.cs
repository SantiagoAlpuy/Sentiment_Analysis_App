using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManageAuthors : UserControl
    {
        IAuthorController authorController;
        private const int LOWER_AGE_LIMIT = 13;
        private const string EMPTY_STRING = "";


        public UC_ManageAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
            birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author() { Username = usernameBox.Text, Name = authorNameBox.Text, Surname = authorSurnameBox.Text, Born = birthDatePicker.Value };
                authorController.AddAuthor(author);
                MessageBox.Show("Autor agregado con éxito");
                usernameBox.Text = EMPTY_STRING;
                authorNameBox.Text = EMPTY_STRING;
                authorSurnameBox.Text = EMPTY_STRING;
                birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
