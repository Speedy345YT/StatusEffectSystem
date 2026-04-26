using UnityEngine;

namespace EffectSystem
{
    public interface IDamageHandler
    {
        public float currentHealth { get; set; }
        public float maxHealth { get; set; }
        public float normalizedHealth { get; }
        /// <summary>
        /// Removes health.
        /// </summary>
        /// <param name="info">Info of damage</param>
        /// <returns>Amount of damage actually dealt</returns>
        public float TakeDamage(float amount);
        public void SetHealth(float amount);
        /// <summary>
        /// Adds health.
        /// </summary>
        /// <param name="amount">Amount of health added</param>
        /// <returns>Amount of health actually gained</returns>
        public float AddHealth(float amount);
        public void Die();
    }
}
