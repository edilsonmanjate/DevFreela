using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Exceptions
{
    public class ProjectAlreadStartedExeption : Exception
    {
        public ProjectAlreadStartedExeption() : base("Project alread started status")
        {

        }
    }
}
