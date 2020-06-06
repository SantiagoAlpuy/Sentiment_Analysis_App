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

namespace UserInterface
{
    public partial class UC_AuthorReport : UserControl
    {
        IPhraseController phraseController;

        private const string OPTION_A = "1- Porcentaje de frases positivas por cada autor";
        private const string OPTION_B = "2- Porcentaje de frases negativas por cada autor";
        private const string OPTION_C = "3- Cantidad de entidades mencionadas por cada autor";
        private const string OPTION_D = "4- Promedio diario de frases por cada autor";

        public UC_AuthorReport()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            criterionComboBox.Items.Clear();
            criterionComboBox.Items.Add("");
            criterionComboBox.Items.Add(OPTION_A);
            criterionComboBox.Items.Add(OPTION_B);
            criterionComboBox.Items.Add(OPTION_C);
            criterionComboBox.Items.Add(OPTION_D);
        }

        private void InitializeDataGridOptionA(string criterion)
        {
            if (criterion == OPTION_A)
                this.dataGrid.DataSource = phraseController.GetAllEntities();
            else if (criterion == OPTION_B)
                this.dataGrid.DataSource = phraseController.GetAllEntities();
            else if (criterion == OPTION_C)
                this.dataGrid.DataSource = phraseController.GetAllEntities();
            else if (criterion == OPTION_D)
                this.dataGrid.DataSource = phraseController.GetAllEntities();
            else
                this.dataGrid.DataSource = null;
        }

        private void criterionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitializeDataGridOptionA(criterionComboBox.Text);
        }
    }
}
