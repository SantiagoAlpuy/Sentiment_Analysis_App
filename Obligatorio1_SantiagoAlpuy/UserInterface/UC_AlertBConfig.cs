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
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_AlertBConfig : UserControl
    {
        Repository repository = Repository.Instance;
        IAlertController alertController;
        private const string FIRST_COLUMN_NAME = "Categoría";
        private const string SECOND_COLUMN_NAME = "Posts";
        private const string THIRD_COLUMN_NAME = "Días";
        private const string FOURTH_COLUMN_NAME = "Horas";
        private const string FIFTH_COLUMN_NAME = "Activada";
        private const string ALERT_ADDED_SUCCESFULLY = "Alerta agregada satisfactoriamente.";

        public UC_AlertBConfig()
        {
            InitializeComponent();
            alertController = new AlertAController();
            categoryComboBox.Items.Add("");
            foreach (CategoryType item in Enum.GetValues(typeof(CategoryType)))
            {
                if (item.Equals(CategoryType.Positiva) || item.Equals(CategoryType.Negativa))
                    categoryComboBox.Items.Add(item);
            }

            this.dataGrid.DataSource = repository.Alerts.OfType<AlertB>().ToList();
            categoryComboBox.SelectedIndex = 0;
            dataGrid.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGrid.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGrid.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGrid.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
            dataGrid.Columns[4].HeaderText = FIFTH_COLUMN_NAME;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddAlert();
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

        private void AddAlert()
        {
            IAlert alert = new AlertB()
            {
                Category = StringToCategory(categoryComboBox.SelectedItem.ToString()),
                Posts = (int)postsUpDown.Value,
                Days = (int)daysUpDown.Value,
                Hours = (int)hoursUpDown.Value
            };
            alertController.AddAlert(alert);
            alertController.EvaluateAlerts();
            MessageBox.Show(ALERT_ADDED_SUCCESFULLY);
            SetFieldsToDefaultValue();
            this.dataGrid.DataSource = repository.Alerts.OfType<AlertB>().ToList();
        }

        private CategoryType StringToCategory(string category)
        {
            CategoryType cat = CategoryType.Neutro;
            if (category.Equals("Positiva"))
                cat = CategoryType.Positiva;
            else if (category.Equals("Negativa"))
                cat = CategoryType.Negativa;
            return cat;
        }

        private void SetFieldsToDefaultValue()
        {
            categoryComboBox.SelectedIndex = 0;
            postsUpDown.Value = 0;
            hoursUpDown.Value = 0;
            daysUpDown.Value = 0;
        }

    }
}
