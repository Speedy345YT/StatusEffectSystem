using UnityEngine;

namespace EffectSystem
{
    public abstract class StatusEffect
    {
        public int duration { get; protected set; } //-1 = permanent
        public int maxDuration { get; protected set; }
        public int minStacks { get; protected set; }
        public int stacks { get; protected set; }
        public int maxStacks { get; protected set; }
        public StatusEffectType type { get; protected set; }
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
        }
        public virtual void OnTick() 
        { 
            if (duration > 0)
            {
                duration -= 1;
            }

            //Apply other tick logic
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
        Weakness
    }
}
