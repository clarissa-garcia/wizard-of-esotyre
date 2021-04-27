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
        direction = GetComponent<Text>();
		direction.text = "Clockwise";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void updateDirection(bool clockwise){
		if(clockwise == true){
			direction.text = "Clockwise";
		}
		else if(clockwise == false){
			direction.text = "Counterclockwise";
		}
		else{
			Debug.Log("broken dir button");
		}
	}
}
