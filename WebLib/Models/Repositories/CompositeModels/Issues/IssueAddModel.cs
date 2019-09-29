using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLib.Models.Repositories.CompositeModels.Issues
{
    public class IssueAddModel
    {
        public AuthorModel Author { get; set; }

        public BookModel Book { get; set; }

        public IssueModel Issue { get; set; }

        public SelectList Readers { get; set; }
        
        public int SelectedReader { get; set; }
    }
}
