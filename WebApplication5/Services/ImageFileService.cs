using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.IService;
using System.IO;

namespace WebApplication5.Services
{
    public class ImageFileService : IFile
    {
        private string fileName;
        private string fileExtension;
        private string fullPathFile;
        private string contentType;
        private string pathForHtmlCode;
        private int contentLength;

        public void SaveUserFileOnDirectory(HttpPostedFileBase userFile, HttpServerUtilityBase server, string directory, string fileNameId)
        {
            contentLength = userFile.ContentLength;
            if (IsAllowed())
            {
                contentType = userFile.ContentType;
                fileName = userFile.FileName;
                fileExtension = Path.GetExtension(fileName);
                fileName = fileNameId + fileExtension;
                fullPathFile = Path.Combine(server.MapPath(directory), fileName);
                pathForHtmlCode = directory + fileName; //TODO: It could be done with events (Better way)
                //SaveAs() is working only with full path only
                userFile.SaveAs(fullPathFile);
            }
        }

        protected bool IsAllowed()
        {
            if (contentLength < 5000000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PathForHtmlCode
        {
            get
            {
                return pathForHtmlCode;
            }
            set
            {
                pathForHtmlCode = value;
            }
        }

        public int ContentLength
        {
            get
            {
                return contentLength;
            }
            set
            {
                contentLength = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public string FileExtension
        {
            get
            {
                return fileExtension;
            }
            set
            {
                fileExtension = value;
            }
        }

        public string FullPathFile
        {
            get
            {
                return fullPathFile;
            }
            set
            {
                fullPathFile = value;
            }
        }

        public string ContentType
        {
            get
            {
                return contentType;
            }
            set
            {
                contentType = value;
            }
        }
    }
}