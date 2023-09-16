using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SVS.Common
{
    public class DestroyUtils : MonoBehaviour
    {
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}

