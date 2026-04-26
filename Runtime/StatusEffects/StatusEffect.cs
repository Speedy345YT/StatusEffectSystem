using UnityEngine;

namespace EffectSystem
{
    [System.Serializable]
    public abstract class StatusEffect
    {
        public int duration; //-1 = permanent
        public int maxDuration;
        public int minStacks;
        public int stacks;
        public int maxStacks;
        public StatusEffectType type;
        public StatusEffect(int duration, int maxDuration, int stacks, int minStacks, int maxStacks, StatusEffectType type)
        {
            this.duration = duration;
            this.maxDuration = maxDuration;
            this.stacks = stacks;
            this.maxStacks = maxStacks;
            this.minStacks = minStacks;
            this.type = type;
        }
        public virtual void OnApply(GameObject target) { }
        public virtual void OnReapply(StatusEffect effect) 
        {
            duration += effect.duration; //Add Duration
            stacks += effect.stacks; //Add Stacks
            maxStacks = Mathf.Max(maxStacks, effect.maxStacks);
            minStacks = Mathf.Min(minStacks, effect.minStacks);
        }
        public virtual void OnTick() 
        { 
            if (duration > 0 && maxDuration > 0)
            {
                duration -= 1;
            }
        }
        public virtual void OnRemove(StatusEffect effect) 
        { 
            duration -= effect.duration;
            stacks -= effect.stacks;
        }
        public virtual void OnClear()
        {
            
        }
    }
    public enum StatusEffectType 
    {
        Fire,
        Ice,
        Doom,
        Weakness
    }
}
