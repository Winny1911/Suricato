using System;

namespace Suricato.Ioc
{
    public interface IHttp
	{
		byte[] PostApiAsArray(string svc, Object data, string token);
		byte[] GetApiAsArray(string svc);
	}
}
