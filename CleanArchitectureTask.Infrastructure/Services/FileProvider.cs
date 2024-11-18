using CleanArchitectureTask.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTask.Infrastructure.Services
{
    public class FileProvider : IFileProvider
    {
        private readonly string _basePath;

        public FileProvider(string basePath)
        {
            _basePath = basePath; // Injected base path
        }

        public string GetHtmlTemplatePath(string templateName)
        {
            // Combine base path and template name to get the full path
            return Path.Combine(_basePath,"TemplateHtmls",templateName);
        }
    }
}
