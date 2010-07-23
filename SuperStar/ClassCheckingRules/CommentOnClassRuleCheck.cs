using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;
using System.Xml;
using System.Windows.Forms;

namespace SuperStar
{
    public class CommentOnClassRuleCheck : AbstractClassRuleCheck
    {
        public CommentOnClassRuleCheck(DTE2 applicationObject, string extension)
            : base(applicationObject, extension)
        {
        }

        public override void DoCheck(CodeClass codeClass)
        {
            string comment = codeClass.DocComment;
            string summaryContent = null;
            string historyContent = null;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(comment);

                if (CheckSummaryExistsContent(xmlDoc, ref summaryContent) && CheckHistoryExistsContent(xmlDoc, ref historyContent))
                {
                    Common.PrintCheckResult(OutputPane, String.Format(@"Log:Class {0}: Summary:[{1}], History:[{2}]", codeClass.FullName, summaryContent, historyContent));
                }
                else
                    Common.PrintCheckResult(OutputPane, String.Format(@"Error:Class {0} have not correct comment! Summary:[{1}], History:[{2}]", codeClass.FullName, summaryContent, historyContent));
            }
            catch (Exception ex)
            {
                Common.PrintCheckResult(OutputPane, String.Format(@"Error:Class {0} have unclosed xml tags in class comment! Summary:[{1}], History:[{2}]", codeClass.FullName, summaryContent, historyContent));
            }
        }

        private bool CheckHistoryExistsContent(XmlDocument xmlDoc, ref string content)
        {
            XmlNode historyNode = xmlDoc.SelectSingleNode("//history");
            if (historyNode != null && !String.IsNullOrEmpty(historyNode.InnerText))
            {
                content = Common.ReplaceEnterChar(historyNode.InnerText);
                return true;
            }
            else
                return false;
        }

        private bool CheckSummaryExistsContent(XmlDocument xmlDoc, ref string content)
        {
            XmlNode summaryNode = xmlDoc.SelectSingleNode("//summary");
            if (summaryNode != null && !String.IsNullOrEmpty(summaryNode.InnerText))
            {
                content = Common.ReplaceEnterChar(summaryNode.InnerText);
                return true;
            }
            else
                return false;
        }
    }
}
