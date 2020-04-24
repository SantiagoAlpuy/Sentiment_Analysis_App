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
using BusinessLogic.Exceptions;

namespace UserInterface
{
    public partial class UC_AlertConfig : UserControl
    {
        Repository repository;
        AlertController alertController;
        private const string WRITE_ENTITY_MESSAGE = "Ingrese el nombre de una entidad";
        private const string WRITE_POST_COUNT_MESSAGE = "Ingrese la cantidad de posts para activar la alarma";
        private const string WRITE_DAY_COUNT_MESSAGE = "Ingrese el rango de días para activar la alarma";
        private const string WRITE_HOUR_COUNT_MESSAGE = "Ingrese el rango de horas para activar la alarma";
        private const string FIELDS_NOT_ADDED = "Debes completar TODOS los campos.";
        private const string ALERT_ADDED_SUCCESFULLY = "Alerta agregada satisfactoriamente.";
        private const string NEGATIVE_POST_COUNT = "No puedes ingresar cantidad de posts negativos.";
        private const string NEGATIVE_DAY_COUNT = "No puedes ingresar cantidad de posts negativos.";
        private const string NEGATIVE_HOUR_COUNT = "No puedes ingresar cantidad de posts negativos.";


        public UC_AlertConfig()
        {
            InitializeComponent();
            repository = Repository.Instance;
            alertController = new AlertController();
            foreach (CategoryType item in Enum.GetValues(typeof(CategoryType)))
            {
                if (!item.Equals(CategoryType.Neutro))
                    comboBox1.Items.Add(item);
            }
            LoadDataGridAlerts();
        }

        private void LoadDataGridAlerts()
        {
            this.dataGridPositiveSentiments.DataSource = repository.alerts.ToList();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = WRITE_ENTITY_MESSAGE;
                textBox1.ForeColor = Color.Gray;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == WRITE_ENTITY_MESSAGE)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text == WRITE_POST_COUNT_MESSAGE)
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = WRITE_POST_COUNT_MESSAGE;
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox4.Text == WRITE_DAY_COUNT_MESSAGE)
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = WRITE_DAY_COUNT_MESSAGE;
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox5.Text == WRITE_HOUR_COUNT_MESSAGE)
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = WRITE_HOUR_COUNT_MESSAGE;
                textBox5.ForeColor = Color.Gray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != WRITE_ENTITY_MESSAGE && textBox3.Text != WRITE_POST_COUNT_MESSAGE && textBox4.Text != WRITE_DAY_COUNT_MESSAGE && 
                textBox5.Text != WRITE_HOUR_COUNT_MESSAGE)
            {
                CreateAndAddAlarm();

            }
            else
            {
                MessageBox.Show(FIELDS_NOT_ADDED);
            }
        }

        private void CreateAndAddAlarm()
        {
            try
            {
                Alert alert = new Alert()
                {
                    Entity = textBox1.Text,
                    Category = CategoryType.Positive,
                    Posts = Int32.Parse(textBox3.Text),
                    Days = Int32.Parse(textBox4.Text),
                    Hours = Int32.Parse(textBox5.Text)
                };
                alertController.AddAlert(alert);
                MessageBox.Show(ALERT_ADDED_SUCCESFULLY);
                textBox1.Text = WRITE_ENTITY_MESSAGE;
                textBox1.ForeColor = Color.Gray;
                textBox3.Text = WRITE_POST_COUNT_MESSAGE;
                textBox3.ForeColor = Color.Gray;
                textBox4.Text = WRITE_DAY_COUNT_MESSAGE;
                textBox4.ForeColor = Color.Gray;
                textBox5.Text = WRITE_HOUR_COUNT_MESSAGE;
                textBox5.ForeColor = Color.Gray;
                comboBox1.Text = "";


                LoadDataGridAlerts();
            }
            catch (NegativePostCountException e)
            {
                MessageBox.Show(NEGATIVE_POST_COUNT);
            }
            catch (NegativeDayException e)
            {
                MessageBox.Show(NEGATIVE_DAY_COUNT);
            }
            catch (NegativeHourException e)
            {
                MessageBox.Show(NEGATIVE_HOUR_COUNT);
            }
        }
    }
}
