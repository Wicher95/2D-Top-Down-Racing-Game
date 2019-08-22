# 2D Top Down Racing Game

This is a simple 2D racing game made in Unity 2019.1.8.

## Getting Started


### Controls of the car:
```
W - Accelerate
S - Break/Reverse
A/D - Turning
Space - HandBreak
Escape - Quit to menu
```
### Adding new track:

* Track are made out of tiles, you can find ready tilemap in Assets/Tiles folder.
* The easiest way to make a new track is to duplicate existing one, the first child in track must be PlayerSpawnPoint object - position and rotation are important, at this point the player car will be spawned.
* Next thing is FinishLine, only thing you need to do is to rotate finish line in correct direction, so that the UP Vector is faced towards race direction. FinishLine have to have trigger collider attached to it and be tagged as "FinishLine".
* If that's set you can create any race track with tiles you want, they have composite collider so that player can't leave it's bounds.
* Also if you want some obstacles on the road, just add them as child object to the race track.
* If you want to use water effect (slowing down and sliding down the river stream) you need to add in that place an empty object with "Water" tag and add to it trigger collider, and AudioSource (with sound of water splash) and you are good to go.
* When the track is ready just drag the GameObject to the RaceTrackHolder table and it will apear as the new track in the menu.

## Prerequisites

All you need is Unity 2019.0.2b

## Authors

* **Piotr Wicher** - *Initial work*
