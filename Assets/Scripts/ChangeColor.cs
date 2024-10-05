using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor;
    public SpriteRenderer rend;
    public float hue, saturation, value;

    // Start is called before the first frame update
    public Color RandomizeColor()
{
            hue = Random.Range(0.05f, 0.95f);        
            saturation = Random.Range(0.15f, 1f); 
            value = Random.Range(0.2f, 1f);   

            return Color.HSVToRGB(hue, saturation, value);
    }

    public void GenerateColor()
    {
        newColor = RandomizeColor();
        rend = GetComponent<SpriteRenderer>();
        rend.color = newColor;
    }


    public Color ReturnCurrentColor()
    {
        return newColor;
    }

    public SpriteRenderer ReturnSprite()
    {
        rend = GetComponent<SpriteRenderer>();
        return rend;
    }

}
