# Project title
 Indentify favorite using by piezo plat sensor for neuro-diversity child

About My project:

  My project is about identification and how amount of pressure give by user. it is combine of hardward and software that is IOT. using by Piezo plate sensore for pressure to give in surface, and how much pressure is given show in unity(game engine) by virtual method. in aurdino ide for ESP32 device, and VS code for unity. 

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
Application & Use case
1. Interactive Installation & Digital Art
This system can be used in museums or art galleries.
Use: Large-scale "pressure plates" on the floor or wall allow visitors to interact with a digital mural.
Value: It turns physical movement into a visual, colorful experience, making art "touchable."
2. Gamified Rehabilitation & Physical Therapy
The project can be used as a medical tool to help patients recover motor skills.
Use: Patients are asked to tap specific plates with a certain amount of "Target Force."
Value: Because the squares in Unity grow based on force, the patient gets instant visual feedback. Doctors can see if the patient has enough strength or coordination in their hands or feet.
3. Musical Instrument Interface (MIDI Controller)
Your project is essentially the foundation of a digital drum kit.
Use: Since you are sending "Force" (Velocity) and "ID" (Note), you can map each square to a sound.
Value: It allows for the creation of custom, low-cost percussion instruments for musicians or hobbyists.
4. Industrial Human-Machine Interface (HMI) Prototyping
Engineers use this setup to test how humans interact with machines.
Use: Testing "Force-Sensitive" buttons for industrial equipment where a simple "On/Off" click isn't enough.
Value: It provides a safe, low-cost way to simulate high-tech pressure controls before manufacturing expensive hardware.
Demo video (in tamil):https://photos.app.goo.gl/41tiEve9xkKJvMje7
