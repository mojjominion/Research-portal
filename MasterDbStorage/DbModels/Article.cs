using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class Article : BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public ResearchTopic ResearchTopic { get; set; }
    }
}
