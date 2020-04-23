using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_ManagePosSentiment1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_ManageEntities1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_ManagePhrases1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            uC_AlertReport1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_AlertConfig1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_AnalysisReport1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            uC_AlertConfig1.Hide();
            uC_AnalysisReport1.Hide();
            uC_ManageEntities1.Hide();
            uC_ManagePhrases1.Hide();
            uC_ManagePosSentiment1.Hide();
            uC_ManageNegSentiment1.Hide();
            uC_AlertReport1.Show();
        }
    }
}
