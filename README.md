# DroneSimulation

Learned about Unity.

Created a 3D environment in Unity to replicate a room and a drone object that moves in the environment.

Added integration for WASD keys to move the drone object in the environment. Any variation of the keys can be used to move the drone object.

Started looking at the djitello python library to integrate with Unity and look for the commands it sends to replicate them.

![sim1](images/droneSim.gif)

total hours: ~7 hours

---

Learned a little bit C#.

Created a drone object in Unity and added the ability to move it in the environment using the WASD keys. Read the documentation of the djitello python library to understand the commands it sends to the drone and replicated them in C# using Socket programming and string manipulation and encoding.

Understand the difference between Update and FixedUpdate in Unity. Update is called once per frame and FixedUpdate is called once per physics update. The physics update is not tied to the frame rate and is tied to the physics engine. It runs a separate thread that runs at a fixed rate and is used to calculate the physics of the objects in the environment. FixedUpdate is used to calculate the movement of the drone object in the environment for better accuracy and for the drone object to move smoothly without filling up the buffer.

Ran the program multiple times to match the speed of the drone with the speed of the drone in the simulation to get an accurate representation of the drone's location in the environment in the simulation.

A video will be recorded in the next few days.

total hours: ~8 hours
