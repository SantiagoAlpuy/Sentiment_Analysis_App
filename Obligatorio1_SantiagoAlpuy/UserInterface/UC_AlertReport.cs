using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_AlertReport : UserControl
    {
        AlertAController alertController;

        private const string FIRST_COLUMN_NAME = "Entidad";
        private const string SECOND_COLUMN_NAME = "Categoría";
        private const string THIRD_COLUMN_NAME = "Posts";
        private const string FOURTH_COLUMN_NAME = "Días";
        private const string FIFTH_COLUMN_NAME = "Horas";
        private const string SIXTH_COLUMN_NAME = "Activada";
        public UC_AlertReport()
        {
            InitializeComponent();
            alertController = new AlertAController();
            LoadDataGridAlerts();
            InitializeDataGrid();
        }

        private void InitializeDataGrid()
        {
            dataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = SIXTH_COLUMN_NAME;
        }

        private void LoadDataGridAlerts()
        {
            this.dataGrid.DataSource = alertController.GetAllEntities();
        }
    }
}
