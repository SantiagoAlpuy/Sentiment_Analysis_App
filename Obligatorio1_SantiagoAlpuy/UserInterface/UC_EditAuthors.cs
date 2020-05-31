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

        private const string AUTHOR_MODIFIED = "El usuario {0} ha sido modificado con éxito.";

        public UC_EditAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
            repository = Repository.Instance;

            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            autorComboBox.Items.Clear();
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
                EnableFields();
            }
            else
                ClearFields();
        }

        private void EnableFields()
        {
            authorNameBox.Enabled = true;
            authorSurnameBox.Enabled = true;
            birthDatePicker.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author authorToBeModified = authorController.ObtainAuthorByUsername(usernameBox.Text);
                Author changedAuthor = authorToBeModified;
                changedAuthor.Name = authorNameBox.Text;
                changedAuthor.Surname = authorSurnameBox.Text;
                changedAuthor.Born = birthDatePicker.Value;
                authorController.ModifyAuthor(authorToBeModified, changedAuthor);
                MessageBox.Show(String.Format(AUTHOR_MODIFIED, usernameBox.Text));
                UpdateComboBox();
                ClearFields();
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(AUTHOR_MODIFIED);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ClearFields()
        {
            authorNameBox.Enabled = false;
            authorSurnameBox.Enabled = false;
            birthDatePicker.Enabled = false;
            usernameBox.Text = "";
            authorNameBox.Text = "";
            authorSurnameBox.Text = "";
            birthDatePicker.Value = DateTime.Now;
        }
    }
}
