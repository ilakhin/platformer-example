using System;
using UnityEditor;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Client.Foundation
{
    [Serializable]
    public sealed class SceneReference : AssetReference
    {
        public SceneReference(string guid)
            : base(guid)
        {
        }

#if UNITY_EDITOR
        public override bool ValidateAsset(Object obj)
        {
            return obj is SceneAsset;
        }

        public override bool ValidateAsset(string path)
        {
            return path.EndsWith(".unity", StringComparison.Ordinal);
        }
#else
        public override bool ValidateAsset(Object obj)
        {
            return false;
        }

        public override bool ValidateAsset(string path)
        {
            return false;
        }
#endif
    }
}
