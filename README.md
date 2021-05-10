# UduinoTest
 A test of multiple inputs and outputs using the Uduino plugin.

Let's create some instrumentation to test out the following:
1) variable digital output from 0-255 for an LED intensity
2) variable digital output 0 or 1 that corresponds to an LED intensity of 0 or 255;
3) variable analog input (ADC converts this to 0-1023) that will set a surface gravity of 0-2 g's
4) variable digital input 0 or 1 that corresponds to a button input (LOW or HIGH)

These correspond to the following physical components:

1) green LED
2) red LED
3) 10k Ohm potentiometer
4) pushbutton
 
The collision manager script will control collisions while the gamemanager script will handle
displaying the gravity slider on screen as well as the scene reset when the button is pressed.

The first image is a shot of the Unity IDE.  You can see the pin assigments, namely:

outputs:

pin 11 digital output for green altitude LED intensity

pin 10 digital output for red collision LED intensity

inputs:

pin A1 for analog input (10k Ohm pot)

pin 2 for digital input (pushbutton)

![uduino01](https://user-images.githubusercontent.com/74695555/117734496-d3296d00-b1b0-11eb-92e5-2b65e95c643d.png)

This image shows the hardware with a green "altitude" LED and an unlit, red "collision" LED.
![20210510_163627](https://user-images.githubusercontent.com/74695555/117733544-fa7f3a80-b1ae-11eb-9241-8291d92a8d90.jpg)

During a collision with the ground, the green LED is dimmmer (lower altitude) and the RED lights up briefly.  It's a bit difficult to see the nuance of the LED intensity here.  Maybe in lower lighting better live images could be obtained.
![20210510_163655](https://user-images.githubusercontent.com/74695555/117733548-fc48fe00-b1ae-11eb-9069-0fc60226b537.jpg)
