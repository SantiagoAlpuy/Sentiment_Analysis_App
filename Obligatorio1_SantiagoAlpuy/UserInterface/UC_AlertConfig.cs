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
        private const string WRITE_ENTITY_MESSAGE = "Ingrese el nombre de una entidad";
        private const string WRITE_POST_COUNT_MESSAGE = "Ingrese la cantidad de posts para activar la alarma";
        private const string WRITE_DAY_COUNT_MESSAGE = "Ingrese el rango de días para activar la alarma";
        private const string WRITE_HOUR_COUNT_MESSAGE = "Ingrese el rango de horas para activar la alarma";
        private const string FIELDS_NOT_ADDED = "Debes completar TODOS los campos.";
        private const string ALERT_ADDED_SUCCESFULLY = "Alerta agregada satisfactoriamente.";
        private const string NEGATIVE_POST_COUNT = "No puedes ingresar cantidad de posts negativos.";
        private const string NEGATIVE_DAY_COUNT = "No puedes ingresar cantidad de posts negativos.";
        private const string NEGATIVE_HOUR_COUNT = "No puedes ingresar cantidad de posts negativos.";
        private const string MAIN_MESSAGE_CATEGORY = "Seleccione una categoría positiva o negativa";
        private const string FIRST_COLUMN_NAME = "Entidad";
        private const string SECOND_COLUMN_NAME = "Categoría";
        private const string THIRD_COLUMN_NAME = "Posts";
        private const string FOURTH_COLUMN_NAME = "Días";
        private const string FIFTH_COLUMN_NAME = "Horas";
        private const string SIXTH_COLUMN_NAME = "Activada";


        public UC_AlertConfig()
        {
            InitializeComponent();
            repository = Repository.Instance;
            alertController = new AlertController();
            foreach (CategoryType item in Enum.GetValues(typeof(CategoryType)))
            {
                if (item.Equals(CategoryType.Positive))
                    categoryComboBox.Items.Add("Positivo");
                else if (item.Equals(CategoryType.Negative))
                    categoryComboBox.Items.Add("Negativo");
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
            if (ValidateIfAllFieldsAreNotEmpty())
            {
                CreateAndAddAlarm();
            }
            else
            {
                MessageBox.Show(FIELDS_NOT_ADDED);
            }
        }

        private bool ValidateIfAllFieldsAreNotEmpty()
        {
            return (entityBox.Text != WRITE_ENTITY_MESSAGE && postBox.Text != WRITE_POST_COUNT_MESSAGE && daysBox.Text != WRITE_DAY_COUNT_MESSAGE &&
                hoursBox.Text != WRITE_HOUR_COUNT_MESSAGE && categoryComboBox.SelectedItem.ToString() != MAIN_MESSAGE_CATEGORY );
        }
        private void CreateAndAddAlarm()
        {
            try
            {
                Alert alert = new Alert()
                {
                    Entity = entityBox.Text,
                    Category = StringToCategory((string)categoryComboBox.SelectedItem),
                    Posts = Int32.Parse(postBox.Text),
                    Days = Int32.Parse(daysBox.Text),
                    Hours = Int32.Parse(hoursBox.Text)
                };
                alertController.AddAlert(alert);
                alertController.EvaluateAlert();
                MessageBox.Show(ALERT_ADDED_SUCCESFULLY);
                SetFieldsToDefaultValue();
                LoadDataGridAlerts();
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private CategoryType StringToCategory(string category)
        {
            CategoryType cat = CategoryType.Neutro;
            if (category.Equals("Positivo"))
                cat = CategoryType.Positive;
            else
                cat = CategoryType.Negative;
            return cat;

        }

        private void SetFieldsToDefaultValue()
        {
            entityBox.Text = WRITE_ENTITY_MESSAGE;
            entityBox.ForeColor = Color.Gray;
            postBox.Text = WRITE_POST_COUNT_MESSAGE;
            postBox.ForeColor = Color.Gray;
            daysBox.Text = WRITE_DAY_COUNT_MESSAGE;
            daysBox.ForeColor = Color.Gray;
            hoursBox.Text = WRITE_HOUR_COUNT_MESSAGE;
            hoursBox.ForeColor = Color.Gray;
            categoryComboBox.Text = "";
        }

        private void entityBox_KeyUp(object sender, KeyEventArgs e)
        {
            IfEmptyLoadDefaultMessage(entityBox, WRITE_ENTITY_MESSAGE);
        }
        
        private void entityBox_KeyDown(object sender, KeyEventArgs e)
        {
            IfDefaultMessageDeleteIt(entityBox, WRITE_ENTITY_MESSAGE);
        }
        
        private void categoryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (categoryComboBox.SelectedIndex == 0)
                categoryComboBox.ForeColor = Color.Gray;
            else
                categoryComboBox.ForeColor = Color.Black;
        }
        
        private void postBox_KeyDown(object sender, KeyEventArgs e)
        {
            IfDefaultMessageDeleteIt(postBox, WRITE_POST_COUNT_MESSAGE);
        }

        private void postBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void postBox_KeyUp(object sender, KeyEventArgs e)
        {
            IfEmptyLoadDefaultMessage(postBox, WRITE_POST_COUNT_MESSAGE);
        }

        private void daysBox_KeyDown(object sender, KeyEventArgs e)
        {
            IfDefaultMessageDeleteIt(daysBox, WRITE_DAY_COUNT_MESSAGE);
        }

        private void daysBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void daysBox_KeyUp(object sender, KeyEventArgs e)
        {
            IfEmptyLoadDefaultMessage(daysBox, WRITE_DAY_COUNT_MESSAGE);
        }

        private void hoursBox_KeyDown(object sender, KeyEventArgs e)
        {
            IfDefaultMessageDeleteIt(hoursBox, WRITE_HOUR_COUNT_MESSAGE);
        }

        private void hoursBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumbers(sender, e);
        }

        private void hoursBox_KeyUp(object sender, KeyEventArgs e)
        {
            IfEmptyLoadDefaultMessage(hoursBox, WRITE_HOUR_COUNT_MESSAGE);
        }

        private void OnlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void IfEmptyLoadDefaultMessage(TextBox box, string message)
        {
            if (box.Text == "")
            {
                box.Text = message;
                box.ForeColor = Color.Gray;
            }
        }

        private void IfDefaultMessageDeleteIt(TextBox box, string message)
        {
            if (box.Text == message)
            {
                box.Text = "";
                box.ForeColor = Color.Black;
            }
        }

    }
}
