using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLib.Models.Repositories.CompositeModels
{
    public class ReaderAccount
    {
        public ReaderModel Reader { get; set; }

        public UserModel User { get; set; }
    }
}
