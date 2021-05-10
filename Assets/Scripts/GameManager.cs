using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;
using UnityEngine.SceneManagement;

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

public class GameManager : MonoBehaviour
{
    public Slider gravitySlider;

    UduinoManager manager;

    public float potValue;

    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;
        manager.pinMode(AnalogPin.A1, PinMode.Input);
    }

    // Update is called once per frame
    void Update()
    {
        gravitySlider.value = (float) manager.analogRead(AnalogPin.A1) / 512f;
        Physics.gravity = new Vector3(0, -gravitySlider.value*9.81f, 0);

        CheckRestart();
    }

    void CheckRestart()
    {

        int buttonState = manager.digitalRead(2);
        if (buttonState == 1)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            //Debug.Log("Let's restart.");
        }
    }
}
