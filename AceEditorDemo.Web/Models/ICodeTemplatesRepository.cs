using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AceEditorDemo.Web.Models
{
    public interface ICodeTemplatesRepository
    {
        IList<string> GetAvailableTemplates();
        CodeTemplate Get(string id);
        void Save(CodeTemplate codeTemplate);
    }

    public class CodeTemplatesRepository : ICodeTemplatesRepository
    {
        private readonly List<CodeTemplate> _codeTemplates = new List<CodeTemplate>
        {
            new CodeTemplate
            {
                Id = "Form1",
                TemplateText = "function dbl(p){\nreturn p * 2; }"
            },
            new CodeTemplate
            {
                Id = "Form2",
                TemplateText = "dbl = (p) => p * 2;"
            }
        };
        public CodeTemplate Get(string id)
        {
            return _codeTemplates.SingleOrDefault(_ => _.Id == id);
        }

        public IList<string> GetAvailableTemplates()
        {
            return _codeTemplates.Select(_ => _.Id).ToList();
        }

        public void Save(CodeTemplate codeTemplate)
        {
            var template = _codeTemplates.SingleOrDefault(_ => _.Id == codeTemplate.Id);
            if (template != null)
            {
                _codeTemplates.Remove(template);
                
            }
            _codeTemplates.Add(codeTemplate);
        }
    }
}
