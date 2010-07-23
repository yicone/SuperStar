using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace SuperStar
{
    public class Common
    {

        public static void PrintCheckResult(OutputWindowPane superStarPane, string message)
        {
            superStarPane.OutputString(message);
            superStarPane.OutputString(Environment.NewLine);
        }

        public static string ReplaceEnterChar(string str)
        {
            return str.Replace("\r\n", "\\r\\n");
        }

        public static OutputWindowPane GetOutputWindowPane(DTE2 applicationObject, string paneName)
        {
            OutputWindowPane superStarPane;
            OutputWindow outputWindow = applicationObject.ToolWindows.OutputWindow;
            if (!ExistSuperStarOutputWindow(applicationObject, paneName))
            {
                superStarPane = outputWindow.OutputWindowPanes.Add(paneName);
            }
            else
                superStarPane = outputWindow.OutputWindowPanes.Item(paneName);

            return superStarPane;
        }

        private static bool ExistSuperStarOutputWindow(DTE2 applicationObject, string paneName)
        {
            bool exist = false;
            foreach (OutputWindowPane pane in applicationObject.ToolWindows.OutputWindow.OutputWindowPanes)
            {
                if (pane.Name == paneName)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }
    }
}
