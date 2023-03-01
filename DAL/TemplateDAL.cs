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
                template.CreatedDate = DateTime.UtcNow;
                template.StatusId = template.StatusId == 0 ? 1 : template.StatusId;
                 
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

        public List<TemplateFields> SaveTemplateFields(TemplateFields templateFields)
        {
            if(templateFields.Id == 0)
            {
                _context.TemplateFields.Add(templateFields);
            }
            else
            {
                _context.TemplateFields.Update(templateFields);
            }
            _context.SaveChanges();
            return _context.TemplateFields.Where(x => x.TemplateId == templateFields.TemplateId).ToList();
        }
        public Template GetTemplate(long templateId)
        {
            return _context.Template.Include(x => x.templateFields).FirstOrDefault(x => x.Id == templateId);
        }

        public bool DeleteTemplate(Template template)
        {
            _context.Template.Remove(template);
            _context.SaveChanges();
            return true;
        }
    }
}
