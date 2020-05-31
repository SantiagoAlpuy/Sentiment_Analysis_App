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
using BusinessLogic.IControllers;
using BusinessLogic.Controllers;

namespace UserInterface
{
    public partial class UC_EditAuthors : UserControl
    {
        Repository repository;
        IAuthorController authorController;

        private const string INVALID_AUTHOR = "Elija un autor válido.";

        public UC_EditAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
            repository = Repository.Instance;

            autorComboBox.Items.Add("");
            foreach (Author author in repository.Authors)
            {
                autorComboBox.Items.Add(author.Username);
            }
        }

        private void autorComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (autorComboBox.Text != "")
            {
                Author selectedAuthor = authorController.ObtainAuthorByUsername(autorComboBox.Text);
                usernameBox.Text = selectedAuthor.Username;
                authorNameBox.Text = selectedAuthor.Name;
                authorSurnameBox.Text = selectedAuthor.Surname;
                birthDatePicker.Value = selectedAuthor.Born;
                authorNameBox.Enabled = true;
                authorSurnameBox.Enabled = true;
                birthDatePicker.Enabled = true;
            }
            else
            {
                authorNameBox.Enabled = false;
                authorSurnameBox.Enabled = false;
                birthDatePicker.Enabled = false;
                usernameBox.Text = "";
                authorNameBox.Text = "";
                authorSurnameBox.Text = "";
                birthDatePicker.Value = DateTime.Now;
                MessageBox.Show(INVALID_AUTHOR);
            }
        }
    }
}
