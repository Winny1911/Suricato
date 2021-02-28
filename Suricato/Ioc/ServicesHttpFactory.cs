using Xamarin.Forms;

namespace Suricato.Ioc
{
    static class ServicesHttpFactory
	{
		static HttpServices httpServices = null;

		private static void StartSession()
		{
			httpServices = new HttpServices(
				http: DependencyService.Get<IRawHttp>(DependencyFetchTarget.GlobalInstance),
				 session: null,
				  endPoint: DependencyService.Get<IEndPoint>(DependencyFetchTarget.GlobalInstance)
			);
		}

		internal static string Get(string svc, string token)
		{
			StartSession();
			return httpServices.GetApi(svc, token);
		}

		internal static string GetGoogleMapsApi(string svc)
		{
			StartSession();
			return httpServices.GetGoogleMapsApi(svc);
		}

		internal static byte[] GetAsArray(string svc)
		{
			StartSession();
			return httpServices.GetApiAsArray(svc);
		}
		internal static string Post(string svc, object data, string token)
		{
			StartSession();
			return httpServices.PostApi(svc, data, token);
		}
        internal static string Put(string svc, object data, string token)
        {
            StartSession();
            return httpServices.PutApi(svc, data, token);
        }
        internal static byte[] PostAsArray(string svc, object data, string token)
		{
			StartSession();
			return httpServices.PostApiAsArray(svc, data, token);
		}
		internal static string PostRazor(string svc, object data, string token)
		{
			StartSession();
			return httpServices.PostRazor(svc, data, token);
		}
	}
}
