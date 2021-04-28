using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StirTextUpdate : MonoBehaviour
{
	private Text stirs;
	
    // Start is called before the first frame update
    void Start()
    {
        stirs = GetComponent<Text>();
		stirs.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void updateCount(string newNum){
		stirs.text = newNum;
	}
}
