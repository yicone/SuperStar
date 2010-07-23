using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuperStar
{
    public partial class InputBaseClassForm : Form
    {
        string _baseClassName;

        public string BaseClassName
        {
            get { return _baseClassName; }
            set { _baseClassName = value; }
        }

        public InputBaseClassForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _baseClassName = txtBaseClassName.Text.Trim();

            if (_baseClassName != String.Empty)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("��ѡ���ļ����ͺ������ռ�");
            }
        }
    }
}