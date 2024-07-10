using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wissen.Istka.BlogProject.App.Entity.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Property
        public virtual List<Article> Articles { get; set; }
    }
}
