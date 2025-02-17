﻿using System;
using System.Collections.Generic;
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
        private const string MAIN_SENTIMENT_COLUMN_NAME = "Descripción";
        private const string SENTIMENT_ADDED_SUCCESFULLY = "Enhorabuena! '{0}' se ha agregado satisfactoriamente";
        public UC_ManagePosSentiment()
        {
            InitializeComponent();
            sentimentController = new SentimentController();
            phraseController = new PhraseController();
            alertController = new AlertAController();
            this.dataGrid.DataSource = GetPositiveSentiments();
            dataGrid.Columns[1].HeaderText = MAIN_SENTIMENT_COLUMN_NAME;
            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[2].Visible = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGrid.SelectedRows)
            {
                sentimentController.RemoveSentiment(row.Cells[1].Value.ToString(), true);
            }

            this.dataGrid.DataSource = GetPositiveSentiments();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Sentiment sentiment = new Sentiment() { Description = sentimentBox.Text, Category = true };
                sentimentController.AddSentiment(sentiment);
                ReactToSuccessfulAdition();
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

        private void ReactToSuccessfulAdition()
        {
            MessageBox.Show(String.Format(SENTIMENT_ADDED_SUCCESFULLY, sentimentBox.Text));
            sentimentBox.Text = "";
            this.dataGrid.DataSource = GetPositiveSentiments();
        }

        private ICollection<Sentiment> GetPositiveSentiments()
        {
            return sentimentController.GetAllEntitiesByCategory(CategoryType.Positiva);
        }

    }
}
