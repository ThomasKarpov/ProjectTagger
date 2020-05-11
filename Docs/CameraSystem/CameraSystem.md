# Camera System

## Description

The camera system is a single Class which controls the camera movement and Zoom.
It centers around the mid point between the two players with smooth motion.

## Usage

- Add the script to the camera object
	- It expects a Camera component to be present in the object
- Change the exposed values as needed

## On the Exposed Values

### Offset

The offset is the distance from the center point of all players that the camera 
should be in. If this value is left as a zero vector, then the camera will be at 
the midpoint and not focusing on the players. 

### Smoothing Factor

The factor influencing the camera movement.

__NOTE:__ The lower the value the faster the camera will move.
__NOTE:__ The value must be between 0 and 1.

### Zoom Out Boundary

The zoom out boundary. This value is the furthest the camera will zoom out.

### Zoom In Boundary

The zoom in boundary. This value is the closest the camera will zoom in.

### Max Scene Horizontal Dist

The Maximum expected horizontal distance between the 2 players. 

__NOTE:__ If the distance between the players is greater than the specified value, 
the players will no longer be visible on the camera view.
