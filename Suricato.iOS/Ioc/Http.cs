using Suricato.Ioc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(Suricato.iOS.Ioc.Http))]
namespace Suricato.iOS.Ioc
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

                if (!string.IsNullOrEmpty(token))
                    request.AddHeader("Authorization", string.Format("Bearer {0}", token));


                SetHeader(request);

                IRestResponse response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    throw new Exception(response.Content);

                return rawBytes ? (object)response.RawBytes : (object)response.Content;
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

        public object Post(string host, string svc, object data, bool rawBytes, string token)
        {

            var client = new RestClient(host);

            var request = new RestRequest(svc, Method.POST);
            SetHeader(request);

            //request.AddHeader("Content-Type", "application/json");

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", token);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (data != null)
                request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(response.Content);
            return rawBytes ? (object)response.RawBytes : (object)response.Content;


            //var client = new RestClient(host);
            //var request = new RestRequest(svc, Method.POST);

            //if(!string.IsNullOrEmpty(token))
            //    request.AddHeader("Authorization", token);

            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "application/json");

            //IRestResponse response = client.Execute(request);

            //switch (response.StatusCode)
            //{
            //    case System.Net.HttpStatusCode.OK:
            //        return response.Content;
            //    case 0:
            //        throw new Exception("Não foi possível conectar com o servidor remoto");
            //    case System.Net.HttpStatusCode.Unauthorized:
            //        throw new Exception("Usuário não autorizado.");
            //}

            //return null;

        }

        public object Put(string host, string svc, object data, bool rawBytes, string token)
        {

            var client = new RestClient(host);

            var request = new RestRequest(svc, Method.PUT);
            SetHeader(request);

            if (!string.IsNullOrEmpty(token))
                request.AddHeader("Authorization", token);

            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");

            if (data != null)
                request.AddJsonBody(data);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(response.Content);
            return rawBytes ? (object)response.RawBytes : (object)response.Content;

        }

        public string PostRazor(string host, string svc, object data, string token)
        {
            var client = new RestClient(host);

            var request = new RestRequest(svc, Method.POST);
            SetHeader(request);
            if (data != null)
                request.AddJsonBody(data);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception(response.Content);
            return response.Content;
        }
    }
}
