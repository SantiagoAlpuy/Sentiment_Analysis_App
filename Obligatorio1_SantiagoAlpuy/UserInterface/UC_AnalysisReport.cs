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

namespace UserInterface
{
    public partial class UC_AnalysisReport : UserControl
    {
        Repository repository;
        private const string FIRST_COLUMN_NAME = "Comentario";
        private const string SECOND_COLUMN_NAME = "Fecha";
        private const string THIRD_COLUMN_NAME = "Entidad";
        private const string FOURTH_COLUMN_NAME = "Categoría";
        public UC_AnalysisReport()
        {
            InitializeComponent();
            repository = Repository.Instance;
            LoadDataGridPhrases();
            dataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;

        }

        private void LoadDataGridPhrases()
        {
            this.dataGrid.DataSource = repository.Phrases.ToList();
        }
    }
}
