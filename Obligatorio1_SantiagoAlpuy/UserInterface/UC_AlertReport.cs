using System.Collections.Generic;
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
        IAuthorController authorController;
        ICollection<AlertB> collection;

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
            authorController = new AuthorController();
            ICollection<AlertB> collection = new List<AlertB>();
            infoLabel.Visible = false;
            listBoxPanel.Visible = false;
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
            infoLabel.Visible = false; 
            dataGrid.DataSource = alertAController.GetActivatedAlerts();
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
            infoLabel.Visible = true;
            collection = alertBController.GetActivatedAlerts();
            dataGrid.DataSource = collection;
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = SIXTH_COLUMN_NAME;
            dataGrid.Columns[6].Visible = false;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (alertTypeComboBox.Text == ALERT_B)
            {
                authorsBox.Items.Clear();
                DataGridViewRow row = dataGrid.CurrentRow;
                ICollection<AlertBAuthor> association = collection.ElementAt(row.Index).AlertBAuthors;
                foreach (AlertBAuthor item in association)
                {
                    Author author = authorController.GetAuthorById(item.AuthorId);
                    authorsBox.Items.Add(author.Username + " - " + author.Name + " " + author.Username);
                }
                listBoxPanel.Visible = true;
            }
            
        }

        private void btnCloseWindow_Click(object sender, System.EventArgs e)
        {
            listBoxPanel.Visible = false;
        }
    }
}
