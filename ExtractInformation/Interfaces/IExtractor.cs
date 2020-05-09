using System.Threading.Tasks;

namespace ExtractInformation.Interfaces
{
    public interface IExtractor
    {
        bool IsEnabled();
        string GetConnectionString();
        string GetQuery();
        Task ExecuteAsync();
    }
}
