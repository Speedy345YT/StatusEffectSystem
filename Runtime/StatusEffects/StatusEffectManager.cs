using System.Collections.Generic;
using UnityEngine;

namespace EffectSystem
{
    public class StatusEffectManager : MonoBehaviour
    {
        public List<StatusEffect> activeEffects = new List<StatusEffect>();
        List<StatusEffect> snapshot { get { return new List<StatusEffect>(activeEffects); } }
        public void AddEffect(StatusEffect effect)
        {
            StatusEffect foundEffect = snapshot.Find(x => x.type == effect.type);
            if (foundEffect != null)
            {
                foundEffect.OnReapply(effect);
                if (foundEffect.maxStacks > 0)
                {
                    foundEffect.stacks = Mathf.Min(foundEffect.stacks, foundEffect.maxStacks);
                }
                
                if (foundEffect.maxDuration > 0)
                {
                    foundEffect.duration = Mathf.Min(foundEffect.duration, foundEffect.maxDuration);
                }
            } else
            {
                activeEffects.Add(effect);
                effect.OnApply(this.gameObject);
            }
        }
        public void RemoveEffect(StatusEffect effect)
        {
            StatusEffect foundEffect = snapshot.Find(x => x.type == effect.type);
            if (foundEffect != null)
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
        public void ClearEffect(string type)
        {
            StatusEffect foundEffect = snapshot.Find(x => x.type == type);
            if (foundEffect != null)
            {
                foundEffect.OnClear();
                activeEffects.Remove(foundEffect);
            }
        }
        public bool HasEffect(string type, out StatusEffect effect)
        {
            StatusEffect foundEffect = snapshot.Find(x => x.type == type);
            if (foundEffect != null)
            {
                effect = foundEffect;
                return true;
            }
            effect = null;
            return false;
        }
        public void TickEffects(string eventName)
        {
            foreach (var effect in snapshot)
            {
                if (effect.triggerName == eventName)
                {
                    effect.OnTick();
                    if (effect.stacks <= effect.minStacks || effect.duration == 0)
                    {
                        ClearEffect(effect.type);
                        return;
                    }
                }
            }
        }
    }
}
