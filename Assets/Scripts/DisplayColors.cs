using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayColors : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image propImage;
    [SerializeField] Image playerImage;
    [SerializeField] TMPro.TMP_Text propText;

    public void Update()
    {
        ChangePropImageColor();
        ChangeCharacterImageColor();
        ChangePropText();
    }
    public void ChangePropImageColor()
    {
        propImage.color = gameManager.CurrentCharacterColor();
    }
    public void ChangeCharacterImageColor()
    {
        playerImage.color = gameManager.CurrentPlayerColor();
    }
    public void ChangePropText()
    {
        propText.color = gameManager.CurrentCharacterColor();
    }
}
