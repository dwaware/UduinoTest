using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

/*
 * 
 * Let's create some instrumentation to test out the following:
 * 1) variable int output from 0-255 for an LED intensity
 * 2) variable in 0 or 1 that corresponds to an LED intensity of 0 or 255;
 * 3) variable digital input from 0-1023 that will convert to a surface gravity of 0-2 gees
 * 4) variable int 0 or 1 that corresponds to a button input (LOW or HIGH)
 * 
 * These correspond to the following physical components:
 * 
 * 1) green LED
 * 2) red LED
 * 3) 10k Ohm potentiometer
 * 4) pushbutton
 * 
 * The collision manager script will control collisions while the gamemanager script will handle
 * displaying the gravity slider on screen as well as the scene reset when the button is pressed.
 * 
 */

public class CollisionManager : MonoBehaviour
{
	// intensity:  our object's height above the plane will be indicated on a green LED
	[Range(0, 255)]
	public int intensity = 0;

	void Start()
    {
		// intensity data will be recorded by pin 11
		UduinoManager.Instance.pinMode(11, PinMode.Output);
		// collision data will be recorded by pin 10
		UduinoManager.Instance.pinMode(10, PinMode.Output);
    }

	void Update()
    {
		//set the intensity to 10 times the object height above the ground plane
		intensity = (int)this.transform.position.y * 10;
		UduinoManager.Instance.analogWrite(11, intensity);
		//Debug.Log("Intensity:  "+ intensity + "    Height:  " + this.transform.position.y);
	}
	
	//OnCollisionEnter will trigger collision data on pin 10
	IEnumerator OnCollisionEnter(Collision col)
	{
		//Debug.Log("### " + this.name + " collided with:  " + col.gameObject.name);

		//illuminate the LED (State.HIGH) for 0.1 seconds and then turn it off again
		UduinoManager.Instance.digitalWrite(10, State.HIGH);
		yield return new WaitForSeconds(0.1f);
		UduinoManager.Instance.digitalWrite(10, State.LOW);
	}
}