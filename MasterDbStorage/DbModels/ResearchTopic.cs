using System;
using System.Collections.Generic;
using System.Text;

namespace MasterDbStorage.DbModels
{
    public class ResearchTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public Researcher Author { get; set; }
    }
}
