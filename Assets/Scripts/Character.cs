using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    //[SerializeField] public string charName;
    [SerializeField] public int[] changes;
    [SerializeField] public TextMeshProUGUI stockDisplayText;
    [SerializeField] public int stockValue;

    [SerializeField] GameObject PanelObj;
    Image panelImage;
    [SerializeField] Color panelColour;

    // Start is called before the first frame update
    void Start()
    {
        panelImage = PanelObj.GetComponent<Image>();
    }

    public void ToCharacterPage()
    {
        panelImage.color = panelColour;
    }
}
