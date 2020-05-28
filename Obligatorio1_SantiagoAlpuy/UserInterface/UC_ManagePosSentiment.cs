using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManagePosSentiment : UserControl
    {
        ISentimentController sentimentController;
        IPhraseController phraseController;
        IAlertController alertController;
        Repository repository;
        private const string WRITE_POSITIVE_WORD_MESSAGE = "Ingrese palabras o combinaciones positivas";
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        public UC_ManagePosSentiment()
        {
            InitializeComponent();
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            alertController = new AlertController();
            repository = Repository.Instance;
            LoadDataGridPositiveSentiments();
            dataGrid.Columns[0].HeaderText = MAIN_SENTIMENT_COLUMN_NAME;
            dataGrid.Columns[1].Visible = false;
        }

        private void LoadDataGridPositiveSentiments()
        {
            this.dataGrid.DataSource = repository.PositiveSentiments.ToList();
        }

        private void sentimentBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (sentimentBox.Text == WRITE_POSITIVE_WORD_MESSAGE)
            {
                sentimentBox.Text = "";
                sentimentBox.ForeColor = Color.Black;
            }
        }

        private void sentimentBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (sentimentBox.Text == "")
            {
                sentimentBox.Text = WRITE_POSITIVE_WORD_MESSAGE;
                sentimentBox.ForeColor = Color.Gray;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                sentimentController.RemoveSentiment(row.Cells[0].Value.ToString(), true);
                phraseController.AnalyzeAllPhrases();
                alertController.EvaluateAlert();
            }

            LoadDataGridPositiveSentiments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CreateAndAddSentiment();
        }

        private void CreateAndAddSentiment()
        {
            try
            {
                Sentiment sentiment = new Sentiment() { Description = sentimentBox.Text, Category = true };
                sentimentController.AddSentiment(sentiment);
                phraseController.AnalyzeAllPhrases();
                alertController.EvaluateAlert();
                MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, sentimentBox.Text));
                sentimentBox.Text = WRITE_POSITIVE_WORD_MESSAGE;
                sentimentBox.ForeColor = Color.Gray;
                LoadDataGridPositiveSentiments();
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
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
    }
}
