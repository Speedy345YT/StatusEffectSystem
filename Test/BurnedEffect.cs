using UnityEngine;

namespace EffectSystem
{
    public class BurnedEffect : StatusEffect
    {
        public IDamageHandler damageHandler;
        public float damagePerTick;
        public BurnedEffect(int duration, int stacks, float damagePerTick)
        : base(duration, maxDuration : -1, stacks, minStacks: 0, maxStacks: -1, type: "Fire", triggerName: "")
        {
            this.damagePerTick = damagePerTick;
        }
        public override void OnApply(GameObject t)
        {
            damageHandler = t.GetComponent<IDamageHandler>(); 
        }

        public override void OnTick()
        {
            base.OnTick();
            if (damageHandler != null)
            {
                float totalDamage = damagePerTick * stacks;
                damageHandler.TakeDamage(totalDamage);
            }
        }
    }
}
