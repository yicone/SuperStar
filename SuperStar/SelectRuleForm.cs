using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperStar
{
    public partial class SelectRuleForm : Form
    {
        string _extension;

        public string Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        private string _ruleName;

        public string RuleName
        {
            get { return _ruleName; }
            set { _ruleName = value; }
        }

        public SelectRuleForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cmbRules.Text != String.Empty&& cmbExtension.Text != String.Empty)
            {
                _extension = cmbExtension.Text;
                _ruleName = cmbRules.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择一个规则.");
            }
        }
    }
}