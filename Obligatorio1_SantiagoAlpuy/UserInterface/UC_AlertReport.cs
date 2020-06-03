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

namespace UserInterface
{
    public partial class UC_AlertReport : UserControl
    {
        Repository repository;
        private const string FIRST_COLUMN_NAME = "Entidad";
        private const string SECOND_COLUMN_NAME = "Categoría";
        private const string THIRD_COLUMN_NAME = "Posts";
        private const string FOURTH_COLUMN_NAME = "Días";
        private const string FIFTH_COLUMN_NAME = "Horas";
        private const string SIXTH_COLUMN_NAME = "Activada";
        public UC_AlertReport()
        {
            InitializeComponent();
            repository = Repository.Instance;
            LoadDataGridAlerts();
            dataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = SIXTH_COLUMN_NAME;

        }

        private void LoadDataGridAlerts()
        {
            this.dataGrid.DataSource = repository.Alerts.OfType<AlertA>().ToList().FindAll( x => x.Activated);
        }
    }
}
