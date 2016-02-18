using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureChallenge
{
    class Program
    {

        static void Main(string[] args)
        {
            var ac = new AzureConnections();


        }


    }

    public class AzureConnections
    {
        private string SqlConnectionString =
            @"Server=tcp:oz8n00gq0x.database.windows.net,1433;Database=AW2;User ID=clintcparker@oz8n00gq0x;Password=123abc!!;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private string C_Sharp_Container = "csharp";
        public void Upload(string oldFilePath, string newFileName)
        {
            var fileStream = new FileStream(oldFilePath, FileMode.Open);
            var container = GetCloudBlobContainer();
            var blob = container.GetBlockBlobReference(newFileName);
            blob.UploadFromStream(fileStream);
        }

        public CloudBlobContainer GetCloudBlobContainer()
        {
            var cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=portalvhds5jdfv1zyqq1g3;AccountKey=bsh3TPmSif8LGxPj1wKnfqUYmIvEWPiCz74THjQYKsaDWW1fb6Bh91L64OW0bxEs403eC6VtQQw8goA0virxlg==");

            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var cloudBlobContainer = cloudBlobClient.GetContainerReference(C_Sharp_Container);

            if (!cloudBlobContainer.CreateIfNotExists()) return cloudBlobContainer;

            var permissions = cloudBlobContainer.GetPermissions();
            permissions.PublicAccess = BlobContainerPublicAccessType.Container;
            cloudBlobContainer.SetPermissions(permissions);
            return cloudBlobContainer;
        }

        public void ReadFromDB()
        {
            using (
                var conn =
                    new SqlConnection(SqlConnectionString)
                )
            {
                //conn.Open();
                //
                //var sqlCommand = conn.CreateCommand();
                //sqlCommand.CommandText = sql;
                //var sqlReader = sqlCommand.ExecuteReader();
                //while (sqlReader.Read())
                //{
                //    var columnValue = reader["<Column>"];
                //}
            }
        }
    }
}
