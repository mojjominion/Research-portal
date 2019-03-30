using MasterDbStorage.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResearchPortal.Areas.Portal.Models
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlContent { get; set; }
        public ResearchTopic ResearchTopic { get; set; }
        public Researcher Author { get; set; }
        public string TopicName { get; set; }
        public string AuthorName { get; set; }

        public ArticleViewModel FromDbModel(Article article)
        {
            return new ArticleViewModel()
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                HtmlContent = article.HtmlContent,
                TopicName = article.ResearchTopic != null ? article.ResearchTopic.Name : "NA",
                AuthorName = article.Author != null ? article.Author.UserName : "NA",
            };
        }
    }
}
