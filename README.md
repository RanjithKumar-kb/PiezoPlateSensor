# Project title
 Indentify favorite using by piezo plat sensor for neuro-diversity child

About My project:

  My project is about identification and how amount of pressure give by user. it is combine of hardward and software that is IOT. using by Piezo plate sensore for pressure to give in surface, and the my much of pressure given show in unity(game engine) by virtual method. in aurdino ide for ESP32 device, and VS code for unity. 

 Tools:

 Hardward: Peizo Plate sensor, ESP32 S3 device
 Software: Aurdino IDE,Unity application

 Methodology:

1.Hardware Architecture (Input Stage)

Signal Acquisition: When a plate is touched, the piezo generates a small voltage proportional to the impact force.

Conditioning: 1M resistors and Zener diodes are used to stabilize the signal and protect the microcontroller from voltage spikes.

Processing: The ESP32-S3 reads the analog signal (0–4095) and converts it into a normalized float value (0.0 to 1.0).

2.Communication Protocol (Data Bridge)

Data is transferred from the hardware to the software via Serial Communication

Formatting: A custom string protocol is used: ID:Force Example: 2:0.75 means Plate #2 was hit with 75% force.

Efficiency: By using a high baud rate (115200), the system ensures "Real-Time" response with no noticeable lag.

3.Software Logic (Visualization Stage)

Parsing: The C# script constantly monitors the Serial Port, splits the incoming strings, and identifies which plate was hit.

Scaling: Using Linear Interpolation ($Lerp$), the script maps the force value to the localScale of a 2D Square.

Animation Decay: A "Return-to-Zero" algorithm is implemented in the Update loop to smoothly shrink the squares back to their original size after the hit, creating a dynamic "bounce" effect.

Demo video (in tamil):https://photos.app.goo.gl/41tiEve9xkKJvMje7
