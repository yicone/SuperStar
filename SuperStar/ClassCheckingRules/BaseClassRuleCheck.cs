using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using System.Windows.Forms;
using EnvDTE;

namespace SuperStar
{
    public class BaseClassRuleCheck : AbstractClassRuleCheck
    {
        private string _upperBaseClassName;

        public BaseClassRuleCheck(DTE2 applicationObject, string extension)
            : base(applicationObject, extension)
        {
            InputBaseClassForm frmCheckBaseClass = new InputBaseClassForm();
            if (frmCheckBaseClass.ShowDialog() == DialogResult.OK)
            {
                _upperBaseClassName = frmCheckBaseClass.BaseClassName.ToUpper();
            }
        }

        public override void DoCheck(CodeClass codeClass)
        {
            bool existBaseClass = false;
            foreach (CodeElement baseClassElement in codeClass.Bases)
            {
                string upperBaseClassName = baseClassElement.Name.ToUpper();
                if (upperBaseClassName == _upperBaseClassName || upperBaseClassName.EndsWith(_upperBaseClassName))// || upperBaseClassName.Equals("OBJECT"))
                {
                    existBaseClass = true;
                    break;
                }
            }

            if (!existBaseClass)
                Common.PrintCheckResult(OutputPane, String.Format(@"Class:{0}没有继承自指定的基类型", codeClass.FullName));
        }
    }
}
