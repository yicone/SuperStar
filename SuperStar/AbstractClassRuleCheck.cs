using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using System.Windows.Forms;
using EnvDTE;

namespace SuperStar
{
    public abstract class AbstractClassRuleCheck : IClassRuleCheck
    {
        private DTE2 _applicationObject;
        private string _extension;
        private OutputWindowPane _outputPane;

        protected DTE2 ApplicationObject
        {
            get { return _applicationObject; }
        }

        protected OutputWindowPane OutputPane
        {
            get { return _outputPane; }
            //设计考虑: 因为输出方式可能改变
            set { _outputPane = value; }
        }

        public AbstractClassRuleCheck(DTE2 applicationObject, string extension)
        {
            _applicationObject = applicationObject;
            _extension = extension;
            
            _outputPane = Common.GetOutputWindowPane(applicationObject, "SuperStar");
            _outputPane.Clear();
        }

        #region IClassRuleCheck Members

        public void Checking()
        {
            ClassLocatingProxy proxy = new ClassLocatingProxy(_applicationObject, _extension);
            proxy.ClassLocated += new EventHandler(proxy_ClassLocated);
            proxy.CheckEachClassInActiveProject();
        }

        private void proxy_ClassLocated(object sender, EventArgs e)
        {
            try
            {
                DoCheck((e as ClassLocatedEventArgs).CodeClass);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public abstract void DoCheck(EnvDTE.CodeClass codeClass);
        #endregion
    }
}
