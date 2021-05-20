using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpellWindow : MonoBehaviour
{
    private TMP_Text currentFullSpellText;
    public GameObject entireSpellText;
    HUD playerHUD;
    public GameObject circle;

    // Start is called before the first frame update
    void Start()
    {
        currentFullSpellText = entireSpellText.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();
        playerHUD.EnableCursor();
    }

    public void resetEntireSpell() {
        currentFullSpellText.text = "";
    }

    public void transferChosenSpell() {
        string enchant = currentFullSpellText.text;
        Item returnItem = RecipeController.CheckEnchant(CauldronInventory.GetAll(), enchant);
        Debug.Log(returnItem.name);

        //Inventory.AddItem(returnItem);
        playerHUD.DrawInventory();
        circle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        playerHUD.DrawInventory();
    }
}
