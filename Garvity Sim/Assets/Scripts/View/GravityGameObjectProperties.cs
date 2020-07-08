using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class GravityGameObjectProperties : MonoBehaviour
    {
        public float Mass;
        public float Radius;
        public Vector3 StartVelocity;
        private void FixedUpdate()
        {
            gameObject.transform.localScale = new Vector3(Radius, Radius, Radius);
        }
    }
}
