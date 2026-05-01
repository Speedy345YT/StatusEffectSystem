using UnityEngine;

namespace EffectSystem
{
    [System.Serializable]
    public abstract class StatusEffect
    {
        public int duration; //-1 = permanent
        public int maxDuration; //-1 = inf stacking
        public int minStacks; //How low something needs to go to be cleared
        public int stacks; //Current Stacks
        public int maxStacks; //-1 = inf stacking
        public StatusEffectType type;
        private StatusEffectManager manager;
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
            if (duration >= 1)
            {
                duration -= 1;
            }
            if (maxDuration > 0)
            {
                duration = Mathf.Clamp(duration, 0, maxDuration);
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
        Doom,
        Poison
    }
}
