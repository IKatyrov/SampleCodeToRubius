using Services;
using Zenject;

namespace Installers
{
    public sealed class ListenerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputListener>().FromNew().AsSingle();
        }
    }
}