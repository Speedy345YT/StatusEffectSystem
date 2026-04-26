using UnityEngine;

namespace EffectSystem
{
    public class FireEffect : StatusEffect
    {
        public IDamageHandler damageHandler;
        public int damagePerTick;
        public FireEffect(int duration, int maxDuration, int stacks, int minStacks, int maxStacks, StatusEffectType type) 
        : base(duration, maxDuration, stacks, minStacks, maxStacks, type)
        {
            
        }
        public override void OnApply(GameObject t)
        {
            damageHandler = t.GetComponent<IDamageHandler>(); 
        }

        public override void OnTick()
        {
            if (damageHandler != null)
            {
                float totalDamage = damagePerTick * stacks;
                damageHandler.TakeDamage(totalDamage);
            }
        }
    }
}
