using System;
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
            this.PrincipalPanel.Controls.Clear();
        }

        private void btnManagePositiveSentiment_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_ManagePosSentiment());
        }

        private void btnManageNegativeSentiment_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_ManageNegSentiment());
        }

        private void btnManageEntities_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_ManageEntities());
        }

        private void btnManagePhrases_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_ManagePhrases(this.PrincipalPanel));
        }

        private void btnAlertConfig_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_AlertAConfig());
        }

        private void btnAnalysisReport_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_AnalysisReport());
        }

        private void btnAlertReport_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_AlertReport());
        }

        private void btnManageAuthors_Click_1(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_ManageAuthors(this.PrincipalPanel));
        }

        private void btnAlertConfigB_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_AlertBConfig());
        }

        private void btnAuthorReport_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_AuthorReport());
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.PrincipalPanel.Controls.Clear();
            this.PrincipalPanel.Controls.Add(new UC_Help());
        }
    }
}
