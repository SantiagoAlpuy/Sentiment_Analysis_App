using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManageAuthors : UserControl
    {
        IAuthorController authorController;
        Repository repository;
        private const int LOWER_AGE_LIMIT = 13;
        private const string EMPTY_STRING = "";
        private const string AUTHOR_ADDED = "Autor agregado con éxito";
        private const string FIRST_COLUMN_NAME = "Usuario";
        private const string SECOND_COLUMN_NAME = "Nombre";
        private const string THIRD_COLUMN_NAME = "Apellido";
        private const string FOURTH_COLUMN_NAME = "Nacimiento";


        public UC_ManageAuthors()
        {
            InitializeComponent();
            authorController = new AuthorController();
            repository = Repository.Instance;
            birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);
            this.authorsDataGrid.DataSource = repository.Authors.ToList();
            authorsDataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            authorsDataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            authorsDataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            authorsDataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author() { Username = usernameBox.Text, Name = authorNameBox.Text, Surname = authorSurnameBox.Text, Born = birthDatePicker.Value };
                authorController.AddAuthor(author);
                MessageBox.Show(AUTHOR_ADDED);
                usernameBox.Text = EMPTY_STRING;
                authorNameBox.Text = EMPTY_STRING;
                authorSurnameBox.Text = EMPTY_STRING;
                birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);
                this.authorsDataGrid.DataSource = repository.Authors.ToList();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
