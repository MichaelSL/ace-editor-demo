using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceEditorDemo.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AceEditorDemo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeTemplateController : ControllerBase
    {
        private readonly ICodeTemplatesRepository _codeTemplatesRepository;

        public CodeTemplateController(ICodeTemplatesRepository codeTemplatesRepository)
        {
            _codeTemplatesRepository = codeTemplatesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_codeTemplatesRepository.GetAvailableTemplates());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            return Ok(_codeTemplatesRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]CodeTemplate codeTemplate)
        {
            _codeTemplatesRepository.Save(codeTemplate);
            return Ok();
        }
    }
}