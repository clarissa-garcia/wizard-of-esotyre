using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseStirButton : MonoBehaviour
{
	private Button decreaseB;
	private StirCounter counter;
	private Text count;
	
    // Start is called before the first frame update
    void Start()
    {
        decreaseB = GetComponent<Button>();
		count = GameObject.Find("Stir Count").GetComponent<Text>();
		counter = GameObject.Find("Stir Count").GetComponent<StirCounter>();
		decreaseB.onClick.AddListener(decreaseButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void decreaseButton(){
		//Debug.Log("Decrease button clicked!");
		counter.decreaseStirs();
	}
}
