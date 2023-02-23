using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EfDBContext
{
    public class Template
    {
        public Template()
        {
            templateFields = new HashSet<TemplateFields>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public long StatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TemplateStatus Status { get; set; }
        public virtual ICollection<TemplateFields> templateFields { get; set; }
        [NotMapped]
        public string StatusName { get; set; }
    }
}
