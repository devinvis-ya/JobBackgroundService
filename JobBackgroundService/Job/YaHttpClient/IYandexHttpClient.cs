using System.Threading.Tasks;
using Job.DBModel;

namespace Job.YaHttpClient
{
    public interface IYandexHttpClient
    {
        Task<string> GetWeatherByPlace(Place place);
    }
}