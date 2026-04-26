using UnityEngine;

namespace EffectSystem
{
    public class DoomEffect : StatusEffect
    {
        public IDamageHandler damageHandler;
        public DoomEffect(int stacks)
        : base(duration: 1, maxDuration: -1, stacks, minStacks: 0, maxStacks: -1, type: StatusEffectType.Doom)
        {

        }
        public override void OnApply(GameObject t)
        {
            damageHandler = t.GetComponent<IDamageHandler>();
        }
        public override void OnTick()
        {
            base.OnTick();
            Debug.Log(stacks);
            if (damageHandler.currentHealth <= stacks)
            {
                damageHandler.TakeDamage(stacks);
                stacks = 0;
            }
        }
    }
}
