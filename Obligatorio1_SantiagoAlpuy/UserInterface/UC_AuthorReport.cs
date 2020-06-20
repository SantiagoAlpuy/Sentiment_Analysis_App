using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic.IControllers;
using BusinessLogic.Controllers;
using BusinessLogic;
using System.ComponentModel;

namespace UserInterface
{
    public partial class UC_AuthorReport : UserControl
    {
        IAuthorController authorController;

        private const string OPTION_A = "1- Porcentaje de frases positivas por cada autor";
        private const string OPTION_B = "2- Porcentaje de frases negativas por cada autor";
        private const string OPTION_C = "3- Cantidad de entidades mencionadas por cada autor";
        private const string OPTION_D = "4- Promedio diario de frases por cada autor";
        private const string ASCENDING = "Ascendente";
        private const string DESCENDING = "Descendente";
        private const int QUANTITY_COLUMNS = 4;

        public UC_AuthorReport()
        {
            InitializeComponent();
            authorController = new AuthorController();
            InitializeCriterionComboBox();
            InitializeSortingComboBox();
        }

        private void InitializeCriterionComboBox()
        {
            criterionComboBox.Items.Clear();
            criterionComboBox.Items.Add("");
            criterionComboBox.Items.Add(OPTION_A);
            criterionComboBox.Items.Add(OPTION_B);
            criterionComboBox.Items.Add(OPTION_C);
            criterionComboBox.Items.Add(OPTION_D);
        }

        private void InitializeSortingComboBox()
        {
            sortComboBox.Items.Clear();
            sortComboBox.Items.Add(ASCENDING);
            sortComboBox.Items.Add(DESCENDING);
            sortComboBox.SelectedIndex = 0;
        }

        private void SortDataGrid()
        {
            ListSortDirection sortDirection;
            if (sortComboBox.Text == ASCENDING)
                sortDirection = ListSortDirection.Ascending;
            else
                sortDirection = ListSortDirection.Descending;
            this.dataGrid.Sort(this.dataGrid.Columns[QUANTITY_COLUMNS -1], sortDirection);
        }

        private void CreateDataGrid(string lastColumnName)
        {
            this.dataGrid.ColumnCount = QUANTITY_COLUMNS;
            this.dataGrid.ColumnHeadersVisible = true;
            this.dataGrid.Columns[0].Name = "Nombre de Usuario";
            this.dataGrid.Columns[1].Name = "Nombre";
            this.dataGrid.Columns[2].Name = "Apellido";
            this.dataGrid.Columns[3].Name = lastColumnName;
            this.dataGrid.Columns[3].ValueType = typeof(double);
            this.dataGrid.ColumnHeadersVisible = true;
            ClearRows();
        }

        private void InitializeDataGridOptionA(string criterion)
        {
            ICollection<Author> authors = authorController.GetAllAuthorsWithInclude();

            if (criterion == OPTION_A)
                CalculatePercentage(authors, CategoryType.Positiva);
            else if (criterion == OPTION_B)
            {
                CalculatePercentage(authors, CategoryType.Negativa);
            }
            else if (criterion == OPTION_C)
            {
                CalculateAmmountOfEntities(authors);
            }
            else if (criterion == OPTION_D)
            {
                CalculatePostsMean(authors);
            }
            else
            {
                this.dataGrid.ColumnHeadersVisible = false;
                ClearRows();
            }
        }

        private void ClearRows()
        {
            this.dataGrid.Rows.Clear();
        }

        private void CalculatePercentage(ICollection<Author> authors, CategoryType category)
        {
            CreateDataGrid("Porcentaje");
            foreach (Author author in authors)
            {
                int percentage = author.CalculatePercentage(category);

                object[] row = new object[] { author.Username, author.Name, author.Surname, percentage };
                this.dataGrid.Rows.Add(row);
            }
            SortDataGrid();
        }

        private void CalculateAmmountOfEntities(ICollection<Author> authors)
        {
            CreateDataGrid("Cantidad de Entidades");
            foreach (Author author in authors)
            {
                int entitiesNumber = author.CalculateEntitiesInPhrases();

                object[] row = new object[] { author.Username, author.Name, author.Surname, entitiesNumber };
                this.dataGrid.Rows.Add(row);
            }
            SortDataGrid();
        }

        private void CalculatePostsMean(ICollection<Author> authors)
        {
            CreateDataGrid("Promedio Diario de Comentarios");
            foreach (Author author in authors)
            {
                double mean = author.CalculateMeanOfPhrases();
                object[] row = new object[] { author.Username, author.Name, author.Surname, mean };

                this.dataGrid.Rows.Add(row);
            }
            SortDataGrid();
        }

        private void btnFilterReport_Click(object sender, EventArgs e)
        {
            InitializeDataGridOptionA(criterionComboBox.Text);
        }
    }
}
