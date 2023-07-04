using UnityEngine;

namespace Tanks
{
    public class TankView : MonoBehaviour
    {
        public Rigidbody2D Rb;
        public Transform TurretParent;

        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
    }
}