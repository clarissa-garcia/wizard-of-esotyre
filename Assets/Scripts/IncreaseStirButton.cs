using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseStirButton : MonoBehaviour
{
	Button increaseB;
	StirCounter counter;
	
    // Start is called before the first frame update
    void Start()
    {
        increaseB = GetComponent<Button>();
		counter = GetComponent<StirCounter>();
		//increaseB.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void increaseButton(){
		Debug.Log("Increase button clicked");
		counter.increaseStirs();
	}
}
