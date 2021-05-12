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
        Debug.Log(currentFullSpellText.text);
        Debug.Log(buttonSyllable.text);
    }

    public void clickedSyllable()
    {
        //Check if three variables have been clicked already first
        Debug.Log(buttonSyllable.text);
        currentFullSpellText.text = currentFullSpellText.text + " " + buttonSyllable.text;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
