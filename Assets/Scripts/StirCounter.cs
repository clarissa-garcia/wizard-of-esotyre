using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirCounter : MonoBehaviour
{
	private int numStirs;
	private bool isClockwise;
	StirTextUpdate stirText;
	
    // Start is called before the first frame update
    void Start()
    {
		stirText = GetComponent<StirTextUpdate>();
        numStirs = 0;
		isClockwise = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	/*
	Not sure if we'll want two separate buttons for the direction
	or just a button to flip. So I've implemented both ways
	*/
	public void flipDirection(){
		isClockwise = !isClockwise;
	}
	
	public void stirClockwise(){
		isClockwise = true;
	}
	
	public void stirCCwise(){
		isClockwise = false;
	}
	
	public void increaseStirs(){
		/*
		I don't think we'll need an upper limit on stirs,
		but just in case it comes up, here it is
		*/
		if(numStirs <= 99){
			numStirs++;
			Debug.Log("Stirs increased " + numStirs);
			stirText.updateCount(numStirs.ToString());
		}
	}
	
	public void decreaseStirs(){
		if(numStirs >= 1){
			//can only update if # won't go below 0
			numStirs--;
			Debug.Log("Stirs decreased " + numStirs);
			stirText.updateCount(numStirs.ToString());
		}
	}
	
	/*
	Checks to see if the current number of stirs and stir direction
	match the recipe parameters given to the method
	*/
	public bool stirCheck(int recipeStirs, bool recipeDirec){
		if(recipeStirs != numStirs){
			return false;
		}
		else if(recipeDirec != isClockwise){
			/*
			should both be true if clockwise
			and both false if counterclockwise
			*/
			return false;
		}
		else return true;
	}
}
