
using UnityEngine; 

public class BridgeObj : InteractableObject{

    private void OnMouseDown() {
        if(GameManager.Instance.repair){
            GameManager.Instance.FixBridge();
        }
    }
}