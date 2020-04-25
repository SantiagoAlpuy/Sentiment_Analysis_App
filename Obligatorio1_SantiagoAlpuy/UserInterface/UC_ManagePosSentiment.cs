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
    public partial class UC_ManagePosSentiment : UserControl
    {
        SentimentController sentimentController;
        PhraseController phraseController;
        AlertController alertController;
        Repository repository;
        private const string WRITE_POSITIVE_WORD_MESSAGE = "Ingrese palabras o combinaciones positivas";
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string SENTIMENT_NOT_ADDED = "Por favor, ingrese un sentimiento válido.";
        private const string NO_DESCRIPTION_SENTIMENT = "No agrego una descripción.";
        private const string SENTIMENT_HAS_NUMBERS = "No se supone que un sentimiento tenga numeros.";
        private const string SENTIMENT_ALREADY_ADDED = "Ese sentimiento ya fue añadido!";
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
            this.dataGrid.DataSource = repository.positiveSentiments.ToList();
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
                alertController.CheckAlertActivation();
            }

            LoadDataGridPositiveSentiments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (sentimentBox.Text != WRITE_POSITIVE_WORD_MESSAGE)
                CreateAndAddSentiment();
            else
                MessageBox.Show(SENTIMENT_NOT_ADDED);
        }

        private void CreateAndAddSentiment()
        {
            try
            {
                Sentiment sentiment = new Sentiment() { Description = sentimentBox.Text, Category = true };
                sentimentController.AddSentiment(sentiment);
                phraseController.AnalyzeAllPhrases();
                alertController.CheckAlertActivation();
                MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, sentimentBox.Text));
                sentimentBox.Text = WRITE_POSITIVE_WORD_MESSAGE;
                sentimentBox.ForeColor = Color.Gray;
                LoadDataGridPositiveSentiments();
            }
            catch (LackOfObligatoryParametersException e)
            {
                MessageBox.Show(NO_DESCRIPTION_SENTIMENT);
            }
            catch (ContainsNumbersException e)
            {
                MessageBox.Show(SENTIMENT_HAS_NUMBERS);
            }
            catch (SentimentAlreadyExistsException e)
            {
                MessageBox.Show(SENTIMENT_ALREADY_ADDED);
            }
        }
    }
}
