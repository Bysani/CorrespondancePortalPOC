using System;
using System.Collections.Generic;
using System.Text;

namespace EfDBContext
{
    public class Template
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public long StatusId { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TemplateStatus Status { get; set; }
    }
}
