# Third-Person-Walking-Mechanic
The "Third-Person-Walking-Mechanic" Unity player controller script is available in this GitHub project. In a Unity game, the script is in charge of managing the player character's movement and jumping.

Features:

Player Movement: Based on input from the keyboard and mouse, the script manages player movement. The WASD keys and mouse input allow for both horizontal and vertical movement.
Camera Control: By interacting with the player camera, the player script enables the player to move and spin in the camera's direction.
Jumping is made possible by the script, which also imparts gravity to the player's character. If the player isn't already jumping and is on a surface, they can jump by pressing the spacebar.

The player can sprint faster than their base movement speed. The player can sprint in multiple directions while on the ground by hitting the left shift key.
The script makes use of Unity's input system to manage player input, including determining whether or not specific keys have been depressed.
Use these instructions to use this player controller script in a Unity project:

Create a new Unity project or open an existing one.
Create an empty GameObject or select an existing GameObject to attach the script to.
Attach the "Terpenmek" script to the selected GameObject.
Assign the required components and values in the Inspector:
Assign the Rigidbody component to the "Rb" field in the script.
Assign the player camera transform to the "Player Camera" field in the script.
Adjust the movement speed, sprint speed, gravity, and other parameters as needed.
Ensure the scene has the necessary surfaces and colliders for the player to interact with.
Run the game and control the player using the specified input keys and mouse buttons.
Contributing:
Contributions to the repository are welcome. If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

License:
This repository is released under the [license] (insert license information) license. Please review the license file for more details.

Note:
This script is designed to work within a Unity environment and relies on the Unity engine and components. Make sure to have the appropriate version of Unity installed before using the script.


