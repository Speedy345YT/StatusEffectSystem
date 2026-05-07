using UnityEngine;

namespace EffectSystem
{
    public class TestApply : MonoBehaviour, IDamageHandler
    {
        public StatusEffectManager manager;
        public float health;
        public float MaxHealth;
        public float currentHealth {
            get
            {
                return health;
            }
            set
            {

            } 
        }
        public float maxHealth
        {
            get
            {
                return MaxHealth;
            }
            set
            {

            }
        }

        public void Die()
        {
        }

        public void SetHealth(float amount)
        {
        }

        public void TakeDamage(float amount)
        {
            Debug.Log($"Took {amount} damage");
            health -= amount;
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                manager.TickEffects("");
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                manager.AddEffect(new DoomEffect(1));
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                manager.AddEffect(new BurnedEffect(1, 5, 1));
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                manager.AddEffect(new BurningEffect(10, 5));
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                manager.AddEffect(new OilEffect(5, 10));
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                manager.AddEffect(new PoisonEffect(5, 1));
            }
        }
    }
}
