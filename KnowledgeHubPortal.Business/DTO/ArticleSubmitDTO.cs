using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KnowledgeHubPortal.Business.DTO
{
    public class ArticleSubmitDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [Url]
        public string ArticleUrl { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}