using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;
using System.Windows.Forms;

namespace SuperStar
{
    public class ClassUsingRuleCheck : AbstractClassRuleCheck
    {
        public ClassUsingRuleCheck(DTE2 applicationObject, string extension)
            : base(applicationObject, extension)
        {
        }

        public override void DoCheck(CodeClass codeClass)
        {
            //ApplicationObject.Find.FindWhat(codeClass.Name);
            ApplicationObject.Find.SearchPath = "Entire Solution";
            ApplicationObject.ExecuteCommand("Edit.FindinFiles", codeClass.Name);
            Window findSymbolResultWindow = ApplicationObject.Windows.Item(Constants.vsWindowKindFindResults1);
            string results = findSymbolResultWindow.Caption.ToString();
        }
    }
}
