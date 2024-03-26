using System;
using System.Collections.Generic;

namespace Client.Core
{
    public sealed class RegionPool
    {
        private readonly Dictionary<string, Stack<Region>> _regions = new(StringComparer.Ordinal);

        public void Push(Region region)
        {
            var id = region.name;

            if (!_regions.TryGetValue(id, out var regions))
            {
                _regions[id] = regions = new Stack<Region>();
            }

            region.gameObject.SetActive(false);
            regions.Push(region);
        }

        public bool TryPop(string id, out Region region)
        {
            if (!_regions.TryGetValue(id, out var regions))
            {
                region = default;

                return false;
            }

            if (!regions.TryPop(out region))
            {
                region = default;

                return false;
            }

            region.gameObject.SetActive(true);

            return true;
        }
    }
}
