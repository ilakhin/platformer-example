using Client.Foundation;
using UnityEngine;

namespace Client.Bootstrap
{
    [CreateAssetMenu]
    internal sealed class MainSettings : ScriptableObject
    {
        [SerializeField]
        private SceneReference _coreSceneReference;

        public SceneReference CoreSceneReference => _coreSceneReference;
    }
}
