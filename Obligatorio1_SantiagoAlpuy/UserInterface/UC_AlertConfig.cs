using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_AlertConfig : UserControl
    {
        Repository repository;
        IAlertController alertController;
        private const string EMPTY_MESSAGE = "";
        private const string FIELDS_NOT_ADDED = "Debes completar TODOS los campos.";
        private const string ALERT_ADDED_SUCCESFULLY = "Alerta agregada satisfactoriamente.";
        private const string FIRST_COLUMN_NAME = "Entidad";
        private const string SECOND_COLUMN_NAME = "Categoría";
        private const string THIRD_COLUMN_NAME = "Posts";
        private const string FOURTH_COLUMN_NAME = "Días";
        private const string FIFTH_COLUMN_NAME = "Horas";
        private const string SIXTH_COLUMN_NAME = "Activada";
        private const string POST_COUNT_MISSING = "Debe ingresar una cantidad de posts.";
        private const string DAY_COUNT_MISSING = "Debe ingresar una cantidad de días.";
        private const string HOUR_COUNT_MISSING = "Debe ingresar una cantidad de horas.";

        public UC_AlertConfig()
        {
            InitializeComponent();
            repository = Repository.Instance;
            alertController = new AlertController();
            categoryComboBox.Items.Add("");
            foreach (CategoryType item in Enum.GetValues(typeof(CategoryType)))
            {
                if (item.Equals(CategoryType.Positive))
                    categoryComboBox.Items.Add("Positiva");
                else if (item.Equals(CategoryType.Negative))
                    categoryComboBox.Items.Add("Negativa");
            }
            LoadDataGridAlerts();
            categoryComboBox.SelectedIndex = 0;
            dataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;
            dataGrid.Columns[5].HeaderText = SIXTH_COLUMN_NAME;
        }

        private void LoadDataGridAlerts()
        {
            this.dataGrid.DataSource = repository.Alerts.ToList();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EvaluateAlert();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EvaluateAlert()
        {
            Alert alert = new Alert()
            {
                Entity = entityBox.Text,
                Category = StringToCategory((string)categoryComboBox.SelectedItem),
                Posts = (int) postsUpDown.Value,
                Days = (int) daysUpDown.Value,
                Hours = (int) hoursUpDown.Value
            };
            alertController.AddAlert(alert);
            alertController.EvaluateAlert();
            MessageBox.Show(ALERT_ADDED_SUCCESFULLY);
            SetFieldsToDefaultValue();
            LoadDataGridAlerts();
        }

        private CategoryType StringToCategory(string category)
        {
            CategoryType cat = CategoryType.Neutro;
            if (category.Equals("Positiva"))
                cat = CategoryType.Positive;
            else if (category.Equals("Negativa"))
                cat = CategoryType.Negative;
            return cat;
        }

        private void SetFieldsToDefaultValue()
        {
            entityBox.Text = "";
            categoryComboBox.SelectedIndex = 0;
            postsUpDown.Value = 0;
            hoursUpDown.Value = 0;
            daysUpDown.Value = 0;
        }


    }
}
