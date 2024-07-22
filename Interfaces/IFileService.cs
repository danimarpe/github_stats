using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace github_stats.Interfaces
{
    public interface IFileService
    {
        IList<IFile> Sort(IEnumerable<IFile> files);

        void Print(IEnumerable<IFile> files);
    }
}
