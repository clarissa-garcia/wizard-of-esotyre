using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCButton : MonoBehaviour
{
	private Button directionB;
	private StirCounter counter;
	
    // Start is called before the first frame update
    void Start()
    {
		directionB = GameObject.Find("Direction Button").GetComponent<Button>();
        counter = GameObject.Find("Stir Count").GetComponent<StirCounter>();
		//directionB.onClick.AddListener(directionSwitch);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void directionSwitch(){
		Debug.Log("button clicked");
		counter.flipDirection();
	}
}
