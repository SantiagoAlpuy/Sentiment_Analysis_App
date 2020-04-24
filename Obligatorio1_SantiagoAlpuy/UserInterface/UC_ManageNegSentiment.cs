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
using BusinessLogic.Exceptions;
using BusinessLogic;

namespace UserInterface
{
    public partial class UC_ManageNegSentiment : UserControl
    {
        SentimentController sentimentController;
        private const string WRITE_NEGATIVE_WORD_MESSAGE = "Ingrese palabras o combinaciones negativas";
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string SENTIMENT_NOT_ADDED = "Por favor, ingrese un sentimiento válido.";
        private const string NO_DESCRIPTION_SENTIMENT = "No agrego una descripción.";
        private const string SENTIMENT_HAS_NUMBERS = "No se supone que un sentimiento tenga numeros.";
        private const string SENTIMENT_ALREADY_ADDED = "Ese sentimiento ya fue añadido!";

        public UC_ManageNegSentiment()
        {
            InitializeComponent();
            sentimentController = new SentimentController();
            LoadDataGridPositiveSentiments();
            dataGridPositiveSentiments.Columns[0].HeaderText = MAIN_SENTIMENT_COLUMN_NAME;
            dataGridPositiveSentiments.Columns[1].Visible = false;
        }

        private void LoadDataGridPositiveSentiments()
        {
            this.dataGridPositiveSentiments.DataSource = sentimentController.negativeSentiments.ToList();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = WRITE_NEGATIVE_WORD_MESSAGE;
                textBox1.ForeColor = Color.Gray;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == WRITE_NEGATIVE_WORD_MESSAGE)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != WRITE_NEGATIVE_WORD_MESSAGE)
            {
                CreateAndAddSentiment();

            }
            else
            {
                MessageBox.Show(SENTIMENT_NOT_ADDED);
            }

        }

        private void CreateAndAddSentiment()
        {
            try
            {
                Sentiment sentiment = new Sentiment() { Description = textBox1.Text, Category = false };
                sentimentController.AddSentiment(sentiment);
                MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, textBox1.Text));
                textBox1.Text = WRITE_NEGATIVE_WORD_MESSAGE;
                textBox1.ForeColor = Color.Gray;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridPositiveSentiments.SelectedRows)
            {
                sentimentController.RemoveSentiment(row.Cells[0].Value.ToString(), false);
            }
            LoadDataGridPositiveSentiments();
        }
    }
}
