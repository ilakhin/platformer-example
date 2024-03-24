using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core
{
    [DisallowMultipleComponent]
    internal sealed class RegionController : MonoBehaviour, ITriggerHandler
    {
        [SerializeField]
        private List<Region> _regions;

        [SerializeField]
        private Vector3 _nextRegionPosition;

        [SerializeField]
        private Region _regionPrefab;

        private void CreateNextRegion()
        {
            var region = Instantiate(_regionPrefab, _nextRegionPosition, Quaternion.identity, transform);

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

        void ITriggerHandler.OnEnter()
        {
            CreateNextRegion();
            DestroyFirstRegion();
        }
    }
}
