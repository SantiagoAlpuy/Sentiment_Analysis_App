using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Controllers;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace UserInterface
{
    public partial class UC_ManageEntities : UserControl
    {
        EntityController entityController;
        Repository repository;
        private const string WRITE_ENTITY_MESSAGE = "Ingrese una entidad";
        private const string ENTITY_NOT_ADDED = "Por favor ingrese una entidad valida.";
        private const string ENTITY_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string NO_DESCRIPTION_ENTITY = "Agregue un nombre de entidad.";
        private const string ENTITY_ALREADY_EXISTS = "Esa entidad ya ha sido agregada al sistema.";
        private const string MAIN_ENTITY_COLUMN_NAME = "Nombre";
        public UC_ManageEntities()
        {
            InitializeComponent();
            entityController = new EntityController();
            repository = Repository.Instance;
            LoadDataGridEntities();
            dataGridPositiveSentiments.Columns[0].HeaderText = MAIN_ENTITY_COLUMN_NAME;
        }

        private void LoadDataGridEntities()
        {
            this.dataGridPositiveSentiments.DataSource = repository.entities.ToList();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != WRITE_ENTITY_MESSAGE)
            {
                CreateAndAddEntity();

            }
            else
            {
                MessageBox.Show(ENTITY_NOT_ADDED);
            }
        }

        private void CreateAndAddEntity()
        {
            try
            {
                Entity entity = new Entity() { Name = textBox1.Text };
                entityController.AddEntity(entity);
                MessageBox.Show(String.Format(ENTITY_ADDED_SUCCESFULLY, textBox1.Text));
                textBox1.Text = WRITE_ENTITY_MESSAGE;
                textBox1.ForeColor = Color.Gray;
                LoadDataGridEntities();
            }
            catch (LackOfObligatoryParametersException e)
            {
                MessageBox.Show(NO_DESCRIPTION_ENTITY);
            }
            catch (EntityAlreadyExistsException e)
            {
                MessageBox.Show(ENTITY_ALREADY_EXISTS);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridPositiveSentiments.SelectedRows)
            {
                entityController.RemoveEntity(row.Cells[0].Value.ToString());
            }
            LoadDataGridEntities();
        }
    }
}
