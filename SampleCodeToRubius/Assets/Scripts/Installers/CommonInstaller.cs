using Services;
using Zenject;

namespace Installers
{
    public sealed class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Logger>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourceLoader>().FromNew().AsSingle();
        }
    }
}