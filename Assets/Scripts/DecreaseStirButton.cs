using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseStirButton : MonoBehaviour
{
	Button decreaseB;
	StirCounter counter;
	
    // Start is called before the first frame update
    void Start()
    {
        decreaseB = GetComponent<Button>();
		counter = GetComponent<StirCounter>();
		decreaseB.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void TaskOnClick(){
		Debug.Log("Decrease button clicked!");
		counter.decreaseStirs();
	}
}
