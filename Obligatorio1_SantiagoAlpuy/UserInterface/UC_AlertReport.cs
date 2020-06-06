using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_AlertReport : UserControl
    {
        AlertAController alertAController;
        AlertBController alertBController;

        private const string FIRST_COLUMN_NAME = "Entidad";
        private const string SECOND_COLUMN_NAME = "Categoría";
        private const string THIRD_COLUMN_NAME = "Posts";
        private const string FOURTH_COLUMN_NAME = "Días";
        private const string FIFTH_COLUMN_NAME = "Horas";
        private const string SIXTH_COLUMN_NAME = "Activada";
        private const string ALERT_A = "Alarma A";
        private const string ALERT_B = "Alarma B";
        public UC_AlertReport()
        {
            InitializeComponent();
            alertAController = new AlertAController();
            alertBController = new AlertBController();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            alertTypeComboBox.Items.Clear();
            alertTypeComboBox.Items.Add("");
            alertTypeComboBox.Items.Add(ALERT_A);
            alertTypeComboBox.Items.Add(ALERT_B);
        }

        private void alertTypeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (alertTypeComboBox.Text == ALERT_A)
                InitializeDataGridAlertA();
            else if (alertTypeComboBox.Text == ALERT_B)
                InitializeDataGridAlertB();
            else
                this.dataGrid.DataSource = null;

        }

        private void InitializeDataGridAlertA()
        {
            this.dataGrid.DataSource = alertAController.GetActivatedAlerts();
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[1].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[6].HeaderText = SIXTH_COLUMN_NAME;
        }

        private void InitializeDataGridAlertB()
        {
            this.dataGrid.DataSource = alertBController.GetActivatedAlerts();
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = SIXTH_COLUMN_NAME;
        }

    }
}
