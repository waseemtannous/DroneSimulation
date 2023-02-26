# DroneSimulation

Learned about Unity.
Created a 3D environment in Unity to replicate a room and a drone object that moves in the environment.
Added integration for WASD keys to move the drone object in the environment. Any variation of the keys can be used to move the drone object.
Started looking at the djitello python library to integrate with Unity and look for the commands it sends to replicate them.

<!-- addgif here -->

![sim1](images/droneSim.gif)

total hours: ~7 hours

---

Learned a little bit C#.

Created a drone object in Unity and added the ability to move it in the environment using the WASD keys. Read the documentation of the djitello python library to understand the commands it sends to the drone and replicated them in C# using Socket programming and string manipulation and encoding.

Understand the difference between Update and FixedUpdate in Unity. Update is called once per frame and FixedUpdate is called once per physics update. The physics update is not tied to the frame rate and is tied to the physics engine. It runs a separate thread that runs at a fixed rate and is used to calculate the physics of the objects in the environment. FixedUpdate is used to calculate the movement of the drone object in the environment for better accuracy and for the drone object to move smoothly without filling up the buffer.

Ran the program multiple times to match the speed of the drone with the speed of the drone in the simulation to get an accurate representation of the drone's location in the environment in the simulation.

A video will be recorded in the next few days.

total hours: ~8 hours

---

Added the ability to move the drone object in the environment using the arrow keys. The drone object can now be moved using the WASD keys and the arrow keys. Also, it moves in the space relative to it's local axis and not the global axis.

Learned about the UDP protocol.

Read through the djitello python library to understand the commands it sends to the drone and how it receives the video feed from the drone. Also, read through the documentation of the socket library to understand how to use it to send and receive data.

Still not able to get the video feed from the drone. Will look into it in the next few days. Tried using the socket library to send and receive data but it didn't work.

total hours: ~8 hours

---

For the past three weeks, I've been working on receiving the video stream from the drone and display it in Unity.

First, started by learning about the UDP protocol and how to use it in C#. Then read through the djitello python library to understand the commands it sends to the drone and how it receives the video feed from the drone. Also, read through the documentation of the socket library to understand how to use it to send and receive data.

To do that, I tried to do it in multiple ways. I started by using the Python for Unity library to inject some python code to C# and eventually to the game. The reason for that was to use a fully developed api that I could use for easier debugging and connection to the drone. This didn't work as expected.

After that, tried to use the VideoPlayer component in Unity and set the source as the UDP URL pointing to the drone. This didn't work as this component can only display a locally saved video file.

Then, started to learn how to implement a UDP client in C# and receive the video stream data as Bytes which then would be decoded and presented on a specific element. I received the Bytes array and attached it to a Texture2D object which was attached to a Material element that was put on a plane object. The idea was to display the video stream on the plane object. In theory that should've worked but it didn't. Still trying to debug it and figure out why it's not working.

I've been reading through lots of articles and documentation on the internet to understand how to do this. I've also been watching videos on YouTube to understand more about receiving video streams and how to implement it in Unity and C# using the UDP protocol.

Each week I worked for about 8-9 hours totaling to about 26 hours.

---

I've been working on receiving the video stream from the drone and display it in Unity. This week, I used the OpenCV for Unity library to decode the video stream and display it on a plane object in Unity. I used the VideoCapture component to capture the video stream from the drone and the MatToTexture component to convert the Mat object to a Texture2D object which was then attached to a Material object that was put on a plane object. This approach didn't work as expected. The video stream was not displayed on the plane object. I tried to debug it but couldn't figure out why it's not working. I've been reading through lots of articles and documentation on the internet to understand how to do this.

I also tried reading an image from a local file and displaying it on the plane object. This worked. I read the image and converted it into bytes array to load it into the Texture2D object. Maybe the problem is with the video stream data. I'll try to figure it out in the next few days.

total hours: 10 hours

---

After multiple tries and debugging, I was able to get the video stream from the drone and display it on a plane object in Unity. I used a workaround as I didn't want to hold the project any longer. after multiple tries using the methods above, I ended up creating a python script that uses the drone's library and opencv to capture the video stream and save the frames as images. I then loaded the images into Unity and displayed them on a plane object. This worked. Next week I'll be diving more into the VR side of the project and will be working from the lab to use the VR headset.

total hours: 9 hours

---

This week, I started working on the VR side of the project. I used the Oculus Integration package to add the Oculus SDK to the project. I implemented some ways to solve the problem so that I could test them in the lab.

total hours: 8 hours

---

Last week: I worked in the lab and tested the approaches I implemented earlier using the Meta Quest 2 VR headset. I displayed the video stream that is stationary in relative to the viewer. Each movement (left, right, forward, backward) of the viewer is translated to a movement of the drone in the environment.

total hours: 9 hours

Demo: https://drive.google.com/file/d/1iFrI3dwaMavrQDx3Y7_pP29DVTKNTzH9/view?usp=sharing
