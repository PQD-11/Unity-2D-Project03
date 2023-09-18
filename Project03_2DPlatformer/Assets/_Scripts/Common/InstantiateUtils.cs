using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;


namespace SVS.Common
{
    public class InstantiateUtils : MonoBehaviour
    {
        public Object objectToInstantiate;

        public void CreateObject()
        {
            Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
        }
    }
}

