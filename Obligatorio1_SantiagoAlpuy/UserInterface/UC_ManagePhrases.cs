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
    public partial class UC_ManagePhrases : UserControl
    {
        PhraseController phraseController = new PhraseController();
        Repository repository;
        private const string WRITE_PHRASE_MESSAGE = "Ingrese una frase";
        private const string PHRASE_NOT_ADDED = "Ingrese una frase válida.";
        private const string PHRASE_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string NO_COMMENT_PHRASE = "Por favor, ingrese una frase o comentario.";
        private const string PHRASE_DATE_OLDER_THAN_ONE_YEAR = "No puede ingresar una fecha más vieja que un año atras.";
        private const string PHRASE_DATE_FROM_FUTURE = "No puede ingresar una fecha del futuro.";
        private const string FIRST_COLUMN_NAME = "Comentario";
        private const string SECOND_COLUMN_NAME = "Fecha";
        private const string THIRD_COLUMN_NAME = "Entidad";
        private const string FOURTH_COLUMN_NAME = "Categoría";
        public UC_ManagePhrases()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            repository = Repository.Instance;
            LoadDataGridPhrases();
            dataGridPositiveSentiments.Columns[0].HeaderText = FIRST_COLUMN_NAME;
            dataGridPositiveSentiments.Columns[1].HeaderText = SECOND_COLUMN_NAME;
            dataGridPositiveSentiments.Columns[2].HeaderText = THIRD_COLUMN_NAME;
            dataGridPositiveSentiments.Columns[3].HeaderText = FOURTH_COLUMN_NAME;
        }

        private void LoadDataGridPhrases()
        {
            this.dataGridPositiveSentiments.DataSource = repository.phrases.ToList();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = WRITE_PHRASE_MESSAGE;
                textBox1.ForeColor = Color.Gray;
            }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox1.Text == WRITE_PHRASE_MESSAGE)
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != WRITE_PHRASE_MESSAGE)
            {
                CreateAndAddPhrase();

            }
            else
            {
                MessageBox.Show(PHRASE_NOT_ADDED);
            }
        }

        private void CreateAndAddPhrase()
        {
            try
            {
                DateTime date = dateTimePicker1.Value;
                Phrase phrase = new Phrase() { Comment = textBox1.Text, Date = date};
                phraseController.AddPhrase(phrase);
                MessageBox.Show(String.Format(PHRASE_ADDED_SUCCESFULLY, textBox1.Text));
                textBox1.Text = WRITE_PHRASE_MESSAGE;
                textBox1.ForeColor = Color.Gray;
                LoadDataGridPhrases();
            }
            catch (LackOfObligatoryParametersException e)
            {
                MessageBox.Show(NO_COMMENT_PHRASE);
            }
            catch (DateOlderThanOneYearException e)
            {
                MessageBox.Show(PHRASE_DATE_OLDER_THAN_ONE_YEAR);
            }
            catch (DateFromFutureException e)
            {
                MessageBox.Show(PHRASE_DATE_FROM_FUTURE);
            }
        }


    }
}
