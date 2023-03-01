using System;
using System.Collections.Generic;
using System.Text;

namespace EfDBContext
{
    public class TemplateFields
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string DataType { get; set; }
        public long TemplateId { get; set; }
        public bool IsMandatory { get; set; }
        public bool IsSelected { get; set; }
        public virtual Template Template { get; set; }
    }
}
