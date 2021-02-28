namespace Suricato.Ioc
{
    internal class HttpServices : IHttp, IJsonHttp
	{
		ISession session = null;
		IEndPoint endPoint = null;
		IRawHttp http = null;
		public HttpServices(IRawHttp http, ISession session, IEndPoint endPoint)
		{
			this.http = http;
			this.session = session;
			this.endPoint = endPoint;
			this.http.SetSession(session, endPoint);
		}
		
		public string PostApi(string svc, object data, string token)
		{
			return http.Post(endPoint.WebApiEndPoint, svc, data, false, token) as string;
		}

        public string PutApi(string svc, object data, string token)
        {
            return http.Put(endPoint.WebApiEndPoint, svc, data, false, token) as string;
        }

        public string GetGoogleMapsApi(string svc)
		{
            return "";// http.Get(endPoint.GoogleMapsApiEndPoint, svc, false, "") as string;
		}

		public string GetApi(string svc, string token="")
		{
			return http.Get(endPoint.WebApiEndPoint, svc, false, token) as string;
		}

		public byte[] PostApiAsArray(string svc, object data, string token)
		{
			return http.Post(endPoint.WebApiEndPoint, svc, data, true, token) as byte[];
		}

		public byte[] GetApiAsArray(string svc)
		{
			return http.Get(endPoint.WebApiEndPoint, svc, true, "") as byte[];
		}
		public string PostRazor(string svc, object data, string token)
		{
			return http.PostRazor(endPoint.RazorEndPoint, svc, data, token);
		}
	}
}
