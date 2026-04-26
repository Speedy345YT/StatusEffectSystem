using UnityEngine;

namespace EffectSystem
{
    public class TestApply : MonoBehaviour, IDamageHandler
    {
        public StatusEffectManager manager;
        public float health;
        public float maxhealth;
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
                return maxhealth;
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

        private void Start()
        {
            manager.AddEffect(new DoomEffect(10));
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                manager.AddEffect(new DoomEffect(1));
            }
        }
    }
}
