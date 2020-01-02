
# A hexagonal board implementation in Unity
<img src="https://media.istockphoto.com/vectors/polygon-background-for-christmas-vector-id619411136">

The repository contains a framework to create, find and store data inside a hexagonal board using Unity [TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) and the math described by [redblob](https://www.redblobgames.com/grids/hexagons/) and it's references. 

The reasons that I made this project are the following:
1. I wanted a generic API that could be easily be extented or integrated into a secondary project;
2. I wanted to have a set of generic classes that manage hexagons and are able to store any kind of data. What I mean by data: creatures, pieces, itens or whatever the main project needs; 
3. I wanted to use the native Unity [TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) components;
 
You can find below images that illustrate the funcionalities and an overview of the system's implementation. 

Feel free to use this tool. Any kind of feedback or credit is well appreciated. 

Playable demo [here](https://ycarowr.itch.io/hexagonal-board)
 
## Functionalities

|Diagonals|Horizontal|
|------------|-------------|
|<img width="382" height="210" src="/Assets/Textures/Gifs/diagonals.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/horizontal.gif">|
|<b>Neighbours</b>|<b>Tile Orientation</b>|
|<img width="382" height="210" src="/Assets/Textures/Gifs/neighbours.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/orientation.gif">|
<!---|<b>Hover</b>|<b>Zoom</b>|
|<img width="382" height="210" src="/Assets/Textures/Gifs/Hover.gif">|<img width="382" height="210" src="/Assets/Textures/Gifs/zoom1.gif">|--->

## Shapes & Sizes
<img width="191" height="105" src="/Assets/Textures/Gifs/rectangle.GIF"> <img width="191" height="105" src="/Assets/Textures/Gifs/triangle.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/hexagon.GIF"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/parallelogram1.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/triangle1.gif"> <img width="191" height="105" src="/Assets/Textures/Gifs/hexagon1.GIF">  

## Menu & Interface

The interface menu to interact with the board data and test the operations.
<p align="center">
<img width="210" height="210" src="/Assets/Textures/Gifs/Sizes.GIF"> <img width="210" height="250" src="/Assets/Textures/Gifs/Menu.GIF">
</p>

## Implementation

### MVC
1. [Model](/Assets/Scripts/BoardSystem/Board)
2. [Views](/Assets/Scripts/Ui)
3. [Controller](/Assets/Scripts/BoardSystem/BoardController.cs)

//TODO: Documentation Overview ...

