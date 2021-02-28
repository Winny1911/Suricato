namespace Suricato.Ioc
{
    public interface IRawHttp
	{
		void SetSession(ISession session, IEndPoint endPoint);
		object Get(string host, string svc, bool rawBytes, string token);
		object Post(string host, string svc, object data, bool rawBytes, string token);
        object Put(string host, string svc, object data, bool rawBytes, string token);
        string PostRazor(string host, string svc, object data, string token);
	}
}
