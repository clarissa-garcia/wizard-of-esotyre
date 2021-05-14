using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpellWindow : MonoBehaviour
{
    private TMP_Text currentFullSpellText;
    public GameObject entireSpellText;

    // Start is called before the first frame update
    void Start()
    {
        currentFullSpellText = entireSpellText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
    }

    public void resetEntireSpell() {
        currentFullSpellText.text = "";
    }

    public void transferChosenSpell() {
        Debug.Log(currentFullSpellText.text);
    }
}
