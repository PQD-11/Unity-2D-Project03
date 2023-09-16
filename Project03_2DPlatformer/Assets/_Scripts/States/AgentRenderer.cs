using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentRenderer : MonoBehaviour
{
    public void FaceDirection(Vector2 vector)
    {
        if (Mathf.Abs(vector.x) > 0)
        {
            transform.parent.localScale = new Vector2(Mathf.Sign(vector.x), 1f);
        }
    }
}