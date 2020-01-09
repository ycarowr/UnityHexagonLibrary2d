
# A hexagonal board implementation in Unity
<img src="https://media.istockphoto.com/vectors/polygon-background-for-christmas-vector-id619411136">

The repository contains an API to create, find and store data inside a hexagonal board using Unity [TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) and the math described by [redblob](https://www.redblobgames.com/grids/hexagons/) and it's references. 

The reasons that I made this project are the following:
1. I wanted a generic API that could be easily be extended or integrated into a secondary project;
2. I wanted to have a set of generic classes that manage hexagons and are able to store any kind of data. What I mean by data are: creatures, pieces, itens or whatever the main project needs; 
3. I wanted to use the native Unity [TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) components;
 
You can find below images that illustrate the functionalities and an overview of the system's implementation. 

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

# Implementation

## MVC 
1. [Model](/Assets/Scripts/BoardSystem/Board)
2. [Views](/Assets/Scripts/Ui)
3. [Controller](/Assets/Scripts/BoardSystem/BoardController.cs)

## Board
I split the board implementation in three distict parts:
1. [Board](/Assets/Scripts/BoardSystem/Board/Board.cs) has a data shape that determines it's layout. Also holds a list of Positions that store the data elements of the board;
2. [BoardManipulation](/Assets/Scripts/BoardSystem/Board/BoardManipulationOddR.cs) is resposible to implement the operations such as diagonals, neighbours or anything else that could come up in the future;
3. [Position](/Assets/Scripts/BoardSystem/BoardController.cs) is the class that holds the elements placed in the board; Currently each position is able to carry one single object, however it can be extended to an array;

## Coordinates
There are two different [Coordinates](/Assets/Scripts/BoardSystem/Board/Coordinates) to manage, the Hex and Offset.
1. [Hex](Assets/Scripts/BoardSystem/Board/Coordinates/Hex.cs) is used internally by the Manipulation to figure out the necessary points to include in each operation. Operations using this type of coordinate system have simpler algorithms.
2. [Offset](/Assets/Scripts/BoardSystem/Board/Coordinates/OffsetCoord.cs) is used by Unity [TileMaps](https://docs.unity3d.com/Manual/class-Tilemap.html) native component, in other words, we can't change it; 
3. [OffsetCoordHelper](Assets/Scripts/BoardSystem/Board/Coordinates/OffsetCoordHelper.cs) is the class that manages the convertion from Hex -> Offset or Offset -> Hex;
