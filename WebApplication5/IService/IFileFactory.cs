using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.IService
{
    public interface IFileFactory
    {
        IFile CreateObjOf(string typeName);
    }
}
