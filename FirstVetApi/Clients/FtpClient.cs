using System.IO;
using System.Text;
using RestSharp;

namespace FirstVetApi.Clients
{
    public class FtpClient
    {

        // Ftp client not implemented yet, using file on filesystem to mock data from FTP
        public FtpClient()
        {
        }

        public string Get(string filePath) {
            using (var streamReader = new StreamReader(filePath, Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }


    }



}
