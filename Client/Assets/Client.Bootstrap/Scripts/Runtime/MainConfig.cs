using Client.Foundation;
using UnityEngine;

namespace Client.Bootstrap
{
    [CreateAssetMenu]
    public sealed class MainConfig : ScriptableObject
    {
        [SerializeField]
        private SceneReference _coreSceneReference;

        public SceneReference CoreSceneReference => _coreSceneReference;
    }
}
