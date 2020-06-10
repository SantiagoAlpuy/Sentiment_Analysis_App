using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.IControllers;
using BusinessLogic.Controllers;
using BusinessLogic;

namespace UserInterface
{
    public partial class UC_AuthorReport : UserControl
    {
        IAuthorController authorController;

        private const string OPTION_A = "1- Porcentaje de frases positivas por cada autor";
        private const string OPTION_B = "2- Porcentaje de frases negativas por cada autor";
        private const string OPTION_C = "3- Cantidad de entidades mencionadas por cada autor";
        private const string OPTION_D = "4- Promedio diario de frases por cada autor";

        public UC_AuthorReport()
        {
            InitializeComponent();
            authorController = new AuthorController();
            InitializeCriterionComboBox();
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

        private void CreateDataGrid(string lastColumnName)
        {
            this.dataGrid.ColumnCount = 4;
            this.dataGrid.ColumnHeadersVisible = true;
            this.dataGrid.Columns[0].Name = "Nombre de Usuario";
            this.dataGrid.Columns[1].Name = "Nombre";
            this.dataGrid.Columns[2].Name = "Apellido";
            this.dataGrid.Columns[3].Name = lastColumnName;
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
                this.dataGrid.DataSource = null;
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
                int totalNumberPhrases = author.Phrases.Count();
                int totalNumberByCategory = author.Phrases.Where(x => x.Category == category).Count();
                int percentage = totalNumberByCategory * 100 / totalNumberPhrases;

                string[] row = new string[] { author.Username, author.Name, author.Surname, percentage.ToString() };
                this.dataGrid.Rows.Add(row);
            }
        }

        private void CalculateAmmountOfEntities(ICollection<Author> authors)
        {
            CreateDataGrid("Cantidad de Entidades");
            foreach (Author author in authors)
            {
                HashSet<string> entities = new HashSet<string>();
                foreach (Phrase phrase in author.Phrases)
                {
                    if (phrase.Entity != "")
                        entities.Add(phrase.Entity);
                }
                string[] row = new string[] { author.Username, author.Name, author.Surname, entities.Count().ToString() };
                this.dataGrid.Rows.Add(row);

            }
        }

        private void CalculatePostsMean(ICollection<Author> authors)
        {
            CreateDataGrid("Promedio Diario de Comentarios");
            foreach (Author author in authors)
            {
                string[] row;
                if (author.Phrases.Count > 0)
                {
                    int totalNumberPhrases = author.Phrases.Count();
                    DateTime firstPostDate = author.Phrases.Min(x => x.Date);
                    double totalDays = Math.Ceiling((DateTime.Now - firstPostDate).TotalDays);
                    double mean = totalNumberPhrases / totalDays;
                    row = new string[] { author.Username, author.Name, author.Surname, mean.ToString() };
                }
                else
                {
                    row = new string[] { author.Username, author.Name, author.Surname, "0" };
                }

                this.dataGrid.Rows.Add(row);
            }
        }

        private void btnFilterReport_Click(object sender, EventArgs e)
        {
            if (criterionComboBox.SelectedItem.ToString() != "")
            {
                InitializeDataGridOptionA(criterionComboBox.SelectedItem.ToString());
            }
        }
    }
}
