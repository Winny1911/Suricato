namespace Suricato.Ioc
{
    public interface ISession
	{
		string AccessCode { get; }
		long WinId { get; }
		string Culture { get; }
		double? Latitude { get; }
		double? Longitude { get; }
	}
}
