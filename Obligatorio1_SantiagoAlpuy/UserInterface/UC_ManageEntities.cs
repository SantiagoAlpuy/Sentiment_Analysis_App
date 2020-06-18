using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManageEntities : UserControl
    {
        IEntityController entityController;
        IAlertController alertController;
        IPhraseController phraseController;
        private const string ENTITY_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string MAIN_ENTITY_COLUMN_NAME = "Nombre";
        public UC_ManageEntities()
        {
            InitializeComponent();
            entityController = new EntityController();
            alertController = new AlertAController();
            phraseController = new PhraseController();
            LoadDataGrid();
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[1].HeaderText = MAIN_ENTITY_COLUMN_NAME;
        }        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Entity entity = new Entity() { Name = entityBox.Text };
                entityController.AddEntity(entity);
                ReactToSuccessfulAddition();
                
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException ex)
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

        private void ReactToSuccessfulAddition()
        {
            MessageBox.Show(String.Format(ENTITY_ADDED_SUCCESFULLY, entityBox.Text));
            entityBox.Text = "";
            LoadDataGrid();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                entityController.RemoveEntity(row.Cells[1].Value.ToString());
            }
            LoadDataGrid();
        }

        private void LoadDataGrid()
        {
            this.dataGrid.DataSource = entityController.GetAllEntities();
        }

    }
}
