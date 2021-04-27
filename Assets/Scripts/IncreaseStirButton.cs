using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseStirButton : MonoBehaviour
{
	private Button increaseB;
	private StirCounter counter;
	private Text count;
	
    // Start is called before the first frame update
    void Start()
    {
        increaseB = GetComponent<Button>();
		count = GameObject.Find("Stir Count").GetComponent<Text>();
		counter = GameObject.Find("Stir Count").GetComponent<StirCounter>();
		increaseB.onClick.AddListener(increaseButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void increaseButton(){
		//Debug.Log("Increase button clicked");
		counter.increaseStirs();
	}
}
