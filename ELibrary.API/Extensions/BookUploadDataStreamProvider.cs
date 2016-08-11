using ELibrary.API.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace ELibrary.API.Extensions
{
    public class BookUploadDataStreamProvider: MultipartFormDataStreamProvider
    {

        public BookUploadDataStreamProvider(string rootPath):base(rootPath)
        {

        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
            var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)
              ? headers.ContentDisposition.FileName
              : "NoName";

            return name.Trim('"').Replace("&", "and");
        }


    }
}