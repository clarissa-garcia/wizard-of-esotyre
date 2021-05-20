using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickedSyllable : MonoBehaviour
{
    public GameObject entireSpellText;
    private TMP_Text currentFullSpellText;
    private TMP_Text buttonSyllable;

    // Start is called before the first frame update
    void Start()
    {
        currentFullSpellText = entireSpellText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        buttonSyllable = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    public void clickedSyllable()
    {
        //Check if three variables have been clicked already first
        // Each syllable has 3 letters, so total string should be 9 if full
        if (currentFullSpellText.text.Replace(" ", string.Empty).ToString().Length != 9) {
            currentFullSpellText.text = currentFullSpellText.text + " " + buttonSyllable.text;
        }  
    }
}
