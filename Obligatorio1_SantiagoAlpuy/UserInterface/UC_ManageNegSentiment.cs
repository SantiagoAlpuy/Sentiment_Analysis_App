using System;
using System.Drawing;
using System.Linq;
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
        Repository repository;
        private const string WRITE_NEGATIVE_WORD_MESSAGE = "Ingrese palabras o combinaciones negativas";
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";

        public UC_ManageNegSentiment()
        {
            InitializeComponent();
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            alertController = new AlertController();
            repository = Repository.Instance;
            this.dataGrid.DataSource = repository.NegativeSentiments.ToList();
            dataGrid.Columns[0].HeaderText = MAIN_SENTIMENT_COLUMN_NAME;
            dataGrid.Columns[1].Visible = false;
        }  

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EvaluateSentimentInsertion();
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

        private void EvaluateSentimentInsertion()
        {
            Sentiment sentiment = new Sentiment() { Description = sentimentBox.Text, Category = false };
            sentimentController.AddSentiment(sentiment);
            phraseController.AnalyzeAllPhrases();
            alertController.EvaluateAlerts();
            MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, sentimentBox.Text));
            sentimentBox.Text = WRITE_NEGATIVE_WORD_MESSAGE;
            sentimentBox.ForeColor = Color.Gray;
            this.dataGrid.DataSource = repository.NegativeSentiments.ToList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                sentimentController.RemoveSentiment(row.Cells[0].Value.ToString(), false);
                phraseController.AnalyzeAllPhrases();
                alertController.EvaluateAlerts();
            }

            this.dataGrid.DataSource = repository.NegativeSentiments.ToList();
        }
        

        private void sentimentBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (sentimentBox.Text == "")
            {
                sentimentBox.Text = WRITE_NEGATIVE_WORD_MESSAGE;
                sentimentBox.ForeColor = Color.Gray;
            }
        }

        private void sentimentBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sentimentBox.Text == WRITE_NEGATIVE_WORD_MESSAGE)
            {
                sentimentBox.Text = "";
                sentimentBox.ForeColor = Color.Black;
            }
        }
    }
}
