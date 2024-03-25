using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Client.Core.Modifiers
{
    [UsedImplicitly]
    public sealed class ModifierManager : IModifierManager
    {
        private readonly Dictionary<Type, (IModifier Modifier, float EndTime)> _modifierEntries = new();
        private readonly HashSet<Type> _expiredModifierTypes = new();

        void IModifierManager.AddModifier(IModifier modifier)
        {
            var modifierType = modifier.GetType();
            var hasModifierEntry = _modifierEntries.TryGetValue(modifierType, out var modifierEntry);
            var endTime = hasModifierEntry
                ? modifierEntry.EndTime + modifier.Duration
                : Time.time + modifier.Duration;

            _modifierEntries[modifierType] = (modifier, endTime);

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
            _expiredModifierTypes.Clear();
        }

        void IModifierManager.Update(float currentTime)
        {
            foreach (var (modifierType, modifierEntry) in _modifierEntries)
            {
                if (modifierEntry.EndTime > currentTime)
                {
                    continue;
                }

                _expiredModifierTypes.Add(modifierType);
            }

            foreach (var modifierType in _expiredModifierTypes)
            {
                if (!_modifierEntries.Remove(modifierType, out var modifierEntry))
                {
                    continue;
                }

                var (modifier, _) = modifierEntry;

                modifier.Deactivate();
            }

            _expiredModifierTypes.Clear();
        }
    }
}
