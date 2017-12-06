using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.IService;

namespace WebApplication5.Services
{
    public class ConcreteFileFactory : IFileFactory
    {
        public IFile CreateObjOf(string typeName)
        {
            if (typeName == ".png" || typeName == ".jpg")
            {
                return new ImageFileService();
            }
            else
            {
                return null;
            }
        }
    }
}