using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI liquidText;
    [SerializeField] TextMeshProUGUI advanceNumText;
    [SerializeField] GameObject[] characterObjects;
    Character[] characters;
    [SerializeField] int MOD_AMOUNT = 100;
    [SerializeField] float STOCK_MOD = 1.5f;
    [SerializeField] int MAX_ADVANCES = 2;

    [SerializeField] GameObject advanceButton;
    Image advanceButtonImage;
    [SerializeField] Sprite advanceOn;
    [SerializeField] Sprite advanceOff;
    bool advanceIsUp = false;

    [SerializeField] GameObject PanelObj;
    Image panelImage;
    [SerializeField] Color panelColour;

    public int advanceNumber = 0;


    [SerializeField] int liquidMoney;


    private void Start()
    {
        advanceButtonImage = advanceButton.GetComponent<Image>();
        panelImage = PanelObj.GetComponent<Image>();
        characters = new Character[characterObjects.Length];
        for (int i =0 ; i < characterObjects.Length; i++)
        {
            characters[i] = characterObjects[i].GetComponent<Character>();
        }
        liquidText.text = "Available Assets: "+liquidMoney.ToString();
        advanceNumText.text = advanceNumber.ToString();
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i].stockDisplayText.text = characters[i].stockValue.ToString();
        }
    }


    public void Liquefy(int i)
    {
        if (characters[i].stockValue > MOD_AMOUNT)
        {
            characters[i].stockValue -= MOD_AMOUNT;
            liquidMoney += MOD_AMOUNT;
        }
        else
        {
            liquidMoney += characters[i].stockValue;
            characters[i].stockValue = 0;
        }
        characters[i].stockDisplayText.text = characters[i].stockValue.ToString();
        liquidText.text = "Available Assets: " + liquidMoney.ToString();
    }

    public void Solidify(int i)
    {
        if (liquidMoney > MOD_AMOUNT)
        {
            characters[i].stockValue += MOD_AMOUNT;
            liquidMoney -= MOD_AMOUNT;
        }
        else
        {
            characters[i].stockValue += liquidMoney;
            liquidMoney = 0;
        }
        characters[i].stockDisplayText.text = characters[i].stockValue.ToString();
        liquidText.text = "Available Assets: "+liquidMoney.ToString();
    }

    public void Advance()
    {
        if (advanceNumber < MAX_ADVANCES && advanceIsUp)
        {
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].stockValue = (int)(characters[i].stockValue * Mathf.Pow(STOCK_MOD, characters[i].changes[advanceNumber]));
                characters[i].stockDisplayText.text = characters[i].stockValue.ToString();
            }
            advanceNumber++;
            liquidMoney += MOD_AMOUNT;
            liquidText.text = "Available Assets: " + liquidMoney.ToString();
            advanceIsUp = false;
            advanceButtonImage.sprite = advanceOff;
        }
        advanceNumText.text = advanceNumber.ToString();
    }

    public void ToInvestPage()
    {
        panelImage.color = panelColour;
    }

    public void switchSafety()
    {
        advanceIsUp = !advanceIsUp;
        if (advanceIsUp)
        {
            advanceButtonImage.sprite = advanceOn;
        }
        else
        {
            advanceButtonImage.sprite = advanceOff;
        }
    }
}
