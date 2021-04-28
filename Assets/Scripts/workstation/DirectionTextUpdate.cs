using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionTextUpdate : MonoBehaviour
{
	private Text direction;
	
    // Start is called before the first frame update
    void Start()
    {
        direction = GameObject.Find("Direction label").GetComponent<Text>();
		direction.text = "Clockwise";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void updateDirection(bool clockwise){
		if(clockwise == true){
			direction.text = "Clockwise";
			Debug.Log(direction.text);
		}
		else if(clockwise == false){
			direction.text = "Counterclockwise";
			Debug.Log(direction.text);
		}
		else{
			Debug.Log("broken dir button");
		}
	}
}
