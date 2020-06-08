using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogic.Controllers;
using BusinessLogic.IControllers;

namespace UserInterface
{
    public partial class UC_ManagePhrases : UserControl
    {
        IPhraseController phraseController;
        IAuthorController authorController;
        FlowLayoutPanel mainPanel;
        private const string PHRASE_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente. ¿Quiere ver las alarmas activas?";

        public UC_ManagePhrases()
        {
            InitializeComponent();
            phraseController = new PhraseController();
            authorController = new AuthorController();
        }

        public UC_ManagePhrases(FlowLayoutPanel panel)
        {
            InitializeComponent();
            phraseController = new PhraseController();
            authorController = new AuthorController();
            mainPanel = panel;

            autorComboBox.Items.Add("");
            autorComboBox.SelectedIndex = 0;
            foreach (Author author in authorController.GetAll())
            {
                autorComboBox.Items.Add(author.Username);
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AddPhrase();
                ReactToSuccessfulAddition();
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
            finally
            {
                autorComboBox.SelectedIndex = 0;
            }
        }


        private void AddPhrase()
        {
            DateTime date = dateTimePicker1.Value;
            Author author = authorController.ObtainAuthorByUsername(autorComboBox.SelectedItem.ToString());
            Phrase phrase = new Phrase() { Comment = phraseBox.Text, Date = date, Author = author };
            phraseController.AddPhrase(phrase);
        }

        private void ReactToSuccessfulAddition()
        {
            DialogResult messageWindow = MessageBox.Show(String.Format(PHRASE_ADDED_SUCCESFULLY, phraseBox.Text), "", MessageBoxButtons.YesNo);
            if (messageWindow == DialogResult.Yes)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(new UC_AlertReport());
            }
            phraseBox.Text = "";
        }
    }
}
