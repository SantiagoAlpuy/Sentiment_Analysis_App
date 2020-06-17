using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.IControllers;
using BusinessLogic.Controllers;

namespace UserInterface
{
    public partial class UC_EditAuthors : UserControl
    {
        IAuthorController authorController;

        private const string AUTHOR_MODIFIED = "El usuario {0} ha sido modificado con éxito.";

        public UC_EditAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
            UpdateComboBox();
        }

        private void UpdateComboBox()
        {
            autorComboBox.Items.Clear();
            autorComboBox.Items.Add("");
            ICollection<Author> authors = authorController.GetAll();
            foreach (Author author in authors)
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
            usernameBox.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author authorToBeModified = authorController.ObtainAuthorByUsername(autorComboBox.Text);
                Author changedAuthor = new Author { Username = authorToBeModified.Username, Name = authorToBeModified.Name,
                Surname = authorToBeModified.Surname, Born = authorToBeModified.Born};
                changedAuthor.Username = usernameBox.Text;
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
            usernameBox.Enabled = false;
            usernameBox.Text = "";
            authorNameBox.Text = "";
            authorSurnameBox.Text = "";
            birthDatePicker.Value = DateTime.Now;
        }
    }
}
