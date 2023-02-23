using EfDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface ITemplateDAL
    {
        public IQueryable<Template> GetTemplateList(string templateName);

        public Template SaveTemplate(Template template);

        public string GetTemplateBody(long templateId);

        public List<TemplateFields> SaveTemplateFields(TemplateFields templateFields);

        public Template GetTemplate(long templateId);
    }
}
