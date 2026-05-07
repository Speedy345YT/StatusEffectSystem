using UnityEngine;

namespace EffectSystem
{
    public class DoomEffect : StatusEffect
    {
        public IDamageHandler damageHandler;
        public DoomEffect(int stacks)
        : base(duration: -1, maxDuration: -1, stacks, minStacks: 0, maxStacks: 0, type: "Doom", triggerName: "")
        {

        }
        public override void OnReapply(StatusEffect effect)
        {
            stacks += effect.stacks;
        }
        public override void OnApply(GameObject t)
        {
            damageHandler = t.GetComponent<IDamageHandler>();
        }
        public override void OnTick()
        {
            base.OnTick();
            if (damageHandler.currentHealth <= stacks)
            {
                damageHandler.TakeDamage(stacks);
                stacks = 0;
            }
        }
    }
}
