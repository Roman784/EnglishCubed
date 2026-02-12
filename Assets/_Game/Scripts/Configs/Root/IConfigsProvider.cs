using R3;

namespace Configs
{
    public interface IConfigsProvider
    {
        public GameConfigs GameConfigs { get; }
        public Observable<bool> LoadGameConfigs();
    }
}
