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
            if (manager.HasEffect("Oil", out StatusEffect oilEffect))
            {
                if (manager.HasEffect("Fire", out StatusEffect fireEffect))
                {
                    fireEffect.stacks += stacks * (oilEffect.stacks + 1);
                    fireEffect.duration = duration;
                    oilEffect.stacks -= stacks;
                    stacks = 0;
                }
                else
                {
                    manager.AddEffect(new BurnedEffect(duration, stacks * oilEffect.stacks, 1));
                }
            } else
            {
                if (manager.HasEffect("Fire", out StatusEffect effect))
                {
                    effect.stacks += stacks;
                    effect.duration = duration;
                    stacks -= 1;
                }
                else
                {
                    manager.AddEffect(new BurnedEffect(duration, stacks, 1));
                }
            }
        }
    }
}
