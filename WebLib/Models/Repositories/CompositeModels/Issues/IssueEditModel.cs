using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebLib.Models.Repositories.CompositeModels.Issues
{
    public class IssueEditModel
    {
        public IssueModel Issue { get; set; }

        public SelectList Readers { get; set; }

        public SelectList Books { get; set; }

        public SelectList Authors { get; set; }

        public int SelectedReader { get; set; }

        public int SelectedBook { get; set; }
    }
}
