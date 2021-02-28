using Suricato.Ioc;
using Xamarin.Forms;

[assembly: Dependency(typeof(Suricato.Droid.Ioc.ServerEndPoint))]
namespace Suricato.Droid.Ioc
{
    public class ServerEndPoint : IEndPoint
	{

        public string MapsEndPoint = "https://maps.googleapis.com/maps/";
        public string EndPoint = "http://api.suricato.com.br:27005/mobile/";


        public string RazorEndPoint
		{
			get
			{
                // endereço produção usanddo IP
                return EndPoint;
            }
		}

		public string WebApiEndPoint
		{
            get
			{
                // endereço produção usando IP
                return EndPoint;
            }
		}

        public string GoogleMapsApiEndPoint
        {
            get
            {
                return MapsEndPoint;

            }
        }
    }
}