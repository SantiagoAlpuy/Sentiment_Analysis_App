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
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManageEntities : UserControl
    {
        IEntityController entityController;
        IAlertController alertController;
        IPhraseController phraseController;
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
            alertController = new AlertController();
            phraseController = new PhraseController();
            repository = Repository.Instance;
            LoadDataGridEntities();
            dataGrid.Columns[0].HeaderText = MAIN_ENTITY_COLUMN_NAME;
        }

        private void LoadDataGridEntities()
        {
            this.dataGrid.DataSource = repository.Entities.ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                entityController.RemoveEntity(row.Cells[0].Value.ToString());
                phraseController.AnalyzeAllPhrases();
                alertController.EvaluateAlert();
            }
            LoadDataGridEntities();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (entityBox.Text != WRITE_ENTITY_MESSAGE)
                CreateAndAddEntity();
            else
                MessageBox.Show(ENTITY_NOT_ADDED);
        }

        private void CreateAndAddEntity()
        {
            try
            {
                Entity entity = new Entity() { Name = entityBox.Text };
                entityController.AddEntity(entity);
                phraseController.AnalyzeAllPhrases();
                alertController.EvaluateAlert();
                MessageBox.Show(String.Format(ENTITY_ADDED_SUCCESFULLY, entityBox.Text));
                entityBox.Text = WRITE_ENTITY_MESSAGE;
                entityBox.ForeColor = Color.Gray;
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


        private void entityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (entityBox.Text == WRITE_ENTITY_MESSAGE)
            {
                entityBox.Text = "";
                entityBox.ForeColor = Color.Black;
            }
        }

        private void entityBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (entityBox.Text == "")
            {
                entityBox.Text = WRITE_ENTITY_MESSAGE;
                entityBox.ForeColor = Color.Gray;
            }
        }
    }
}
