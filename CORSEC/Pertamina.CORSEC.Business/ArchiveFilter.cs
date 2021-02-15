using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pertamina.CORSEC.Business
{
    public class ArchiveFilter
    {
        public ArchiveFilter() { }
        public ArchiveFilter(string archive, int begin, int end)
        {
            this.Archive = archive;
            this.Begin = begin;
            this.End = end;
            this.Display = string.Format("5 Tahun Terakhir & Archive {0}", this.Archive);
        }
        public string Archive { get; set; }
        public string Display { get; set; }
        public int Begin { get; set; }
        public int End { get; set; }

    }
}
