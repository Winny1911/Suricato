using System.Threading.Tasks;

namespace Suricato.Ioc
{
    public interface IQrCodeScanningService
	{
		Task<string> ScanAsync();
	}
}
