using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels.Issues
{
    public class IssueViewModel
    {
        public AuthorModel Author { get; set; }

        public BookModel Book { get; set; }

        public ReaderModel Reader { get; set; }

        public IssueModel Issue { get; set; }
    }
}
