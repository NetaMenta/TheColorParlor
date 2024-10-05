using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] ChangeColor prop;
    [SerializeField] string propName;
    public void SetActive(bool isActive)
     {
        gameObject.SetActive(isActive);
     }
    public ChangeColor getProp()
    {
        return prop;
    }
    public SpriteRenderer returnPropSprite()
    {
        return prop.ReturnSprite();
    }
    public Color ReturnCharacterColor()
    {
        return prop.ReturnCurrentColor();
    }
    
    public string ReturnPropName()
    {
        return propName;
    }



}
