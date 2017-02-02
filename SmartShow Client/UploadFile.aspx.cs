using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartShow_Client.Models;

namespace SmartShow_Client
{
    public partial class UploadFile : System.Web.UI.Page
    {
        static HttpClient client;
        static ApiConnectionClass<AllowedFileTypes> allowedFileApiInterface;
        static ApiConnectionClass<Filedata> fileDataApiInterface;
        string allowedFileApiPath = ConfigurationManager.AppSettings["ServerBaseUri"].ToString() + "api/v1/allowedfiletype";
        string fileDataApiPath = ConfigurationManager.AppSettings["ServerBaseUri"].ToString() + "api/v1/file";

        static UploadFile()
        {

            client = new HttpClient();
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerBaseUri"].ToString());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            allowedFileApiInterface = new ApiConnectionClass<AllowedFileTypes>(client);
            fileDataApiInterface = new ApiConnectionClass<Filedata>(client);

            //var allowedFileTypes = allowedFileApiInterface.CallGetAPiReturningList(allowedFileApiPath);
        }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void fuUploadFile_DataBinding(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (fuUploadFile.HasFile)
            {

                Byte[] filebyteArray = null;

                using (var binaryReader = new BinaryReader(fuUploadFile.PostedFile.InputStream))
                {
                    filebyteArray = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                ByteArrayContent audioFileContent = new ByteArrayContent(filebyteArray);
                //audioFileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("audio/mpeg");

                //var requestContent = new StreamContent(new FileStream(fileName, FileMode.Open));
                var requestContent = new StreamContent(fuUploadFile.FileContent);
                //requestContent.Add(audioFileContent, "audio", filePathToUpload);
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

                    client.BaseAddress = new Uri("http://www.filestackapi.com");

                    var result = client.PostAsync("/api/store/S3?key=" + ConfigurationManager.AppSettings["FilePickerApiKey"].ToString(), requestContent).Result;
                    string uploadedFileUrl = "";

                    if (result.IsSuccessStatusCode)
                    {
                        uploadedFileUrl = JObject.Parse(result.Content.ReadAsStringAsync().Result)["url"].ToString();
                         Response.Write("<script>alert('File Uploaded Successfully');</script>");
                        
                            //    lblMessage.Text = "File Uploaded Successfully";
                            //  lblMessage.ForeColor = System.Drawing.Color.Green;
                            var fileUploaded = new Filedata()
                        {
                            Url = uploadedFileUrl,
                            Name = fuUploadFile.FileName,
                            Type = "1"
                        };

                        fileDataApiInterface.CallPostAPi(fileDataApiPath, fileUploaded);
                    }
                    else
                    {
                        Response.Write("<script>alert('File Uploading Failed, Internal Server Error');</script>");
                        //      lblMessage.Text = "File Uploading Failed, Internal Server Error";
                        //    lblMessage.ForeColor = System.Drawing.Color.DarkRed;
                    }

                }
            }
            else
            {
                
                Response.Write("<script>alert('File Missing');</script>");
                //lblMessage.Text = "File Not Found";
                //lblMessage.ForeColor = System.Drawing.Color.Red;
            }


        }
    }
}