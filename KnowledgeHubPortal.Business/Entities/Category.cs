using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KnowledgeHubPortal.Business.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        [MinLength(5)]
        public string Description { get; set; }
    }
}
