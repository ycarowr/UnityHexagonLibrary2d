## A hexagonal board implementation using Unity

The repository contains a small framework to create, find and store data inside a hexagonal board using [Unity TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) and the math described by [redblob](https://www.redblobgames.com/grids/hexagons/) and it's references. 

The reasons that I made this project are the following:
1. It can easily be extented or integrated into a secondary project.
2. Usage of [Unity TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) components: I could not find in the web an implementation that binds this unity native component and the math described in [redblob](https://www.redblobgames.com/grids/hexagons/) with a graphic interface.
3. Ready to go: I'd like to have a set of generic classes that manage hexagons and are able to store any kind of data.

Since the requirements above are met, I do believe this repository can save some time in the implementation of hexagonal prototypes/projects that are unity based. 

Feel free to use it. Any kind of feedback is well appreciated. 

You can find below images that illustrate the funcionalities and an overview of the system's implementation.
 
## Operations

|Diagonals|Horizontal|
|------------|-------------|
|<img width="382" height="210" src="/Assets/Textures/Gifs/diagonals.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/horizontal.gif">|
|<b>Neighbours</b>|<b>Tile Orientation</b>|
|<img width="382" height="210" src="/Assets/Textures/Gifs/neighbours.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/orientation.gif">|
<!---|<b>Hover</b>|<b>Zoom</b>|
|<img width="382" height="210" src="/Assets/Textures/Gifs/Hover.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/zoom1.gif">|--->

## Shapes & Sizes
<img width="191" height="105" src="/Assets/Textures/Gifs/rectangle.GIF"> <img width="191" height="105" src="/Assets/Textures/Gifs/triangle.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/hexagon.GIF"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram1.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/triangle1.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/hexagon1.GIF">  

## Menus 

The interface menu to interact with the board data and test the operations.
<p align="center">
<img width="210" height="210" src="/Assets/Textures/Gifs/Sizes.GIF"> <img width="210" height="250" src="/Assets/Textures/Gifs/Menu.GIF">
</p>

## Implementation

### MVC
1. [Model](/Assets/Scripts/BoardSystem/Board)
2. [Views](/Assets/Scripts/Ui)
3. [Controller](/Assets/Scripts/BoardSystem/BoardController.cs)

### Model 

// Documentation on going ...

