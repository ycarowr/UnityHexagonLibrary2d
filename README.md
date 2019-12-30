## A hexagonal board implementation using Unity TileMap

This repository contains my implementation of a hexagonal board and additional utility functions using Unity3d TileMaps and the math described by [redblob](https://www.redblobgames.com/grids/hexagons/) and references. 

Feel free to use it in your projects. Any kind of feedback is appreciated. 

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
<p align="center">
<img width="210" height="250" src="/Assets/Textures/Gifs/Sizes.GIF"> <img width="210" height="230" src="/Assets/Textures/Gifs/Menu.GIF">
</p>

## Implementation

### MVC
1. [Model](/Assets/Scripts/BoardSystem/Board)
2. [Views](/Assets/Scripts/Ui)
3. [Controller](/Assets/Scripts/BoardSystem/BoardController.cs)

### Model 

