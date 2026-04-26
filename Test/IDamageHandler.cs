using UnityEngine;

namespace EffectSystem
{
    public interface IDamageHandler
    {
        public float currentHealth { get; set; }
        public float maxHealth { get; set; }
        public float normalizedHealth { get => currentHealth / maxHealth; }
        /// <summary>
        /// Removes health.
        /// </summary>
        /// <param name="info">Info of damage</param>
        /// <returns>Amount of damage actually dealt</returns>
        public void TakeDamage(float amount);
        public void Die();
    }
}
