using UnityEngine;

namespace EffectSystem
{
    public class PoisonEffect : StatusEffect
    {
        public IDamageHandler damageHandler;
        public float damagePerTick;
        public PoisonEffect(int stacks, float damagePerTick)
        : base(duration: -1, maxDuration: -1, stacks, minStacks: 0, maxStacks: -1, type: StatusEffectType.Fire)
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
                stacks -= 1;
                damageHandler.TakeDamage(totalDamage);
            }
        }
    }
}
