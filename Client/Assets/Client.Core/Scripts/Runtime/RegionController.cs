using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Client.Core
{
    // Контроллер игрового мира.
    [DisallowMultipleComponent]
    public sealed class RegionController : MonoBehaviour
    {
        [SerializeField]
        private List<Region> _regions;

        [SerializeField]
        private Vector3 _nextRegionPosition;

        [SerializeField]
        private RegionInfo[] _regionInfos;

        private readonly RegionPool _regionPool = new();

        public void Recreate()
        {
            CreateNextRegion();
            DestroyFirstRegion();
        }

        private void CreateNextRegion()
        {
            var regionPrefab = GetNextRegionPrefab();

            if (_regionPool.TryPop(regionPrefab.name, out var region))
            {
                region.transform.position = _nextRegionPosition;
            }
            else
            {
                region = Instantiate(regionPrefab, _nextRegionPosition, Quaternion.identity, transform);
                region.name = regionPrefab.name;
            }

            _regions.Add(region);
            _nextRegionPosition.x += region.Width;
        }

        private Region GetNextRegionPrefab()
        {
            var regionInfoIndex = GetNextRegionInfoIndex();
            var regionInfo = _regionInfos[regionInfoIndex];
            var weightPart = regionInfo.Weight / _regionInfos.Length;

            for (var i = 0; i < _regionInfos.Length; i++)
            {
                if (i == regionInfoIndex)
                {
                    _regionInfos[i].Weight = 0f;
                }
                else
                {
                    _regionInfos[i].Weight += weightPart;
                }
            }

            return regionInfo.RegionPrefab;
        }

        private int GetNextRegionInfoIndex()
        {
            var totalWeight = _regionInfos.Sum(static info => info.Weight);
            var randomWeight = Random.Range(0f, totalWeight);
            var currentWeight = 0f;

            var index = 0;

            foreach (var regionInfo in _regionInfos)
            {
                currentWeight += regionInfo.Weight;

                if (currentWeight >= randomWeight)
                {
                    break;
                }

                index++;
            }

            return index;
        }

        private void DestroyFirstRegion()
        {
            var region = _regions[0];

            _regions.RemoveAt(0);
            _regionPool.Push(region);
        }

        [UsedImplicitly]
        private void Start()
        {
            CreateNextRegion();
        }
    }
}
