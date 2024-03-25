using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    public sealed class RegionController : MonoBehaviour
    {
        [SerializeField]
        private List<Region> _regions;

        [SerializeField]
        private Vector3 _nextRegionPosition;

        [SerializeField]
        private Region[] _regionPrefabs;

        public void Recreate()
        {
            CreateNextRegion();
            DestroyFirstRegion();
        }

        private void CreateNextRegion()
        {
            var regionPrefabIndex = Random.Range(0, _regionPrefabs.Length);
            var regionPrefab = _regionPrefabs[regionPrefabIndex];
            var region = Instantiate(regionPrefab, _nextRegionPosition, Quaternion.identity, transform);

            _regions.Add(region);
            _nextRegionPosition.x += region.Width;
        }

        private void DestroyFirstRegion()
        {
            var region = _regions[0];

            _regions.RemoveAt(0);

            Destroy(region.gameObject);
        }

        [UsedImplicitly]
        private void Start()
        {
            CreateNextRegion();
        }
    }
}
