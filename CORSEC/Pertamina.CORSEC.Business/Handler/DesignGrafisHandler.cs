using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ionic.Zip;
using Pertamina.CORSEC.Dta;
using Pertamina.CORSEC.Dto;

namespace Pertamina.CORSEC.Business.Handler
{
    public class DesignGrafisHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;
            string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
            try
            {
                int ID = 0;
                string id = request["id"];
                int.TryParse(id, out ID);

                List<tbl_Design_Grafis_File> files = tbl_Design_Grafis_FileItem.GetByFK(ID);
                string filePath = string.Empty;
                using (Ionic.Zip.ZipFile zip = new ZipFile())
                {
                    zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                    //create folder inside zip
                    zip.AddDirectoryByName("Files");
                    int counter = 1;
                    foreach (tbl_Design_Grafis_File file in files)
                    {
                        // add binary file
                        zip.AddEntry(string.Format("Files\\{0}.{1}", counter, file.file_name), file.file_blob);
                        counter++;
                    }

                    response.Clear();
                    response.BufferOutput = false;

                    response.ContentType = "application/zip";
                    response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                    zip.Save(response.OutputStream);
                    response.End();
                }


                Log.Info(string.Format("File {0} downloaded successfully by {1}", zipName, Utilities.Username));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
    }
}
