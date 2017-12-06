using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication5.IService
{
    public interface IFile
    {
        string FileName { get; set; }
        string FileExtension { get; set; }
        string FullPathFile { get; set; }
        string ContentType { get; set; }
        string PathForHtmlCode { get; set; }
        int ContentLength { get; set; }

        void SaveUserFileOnDirectory(HttpPostedFileBase userFile, HttpServerUtilityBase server, string directory, string fileNameId);
    }
}
