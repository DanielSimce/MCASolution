using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mca
{
    public class NavModel
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public int? ParentId { get; set; }
        public bool IsHidden { get; set; }
        public string LinkUrl { get; set; }
        public int Level { get; set; }

        public List<NavModel> Children { get; set; }
    }
}
