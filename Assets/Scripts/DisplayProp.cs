using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayProp : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image currentPropImage;
    [SerializeField] TMPro.TMP_Text propName;
    SpriteRenderer currentSprite;

    private void Start()
    {
        ChangePropName();
        ChangePropImage();
    }

    public void ChangePropImage()
    {
        currentSprite = gameManager.ReturnCurrentPropSprite();
        currentPropImage.sprite = currentSprite.sprite;
    }

    public void ChangePropName()
    {
        propName.text = gameManager.ReturnPropName();
        Debug.Log(gameManager.ReturnPropName());
    }

}
