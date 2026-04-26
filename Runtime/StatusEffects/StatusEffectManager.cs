using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Unity.VisualScripting.YamlDotNet.Core.Events;

namespace EffectSystem
{
    public class StatusEffectManager : MonoBehaviour
    {
        [DictionaryDrawerSettings]public Dictionary<StatusEffectType, StatusEffect> activeEffects = new Dictionary<StatusEffectType, StatusEffect>();
        Dictionary<StatusEffectType, StatusEffect> snapshot { get { return new Dictionary<StatusEffectType, StatusEffect>(activeEffects); } }
        public void AddEffect(StatusEffect effect)
        {
            if (snapshot.TryGetValue(effect.type, out StatusEffect foundEffect))
            {
                foundEffect.OnReapply(effect);
                if (foundEffect.maxStacks > 0)
                {
                    foundEffect.stacks = Mathf.Min(foundEffect.stacks, foundEffect.maxStacks);
                }
                
                if (foundEffect.maxDuration > 0)
                {
                    foundEffect.duration = Mathf.Min(foundEffect.duration, foundEffect.duration);
                }
            } else
            {
                activeEffects.Add(effect.type, effect);
                effect.OnApply(this.gameObject);
            }
        }
        public void RemoveEffect(StatusEffect effect)
        {
            if (snapshot.TryGetValue(effect.type, out StatusEffect foundEffect))
            {
                foundEffect.OnRemove(effect);
                if (foundEffect.stacks < foundEffect.minStacks || foundEffect.duration < foundEffect.maxDuration)
                {
                    ClearEffect(foundEffect.type);
                }
                foundEffect.stacks = Mathf.Max(foundEffect.stacks, foundEffect.minStacks);
                foundEffect.duration = Mathf.Max(foundEffect.duration, foundEffect.minStacks);
            }
        }
        public void ClearEffect(StatusEffectType type)
        {
            if (snapshot.ContainsKey(type))
            {
                activeEffects[type].OnClear();
                activeEffects.Remove(type);
            }
        }
        private void Update()
        {
            TickEffects();
        }
        private void TickEffects()
        {
            foreach (var effect in snapshot)
            {
                effect.Value.OnTick();
                if (effect.Value.stacks < effect.Value.minStacks || effect.Value.duration <= 0)
                {
                    ClearEffect(effect.Value.type);
                }
            }
        }
    }
}
