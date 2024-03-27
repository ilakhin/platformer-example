using Client.Foundation;
using UnityEngine;

namespace Client.Bootstrap
{
    // Конфигурация Main.
    [CreateAssetMenu]
    public sealed class MainConfig : ScriptableObject
    {
        [SerializeField]
        private SceneReference _coreSceneReference;

        public SceneReference CoreSceneReference => _coreSceneReference;
    }
}
