using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AlertBAuthor
    {
        public int AlertBId { get; set; }
        public AlertB AlertB { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
