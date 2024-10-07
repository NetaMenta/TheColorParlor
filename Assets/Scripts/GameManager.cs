using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] Character[] characters;
    [SerializeField] GameObject resultsCanvas;

    [SerializeField] ChangeColor currentProp;

    //stuff for color comparing
    public float huePlayer, saturationPlayer, valuePlayer, hueCharacter, saturationCharacter, valueCharacter, hueDifference, saturationDifference, valueDifference;
    [SerializeField] TMPro.TMP_Text accuracyText;
    [SerializeField] TMPro.TMP_Text TotalAccuracyText;
    [SerializeField] TMPro.TMP_Text TotalAccuracyText2;
    [SerializeField] TMPro.TMP_Text CurrentLevel;
    [SerializeField] TMPro.TMP_Text TotalLevels;
    [SerializeField] ColorPickerControl playerColor;

    public List<float> accuracyResults = new List<float>();
    public float percentageDifference;
    public int levelLength = 5;
    public int currentCharacter = 0;

    public void Start()
    {
        currentProp.GenerateColor();
        GetPropHSVValues();
        updatePlayerColor();
        compareColorsUpdate();
        DisplayCurrentCharacter();
        DisplayLevelLength();

    }
    public void Update()
    {
        updatePlayerColor();
        compareColorsUpdate();
    }

    public string ReturnPropName()
    {
        return characters[currentCharacter].ReturnPropName();
    }
    public Color CurrentPlayerColor()
    {
        return Color.HSVToRGB(huePlayer, saturationPlayer, valuePlayer);
    }

    public Color CurrentCharacterColor()
    {
        return Color.HSVToRGB(hueCharacter, saturationCharacter, valueCharacter);
    }

    public void nextCharacter()
    {
        characters[currentCharacter].SetActive(false);
        currentCharacter++;
        if (currentCharacter >= characters.Length)
        {
            currentCharacter = 0;
        }
        characters[currentCharacter].SetActive(true);
        currentProp = characters[currentCharacter].getProp();
        currentProp.GenerateColor();
        GetPropHSVValues();
    }

    public SpriteRenderer ReturnCurrentPropSprite()
    {
        SpriteRenderer rend = characters[currentCharacter].returnPropSprite();
        return rend;
    }

    public void updatePlayerColor()
    {
        huePlayer = playerColor.currentHue;
        saturationPlayer = playerColor.currentSat;
        valuePlayer = playerColor.currentVal;
    }

    public void GetPropHSVValues()
    {
        Color.RGBToHSV(currentProp.newColor, out hueCharacter, out saturationCharacter, out valueCharacter);

    }
    public void compareColorsUpdate()
    {
        GetPropHSVValues();
        updatePlayerColor();

        hueDifference = Mathf.Abs(huePlayer - hueCharacter);
        saturationDifference = Mathf.Abs(saturationPlayer - saturationCharacter);
        valueDifference = Mathf.Abs(valuePlayer - valueCharacter);

    }
        public void compareColors()
    {
      
        float percentageDifference = 100- calculatePercentageDifference(hueDifference, saturationDifference, valueDifference);
        accuracyResults.Add(percentageDifference);
        string formattedNumber = percentageDifference.ToString("F2");

        if (hueDifference < 0.15f && saturationDifference < 0.15f && valueDifference < 0.15f)
        {
            accuracyText.text = "COLORS ARE " + formattedNumber + "% SIMILAR, WHICH IS GREAT!";
        }
        else
        {
            accuracyText.text = "COLORS ARE " + formattedNumber + "% SIMILAR, WHICH COULD BE BETTER...";
        }

    }

    public float calculateAccuracy()
    {
        float accuracy = 0;
        for (int i = 0; i < accuracyResults.Count; i++)
        {
            accuracy += accuracyResults[i];
        }
        accuracy = accuracy / levelLength;
        return accuracy;    
    }
    public void displayAccuracyStats()
    {
        if (accuracyResults.Count >= 5)

        {
            float accuracy = calculateAccuracy();
            Debug.Log("Accuracy currently is " + accuracy);
            string formattedNumber = accuracy.ToString("F2");
            TotalAccuracyText.text = formattedNumber + "%";
            if (accuracy >= 90f)
            {
                TotalAccuracyText2.text = "YOURE AWESOME AT THIS!";
            }
            else if (accuracy <= 90f)
            {
                TotalAccuracyText2.text = "YOU SHOULD PRACTICE!";
            }
        }
       
    }

    public void showCanvas()
    {
        compareColors();
        resultsCanvas.SetActive(true);
    }

    public void hideCanvas()
    {
        resultsCanvas.SetActive(false);
    }

    public float calculatePercentageDifference(float hueDifference, float saturationDifference, float valueDifference)
    {
        float huePercentage = (hueDifference / 1f) * 100;
        float saturationPercentage = (saturationDifference / 1f) * 100;
        float valuePercentage = (valueDifference / 1f) * 100;

        percentageDifference = (huePercentage + saturationPercentage + valuePercentage) / 3;
        return percentageDifference;
    }

    public void RestartGame()
    {
        characters[currentCharacter].SetActive(false);
        accuracyResults = new List<float>();
        currentCharacter = 0;
        characters[currentCharacter].SetActive(true);
    }

    public void DisplayCurrentCharacter()
    {
        int level = accuracyResults.Count;
        CurrentLevel.text = level.ToString();
    }

    public void DisplayLevelLength()
    {
        TotalLevels.text = "/ " + levelLength.ToString();
    }
}
