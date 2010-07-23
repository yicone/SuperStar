using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;

namespace SuperStar
{
    public class ClassLocatingProxy
    {
        private DTE2 _applicationObject;
        private string _extension = ".cs";

        public ClassLocatingProxy(DTE2 applicationObject, string extension)
        {
            _applicationObject = applicationObject;
            if(extension != null)
                _extension = extension;
        }

        public void CheckEachClassInActiveProject()
        {
            object[] projects = (object[])_applicationObject.ActiveSolutionProjects;
            foreach (Project project in projects)
            {
                foreach (ProjectItem projectItem in project.ProjectItems)
                {
                    CheckFileCodeModel(projectItem.FileCodeModel);
                    RecursiveCheckChildProjectItems(projectItem);
                }
            }
        }

        private void RecursiveCheckChildProjectItems(ProjectItem projectItem)
        {
            foreach (ProjectItem childProjectItem in projectItem.ProjectItems)
            {
                CheckFileCodeModel(childProjectItem.FileCodeModel);
                RecursiveCheckChildProjectItems(childProjectItem);
            }
        }

        private void CheckFileCodeModel(FileCodeModel fileCodeModel)
        {
            if (fileCodeModel != null && fileCodeModel.Parent.Name.EndsWith(_extension))
            {
                foreach (CodeElement codeElement in fileCodeModel.CodeElements)
                {
                    if (codeElement.Kind == vsCMElement.vsCMElementNamespace)
                    {
                        foreach (CodeElement childElement in codeElement.Children)
                        {
                            if (childElement.IsCodeType)
                            {
                                CodeClass codeClass = childElement as CodeClass;
                                if (codeClass != null)
                                {
                                    //_classRuleHandler.Invoke(codeClass, _superStarPane, _upperBaseClassName);
                                    OnClassLocated(new ClassLocatedEventArgs(codeClass));
                                }
                            }
                        }
                    }
                }
            }
        }//END METHOD

        public event EventHandler ClassLocated;

        protected virtual void OnClassLocated(EventArgs e)
        {
            if (ClassLocated != null)
            {
                ClassLocated(this, e);
            }
        }
    }
}
