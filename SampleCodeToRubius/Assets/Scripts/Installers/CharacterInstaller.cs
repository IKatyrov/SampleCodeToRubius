using Services;
using Zenject;

namespace Installers
{
    public sealed class CharacterInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CharactersProvider>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<CharactersFactory>().FromNew().AsSingle();
        }
    }
}