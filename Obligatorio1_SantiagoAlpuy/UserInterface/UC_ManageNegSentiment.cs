using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManageNegSentiment : UserControl
    {
        ISentimentController sentimentController;
        IPhraseController phraseController;
        IAlertController alertController;
        RepositoryA<Sentiment> repositoryA;
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";

        public UC_ManageNegSentiment()
        {
            InitializeComponent();
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            alertController = new AlertAController();
            repositoryA = new RepositoryA<Sentiment>();
            this.dataGrid.DataSource = GetNegativeSentiments();
            dataGrid.Columns[1].HeaderText = MAIN_SENTIMENT_COLUMN_NAME;
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[2].Visible = false;
        }  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Sentiment sentiment = new Sentiment() { Description = sentimentBox.Text, Category = false };
                sentimentController.AddSentiment(sentiment);
                ReactToSuccessfulAddition();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
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

        private void ReactToSuccessfulAddition()
        {
            MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, sentimentBox.Text));
            sentimentBox.Text = "";
            this.dataGrid.DataSource = GetNegativeSentiments();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                sentimentController.RemoveSentiment(row.Cells[1].Value.ToString(), false);
            }

            this.dataGrid.DataSource = GetNegativeSentiments();
        }

        private ICollection<Sentiment> GetNegativeSentiments()
        {
            return sentimentController.GetAllEntitiesByCategory(CategoryType.Negativa);
        }

    }
}
