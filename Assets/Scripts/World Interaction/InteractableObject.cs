
using TMPro;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{

    public float maxPlayerDist = 5; 
    public bool showFloatingText = true;
    [TextArea(5, 10)]
    public string floatingText;
    [Tooltip("Shows pop up when player hovers over")]
    public bool showPopUp = false;
    [TextArea(5, 10)]
    public string popUpText;

    public GameObject floatingTextPrefab;

    private GameObject floatingTextObject;
    private cakeslice.Outline outln; // outline attached to object
    private GameObject mainCamera = null;
    protected HUD playerHUD;

    private GameObject player;
    

    protected virtual void Start()
    {

        gameObject.layer = 3;
        outln = gameObject.AddComponent<cakeslice.Outline>();
        mainCamera = GameObject.FindWithTag("FPCamera");
        playerHUD = GameObject.FindWithTag("PlayerHUD").GetComponent<HUD>();
        player = GameObject.FindWithTag("Player");
        outln.enabled = false;

        if(popUpText == "")
            popUpText = "Pop up text here";
        if (floatingText == "")
            floatingText = "Float text here";
        

    }

    private void Awake()
    {
        if (showFloatingText)
        {
            floatingTextObject = Instantiate(floatingTextPrefab, gameObject.transform);
            floatingTextObject.GetComponentInChildren<TextMeshPro>().text = floatingText;
            floatingTextObject.SetActive(false);
        }
    }

    protected virtual void Update()
    {
        if(showFloatingText && floatingTextObject){
            if (PlayerInRange()){
                floatingTextObject.SetActive(true);
                floatingTextObject.transform.rotation = Quaternion.LookRotation(floatingTextObject.transform.position - mainCamera.transform.position);
            }
            else{
                if(floatingTextObject.activeSelf)
                    floatingTextObject.SetActive(false);
            } 
        }
        
        Interact();
    }

    private void OnMouseOver()
    {
        if (PlayerInRange())
        {
            Debug.Log("Mouse Entered");
                    outln.enabled = true;
                    if (showPopUp)
                        playerHUD.ShowPopUp(popUpText);
        }
        else
        {
            outln.enabled = false;
            if (showPopUp)
                playerHUD.HidePopUp();
        }
        
    }

    private void OnMouseExit()
    {
        outln.enabled = false;
        if (showPopUp)
            playerHUD.HidePopUp();
    }

    virtual protected void Interact()
    {
        if (IsHovered() && Input.GetMouseButtonDown(0))
        {
            Debug.Log("Player interacted with " + name);
        }
    }

    protected bool IsHovered()
    {
        return outln.enabled;
    }

    protected float DistToPlayer(){
        return Vector3.Distance(player.transform.position, transform.position);
    }

    protected bool PlayerInRange(){
        return DistToPlayer() <= maxPlayerDist;
    }
}
