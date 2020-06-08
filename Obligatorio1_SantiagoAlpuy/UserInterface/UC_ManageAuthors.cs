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
        private const int LOWER_AGE_LIMIT = 13;
        private const string EMPTY_STRING = "";
        private const string AUTHOR_ADDED = "Autor agregado con éxito";
        private const string FIRST_COLUMN_NAME = "Usuario";
        private const string SECOND_COLUMN_NAME = "Nombre";
        private const string THIRD_COLUMN_NAME = "Apellido";
        private const string FOURTH_COLUMN_NAME = "Nacimiento";
        FlowLayoutPanel PrincipalPanel;

        public UC_ManageAuthors(FlowLayoutPanel panel)
        {
            PrincipalPanel = panel;
            InitializeComponent();
            authorController = new AuthorController();
            birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);
            this.authorsDataGrid.DataSource = authorController.GetAll();
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            authorsDataGrid.Columns[0].Visible = false;
            authorsDataGrid.Columns[1].HeaderText = FIRST_COLUMN_NAME;
            authorsDataGrid.Columns[2].HeaderText = SECOND_COLUMN_NAME;
            authorsDataGrid.Columns[3].HeaderText = THIRD_COLUMN_NAME;
            authorsDataGrid.Columns[4].HeaderText = FOURTH_COLUMN_NAME;
            authorsDataGrid.Columns[5].Visible = false;
            authorsDataGrid.Columns[6].Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Author author = new Author() { Username = usernameBox.Text, Name = authorNameBox.Text, Surname = authorSurnameBox.Text, Born = birthDatePicker.Value };
                authorController.AddAuthor(author);
                ReactToSuccessfulAddition();
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

        private void ReactToSuccessfulAddition()
        {
            MessageBox.Show(AUTHOR_ADDED);
            usernameBox.Text = EMPTY_STRING;
            authorNameBox.Text = EMPTY_STRING;
            authorSurnameBox.Text = EMPTY_STRING;
            birthDatePicker.Value = DateTime.Now.AddYears(-LOWER_AGE_LIMIT);
            this.authorsDataGrid.DataSource = authorController.GetAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in authorsDataGrid.SelectedRows)
            {
                authorController.RemoveAuthor(row.Cells[1].Value.ToString());
            }
            this.authorsDataGrid.DataSource = authorController.GetAll();
        }

        private void editBox_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_EditAuthors());
        }
    }
}
