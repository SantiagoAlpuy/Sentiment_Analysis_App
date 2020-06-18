using System.Windows.Forms;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_AnalysisReport : UserControl
    {
        IPhraseController phraseController;
        private const string FIRST_COLUMN_NAME = "Comentario";
        private const string SECOND_COLUMN_NAME = "Fecha";
        private const string THIRD_COLUMN_NAME = "Entidad";
        private const string FOURTH_COLUMN_NAME = "Categoría";
        private const string FIFTH_COLUMN_NAME = "Autor";
        public UC_AnalysisReport()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            LoadDataGridPhrases();
            InitializeDataGrid();
        }

        private void LoadDataGridPhrases()
        {
            this.dataGrid.DataSource = phraseController.GetAllEntitiesWithIncludes("Author");
        }

        private void InitializeDataGrid()
        {
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[1].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = FIFTH_COLUMN_NAME;
        }
    }
}
