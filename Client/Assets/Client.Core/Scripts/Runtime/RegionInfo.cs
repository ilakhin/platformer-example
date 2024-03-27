using System;
using UnityEngine;

namespace Client.Core
{
    // Информация о сегменте (префаб, вес для генерации).
    [Serializable]
    public sealed class RegionInfo
    {
        [SerializeField]
        private Region _regionPrefab;

        [SerializeField]
        private float _weight;

        public Region RegionPrefab => _regionPrefab;

        public float Weight
        {
            get => _weight;
            set => _weight = value;
        }
    }
}
