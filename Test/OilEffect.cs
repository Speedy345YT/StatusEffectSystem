using UnityEngine;

namespace EffectSystem
{
    public class OilEffect : StatusEffect
    {
        public OilEffect(int duration, int stacks)
        : base(duration, maxDuration : -1, stacks, minStacks: 0, maxStacks: -1, type: "Oil", triggerName: "")
        {
            
        }
    }
}
