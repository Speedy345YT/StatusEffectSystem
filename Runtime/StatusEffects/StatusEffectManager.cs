using System.Collections.Generic;
using UnityEngine;

namespace EffectSystem
{
    public class StatusEffectManager : MonoBehaviour
    {
        private Dictionary<StatusEffectType, StatusEffect> activeEffects = new Dictionary<StatusEffectType, StatusEffect>();
        public void AddEffect(StatusEffect effect)
        {
            if (activeEffects.TryGetValue(effect.type, out StatusEffect foundEffect))
            {
                foundEffect.OnReapply(effect);
            } else
            {
                activeEffects.Add(effect.type, effect);
                effect.OnApply();
            }
        }
        public void RemoveEffect(StatusEffect effect)
        {
            if (activeEffects.TryGetValue(effect.type, out StatusEffect foundEffect))
            {
                foundEffect.OnRemove(effect);
                if (foundEffect.stacks < foundEffect.minStacks || foundEffect.duration < foundEffect.maxDuration)
                {
                    ClearEffect(foundEffect.type);
                }
            }
        }
        public void ClearEffect(StatusEffectType type)
        {
            if (!activeEffects.ContainsKey(type))
            {
                activeEffects[type].OnClear();
                activeEffects.Remove(type);
            }
        }

        private void TickEffects()
        {
            foreach (var effect in activeEffects)
            {
                effect.Value.OnTick();
                if (effect.Value.stacks < effect.Value.minStacks || effect.Value.duration < effect.Value.maxDuration)
                {
                    ClearEffect(effect.Value.type);
                }
            }

        }
    }
}
