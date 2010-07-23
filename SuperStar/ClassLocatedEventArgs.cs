using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace SuperStar
{
    public class ClassLocatedEventArgs : EventArgs
    {
        private CodeClass _codeClass;

        public CodeClass CodeClass
        {
            get { return _codeClass; }
            set { _codeClass = value; }
        }

        public ClassLocatedEventArgs(CodeClass codeClass)
        {
            _codeClass = codeClass;
        }
    }
}
