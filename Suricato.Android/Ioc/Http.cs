using System;
using RestSharp;
using System.Globalization;
using Xamarin.Forms;
using Suricato.Ioc;
using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Reflection;

[assembly: Dependency(typeof(Suricato.Droid.Ioc.Http))]
namespace Suricato.Droid.Ioc
{
    public class Http : IRawHttp
    {
        ISession session = null;
        IEndPoint endPoint;

        public Http()
        {

        }

        protected Http(ISession session, IEndPoint endPoint)
        {
            this.session = session;
            this.endPoint = endPoint;
        }

        public void SetSession(ISession session, IEndPoint endPoint)
        {
            this.session = session;
            this.endPoint = endPoint;
        }

        public object Get(string host, string svc, bool rawBytes, string token)
        {
            try
            {
                var client = new RestClient(host);

                var request = new RestRequest(svc, Method.GET);

                if(!string.IsNullOrEmpty(token))
                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));


                SetHeader(request);

                IRestResponse response = client.Execute(request);

                if (AnalisaStatusRetornoAPI(response.StatusCode)){
                    return rawBytes ? (object)response.RawBytes : (object)response.Content;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }

        }

        private void SetHeader(RestRequest request)
        {
            request.AddHeader("Accept", "application/json");
        }

        private void SetCertificate(ref RestClient client)
        {
            string x = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(x,"cert/suricato_api.csr");
         //   string f2 = Android.OS.Environment.ExternalStorageDirectory + Java.IO.File.Separator + "Cert";
        //    string certificatesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Cert");
            X509Certificate2 certificates = new X509Certificate2();
            certificates.Import(path);
            client.ClientCertificates = new X509CertificateCollection(){certificates};
        }


        public object Post(string host, string svc, object data, bool rawBytes, string token)
        {

            var client = new RestClient(host);

           // SetCertificate(ref client);

            var request = new RestRequest(svc, Method.POST);
            SetHeader(request);

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", token);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (data != null)
                request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

           // if (AnalisaStatusRetornoAPI(response.StatusCode)){
                return rawBytes ? (object)response.RawBytes : (object)response.Content;
           // }
           // else
           // {
           //     return null;
           // }
        }

        public object Put(string host, string svc, object data, bool rawBytes, string token)
        {

            var client = new RestClient(host);
            var request = new RestRequest(svc, Method.PUT);

            request.RequestFormat = DataFormat.Json;

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", string.Format("Bearer {0}", token));

            request.AddHeader("Accept", "application/json");
            request.AddBody(data);

            IRestResponse response = client.Execute(request);

            if (AnalisaStatusRetornoAPI(response.StatusCode)){
                return rawBytes ? (object)response.RawBytes : (object)response.Content;
            }
            else{
                return null;
            }
        }

        public string PostRazor(string host, string svc, object data, string token)
        {
            var client = new RestClient(host);

            var request = new RestRequest(svc, Method.POST);
            SetHeader(request);
            if (data != null)
                request.AddJsonBody(data);
            IRestResponse response = client.Execute(request);
            if (AnalisaStatusRetornoAPI(response.StatusCode))
            {
                return response.Content;
            }
            else
            {
                return null;
            }
        }
        
        private bool AnalisaStatusRetornoAPI(HttpStatusCode code)
        {
            //esse switch pode ser implementado em diversas situações
            switch (code)
            {
                case System.Net.HttpStatusCode.OK:
                case System.Net.HttpStatusCode.Created:
                    return true;
                case 0:
                case HttpStatusCode.BadGateway:
                    throw new Exception("Não foi possível conectar com o servidor remoto");
                case System.Net.HttpStatusCode.Unauthorized:
                    throw new Exception("Usuário não autorizado.");
                case System.Net.HttpStatusCode.GatewayTimeout:
                case System.Net.HttpStatusCode.RequestTimeout:
                    throw new Exception("Conexão com o servidor encerrada por tempo limite.");
                case HttpStatusCode.BadRequest:
                    throw new Exception("Chamada ao inválida ao servidor.");
                default:
                    return false;
            }
        }
    }
}