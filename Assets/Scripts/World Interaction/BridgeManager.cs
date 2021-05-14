using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BridgeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject repairedBridge;
    public GameObject brokenBridge; 

    void Awake()
    {
        GameManager.OnBridgeRepair += OnBridgeRepair;
        if(GameManager.Instance.BridgeRepaired()){
            repairedBridge.SetActive(true);
            brokenBridge.SetActive(false);
        }
        else{
            repairedBridge.SetActive(false);
            brokenBridge.SetActive(true);
        }
    }

    public void OnBridgeRepair(){
        QuestManager.Instance.SetQuest(Quest.ENTER_FOREST);
        repairedBridge.SetActive(true);
        brokenBridge.SetActive(false);
        GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>().HidePopUp();
    }

    void OnDestroy()
    {
        GameManager.OnBridgeRepair -= OnBridgeRepair;
    }
}
