using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTask.Application.Interfaces.Services
{
    public interface IFileProvider
    {
        string GetHtmlTemplatePath(string templateName);
    }

}
