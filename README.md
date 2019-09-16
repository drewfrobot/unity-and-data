# unity-and-data
**Visualising Data in Unity 3D**

A beginning exploration into visualising data in Unity 3D using SQLite. 

Murray https://www.forbes.com/sites/evamurray/2019/03/29/what-is-the-difference-between-data-analysis-and-data-visualization/#49c54afe6411 summarises data analysis quite succinctly as a process which begins with a question, and through the use of data, along with a healthy dose of curiosity and tenacity, attempts to find answers which can be difficult to find. Murray also notes consumers of effective data visualisations need less time to process the information and gain quicker insights. 

The ability to actually actually explore expansive data landscapes offers new opportunities for intuitive insights over what is possible with traditional tools such as Excel, R or even D3.js.

SQLite is used as 
  a)  it is in the public domain, 
  b)  runs locally without the need for a server,
  c)  can handle huge datasets as it is disk based (not memory based like R),
  d)  can be called repeatedly to vary easily the visualisations in the same session. (not easily done for csv)

The iris data set is the basis for the visualisation. The set includes Sepal and Petal Length and Width for three species of iris. The visualisations all have the Sepal Length and Width on the horizontal axis and the Petal Length on the vertical axis. A color code column has also been added Green - Setosa, Yellow - Versicolor and Red - Virginica.


**Setup**

1.  In a new Unity Project, create a Plugins folder in the Assets folder.

2.  For a windows machine, download SQLite "dll" and "tools" packages from https://www.sqlite.org/download.html, unzip and place the following files
      sqlite3.def
      sqlite3.dll
    into this newly created Plugins folder. 

3.  Download the irisdb.sqlite from this repository and place it in the Assets folder.

4.  From the local unity installation at 
    ```
    C:\Program Files\Unity\...\UnityVersion\Editor\Data\Mono\lib\mono\2.0, 
    ```
    copy the following files to the Asset folder.
     ``` 
      Mono.Data.Sqlite.dll
      Mono.Data.SqliteClient.dll
     ```
     the file System.Data.dll may also be required, though it can cause clashes with other versions of the file elsewhere in the Unity installation.
      
5.  Recommend using EditorSceneMemoryManager.cs from the following website. 

    https://medium.com/@lynxelia/unity-memory-management-how-to-manage-memory-and-reduce-the-time-it-takes-to-enter-play-mode-fd07b43c1daa

    This script forces garbage collection to be performed every time the project is played.
    
6.  Download the DBAccess.cs script from this repository and place it in the Assets folder

7.  Create a GameObject > 3D > Cube. Remove Box Collider, it is not needed.

8.  Drag this to the Assets window to create a prefab; rename it "Bar". 
    Remove the GameObject from the hierarchy.
    Change the scale to 0.05/0.05/0.05
    
9.  Create an empty GameObject, call it DBAccess.

10. Drag the downloaded DBAccess Script onto the DBAccess GameObject in the hierarchy. 
    This attached C# script will be used to manipulate the object during play. 

11. Open DBAccess to edit. If installed Visual Studio Code https://code.visualstudio.com/ will open automatically.

12. In the inspector window for the GameObject DBAccess there is a variable for the prefab, called Bar Prefab. Drag the "bar" prefab onto this variable in the inspector window.

13. Add a GameObject > 3D > Plane, and change its scale to 2/2/2. 

14. Add a controller to allow navigation of the scene. Download if not already available the FPSController.prefab from the Standard Assets package in the Asset Store. Drag it into the Scene Window, above the plane. Disable the Main Camera in the Inspector Window.

15. The DBAccess script has three scenarios which can be explored by commenting/uncommenting various lines of code.

The first scenario is displaying the scatterplot for all three species, the second displays for only the Setosa species and the third changes the scatterplot into a pseudo bar chart/plot.

![Scatterplot - 3 Species](https://raw.githubusercontent.com/drewfrobot/unity-and-data/master/Images/1scatterplot_3species.png)
![Scatterplot - 1 Species](https://raw.githubusercontent.com/drewfrobot/unity-and-data/master/Images/2scatterplot_1species.png)
![Barplot - 3 Species](https://raw.githubusercontent.com/drewfrobot/unity-and-data/master/Images/3bars_3species.png)

**Inspirations for this exercise**

SQLite setup in Unity
https://answers.unity.com/questions/743400/database-sqlite-setup-for-unity.html

Iris data set visualised as spheres from CSV file. Uses transforms which can linger in the scene after play mode stopped.
https://sites.psu.edu/bdssblog/2017/04/06/basic-data-visualization-in-unity-scatterplot-creation/

Mathematical functions eg sine wave, visualised by vary resolution of small cubs which form line graph of function
https://catlikecoding.com/unity/tutorials/basics/building-a-graph/

Scatterplots in 3D in R
http://www.sthda.com/english/wiki/scatterplot3d-3d-graphics-r-software-and-data-visualization
