using System;
using System.Collections.Generic;
using System.Text;
using Suricato.Ioc;
using Xamarin.Forms;

[assembly: Dependency(typeof(Suricato.iOS.Ioc.ServerEndPoint))]
namespace Suricato.iOS.Ioc
{
	public class ServerEndPoint : IEndPoint
	{

        public string EndPoint = "https://api.suricato.com.br:8443/mobile/";
        public string MapsEndPoint = "https://maps.googleapis.com/maps/";


        public string RazorEndPoint
		{
			get
			{
                return EndPoint;
			}
		}

		public string WebApiEndPoint
		{
			get
			{
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
