using System;

namespace Suricato.Ioc
{
    public interface IJsonHttp
	{
		string PostApi(string svc, Object data, string token);
        string PutApi(string svc, Object data, string token);
        string GetApi(string svc, string token);
	}
}
