using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textColorHandler : ChangeColor
{
    [SerializeField] TMPro.TMP_Text text;
    [SerializeField] SpriteRenderer currentProp;
    public void changeColorToPropColor(SpriteRenderer currentProp)
    {
        text.color = currentProp.color;
    }
    public void changeProp(SpriteRenderer newProp)
    {
        currentProp = newProp;
    }
}
