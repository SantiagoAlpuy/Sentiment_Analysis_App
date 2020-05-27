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
        public UC_ManageAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author() { Username = usernameBox.Text, Name = authorNameBox.Text, Surname = authorSurnameBox.Text, Born = birthDatePicker.Value };
                authorController.AddAuthor(author);
                MessageBox.Show("Autor agregado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
