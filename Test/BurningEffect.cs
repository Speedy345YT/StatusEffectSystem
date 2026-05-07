using UnityEngine;

namespace EffectSystem
{
    public class BurningEffect : StatusEffect
    {
        StatusEffectManager manager;
        public BurningEffect(int duration, int stacks) 
            : base(duration, maxDuration: -1, stacks, minStacks: 0, maxStacks: -1, type: "Burning", triggerName: "")
        {

        }
        public override void OnApply(GameObject target)
        {
            manager = target.GetComponent<StatusEffectManager>();
        }
        public override void OnTick()
        {
            if (manager.HasEffect("Fire", out StatusEffect effect))
            {
                effect.stacks += stacks;
                effect.duration = duration;
                stacks -= 1;
            } else
            {
                manager.AddEffect(new FireEffect(duration, stacks, 1));
            }
        }
    }
}
