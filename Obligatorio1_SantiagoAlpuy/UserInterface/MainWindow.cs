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
            this.PrincipalPanel.Controls.Add(new UC_AlertConfig());
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
    }
}
