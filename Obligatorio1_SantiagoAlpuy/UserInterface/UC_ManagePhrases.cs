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
        PhraseController phraseController;
        AlertController alertController;
        Repository repository;
        private const string WRITE_PHRASE_MESSAGE = "Ingrese una frase";
        private const string PHRASE_NOT_ADDED = "Ingrese una frase válida.";
        private const string PHRASE_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        private const string NO_COMMENT_PHRASE = "Por favor, ingrese una frase o comentario.";
        private const string PHRASE_DATE_OLDER_THAN_ONE_YEAR = "No puede ingresar una fecha más vieja que un año atras.";
        private const string PHRASE_DATE_FROM_FUTURE = "No puede ingresar una fecha del futuro.";
        public UC_ManagePhrases()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            alertController = new AlertController();
            repository = Repository.Instance;
        }


        private void CreateAndAddPhrase()
        {
            try
            {
                DateTime date = dateTimePicker1.Value;
                Phrase phrase = new Phrase() { Comment = phraseBox.Text, Date = date};
                phraseController.AddPhraseToRepository(phrase);
                phraseController.AnalyzePhrase(phrase);
                alertController.CheckAlertActivation();
                MessageBox.Show(String.Format(PHRASE_ADDED_SUCCESFULLY, phraseBox.Text));
                phraseBox.Text = WRITE_PHRASE_MESSAGE;
                phraseBox.ForeColor = Color.Gray;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (phraseBox.Text != WRITE_PHRASE_MESSAGE)
                CreateAndAddPhrase();
            else
                MessageBox.Show(PHRASE_NOT_ADDED);
        }

        private void phraseBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (phraseBox.Text == WRITE_PHRASE_MESSAGE)
            {
                phraseBox.Text = "";
                phraseBox.ForeColor = Color.Black;
            }
        }

        private void phraseBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (phraseBox.Text == "")
            {
                phraseBox.Text = WRITE_PHRASE_MESSAGE;
                phraseBox.ForeColor = Color.Gray;
            }
        }
    }
}
