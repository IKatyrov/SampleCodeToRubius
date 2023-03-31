using Character.Player;
using Character.Shadow;

namespace Services
{
    public interface IResourceLoader
    {
        PlayerCharacter LoadPlayerCharacter();
        ShadowCharacter LoadShadowCharacter();
    }
}