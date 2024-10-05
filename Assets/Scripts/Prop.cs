using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public SpriteRenderer prop;
    public Color propColor;

    void Start()
    {
        propColor = prop.color;
    }
}
