using System;
using UnityEngine;

namespace Tanks
{
    public class TankView : MonoBehaviour
    {
        public Rigidbody2D Rb;
        public Transform TurretParent;

        public Action<GameObject> СollisionEvt;
        private void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        
        private void OnCollisionEnter(Collision other)
        {
            СollisionEvt?.Invoke(other.gameObject);
        }
    }
}