using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using System.Windows.Forms;

namespace SuperStar
{
    public class RuleCheckFactory
    {
        public static IClassRuleCheck GetRuleCheck(DTE2 applicationObject, string ruleName, string extension)
        {
            IClassRuleCheck classRuleCheck = null;
            switch(ruleName)
            {
                case "BaseClassRule":
                    classRuleCheck = new BaseClassRuleCheck(applicationObject, extension);
                    break;
                case "CommentOnClassRule":
                    classRuleCheck = new CommentOnClassRuleCheck(applicationObject, extension);
                    break;
                default:
                    MessageBox.Show(string.Format("{0}规则不存在.", ruleName));
                    break;
            }

            return classRuleCheck;
        }
    }
}
