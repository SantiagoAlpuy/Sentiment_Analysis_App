using System;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManagePhrases : UserControl
    {
        IPhraseController phraseController;
        IAlertController alertController;
        IAuthorController authorController;
        Repository repository;
        FlowLayoutPanel mainPanel;
        private const string WRITE_PHRASE_MESSAGE = "Ingrese una frase";
        private const string PHRASE_NOT_ADDED = "Ingrese una frase válida.";
        private const string PHRASE_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente. ¿Quiere ver las alarmas activas?";

        public UC_ManagePhrases()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            alertController = new AlertController();
            authorController = new AuthorController();
        }

        public UC_ManagePhrases(FlowLayoutPanel panel)
        {
            InitializeComponent();
            phraseController = new PhraseController();
            alertController = new AlertController();
            authorController = new AuthorController();
            repository = Repository.Instance;
            mainPanel = panel;

            autorComboBox.Items.Add("");
            foreach (Author author in repository.Authors)
            {
                autorComboBox.Items.Add(author.Username);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (phraseBox.Text != WRITE_PHRASE_MESSAGE)
                CreateAndAddPhrase();
            else
                MessageBox.Show(PHRASE_NOT_ADDED);
        }

        private void CreateAndAddPhrase()
        {
            try
            {
                DateTime date = dateTimePicker1.Value;
                Author author = authorController.ObtainAuthorByUsername((string) autorComboBox.SelectedItem);
                Phrase phrase = new Phrase() { Comment = phraseBox.Text, Date = date, PhraseAuthor = author };
                phraseController.AddPhraseToRepository(phrase);
                phraseController.AnalyzePhrase(phrase);
                alertController.EvaluateAlert();
                ShowMessageAndGoToAlerts();
                phraseBox.Text = WRITE_PHRASE_MESSAGE;
                phraseBox.ForeColor = Color.Gray;
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

        private void ShowMessageAndGoToAlerts()
        {
            DialogResult messageWindow = MessageBox.Show(String.Format(PHRASE_ADDED_SUCCESFULLY, phraseBox.Text), "", MessageBoxButtons.YesNo);
            if (messageWindow == DialogResult.Yes)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(new UC_AlertReport());
            }
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
