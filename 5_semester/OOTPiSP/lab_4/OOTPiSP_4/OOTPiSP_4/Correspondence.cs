using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOTPiSP_4
{
    public class Correspondence
    {
        public Correspondence(int IdCorrespondence, string Content)
        {
            this.IdCorrespondence = IdCorrespondence;
            this.Content = Content;
        }
        public int IdCorrespondence { get; set; }
        public string Content {  get; set; }
    }
}
