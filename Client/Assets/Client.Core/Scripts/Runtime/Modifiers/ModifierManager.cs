using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core.Modifiers
{
    [UsedImplicitly]
    public sealed class ModifierManager : IModifierManager
    {
        private readonly Dictionary<string, (IModifier Modifier, float EndTime)> _modifierEntries = new(StringComparer.Ordinal);
        private readonly HashSet<string> _expiredModifierIds = new(StringComparer.Ordinal);

        void IModifierManager.AddModifier(IModifier modifier)
        {
            var hasModifierEntry = _modifierEntries.TryGetValue(modifier.Id, out var modifierEntry);
            var endTime = hasModifierEntry
                ? modifierEntry.EndTime + modifier.Duration
                : Time.time + modifier.Duration;

            _modifierEntries[modifier.Id] = (modifier, endTime);

            if (!hasModifierEntry)
            {
                modifier.Activate();
            }
        }

        void IModifierManager.Clear()
        {
            foreach (var (modifier, _) in _modifierEntries.Values)
            {
                modifier.Deactivate();
            }

            _modifierEntries.Clear();
            _expiredModifierIds.Clear();
        }

        void IModifierManager.Update(float currentTime)
        {
            foreach (var (modifierId, modifierEntry) in _modifierEntries)
            {
                if (modifierEntry.EndTime > currentTime)
                {
                    continue;
                }

                _expiredModifierIds.Add(modifierId);
            }

            foreach (var modifierId in _expiredModifierIds)
            {
                if (!_modifierEntries.Remove(modifierId, out var modifierEntry))
                {
                    continue;
                }

                var (modifier, _) = modifierEntry;

                modifier.Deactivate();
            }

            _expiredModifierIds.Clear();
        }
    }
}
