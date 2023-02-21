using EfDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class TemplateDAL : ITemplateDAL
    {
        private readonly EmployeeDBContext _context;
        public TemplateDAL(EmployeeDBContext context)
        {
            _context = context;
        }
        public IQueryable<Template> GetTemplateList(string templateName)
        {
            if (!string.IsNullOrWhiteSpace(templateName))
            {
                return _context.Template.Where(x => (EF.Functions.Like(x.Name, $"%{templateName}%")));
            }
            return _context.Template;
        }

        public Template SaveTemplate(Template template)
        {
            if (template.Id == 0)
            {
                _context.Template.Add(template);
            }
            else
            {
                _context.Template.Update(template);
            }
            _context.SaveChanges();
            return template;
        }

        public string GetTemplateBody(long templateId)
        {
            var templateDetails = _context.Template.FirstOrDefault(x => x.Id == templateId);
            return templateDetails != null && !string.IsNullOrWhiteSpace(templateDetails.Body) ? templateDetails.Body : "";
        }
    }
}
