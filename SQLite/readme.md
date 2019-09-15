This SQLite database was created as follows in Windows

1.  Download/Create the iris.csv dataset eg from https://sites.psu.edu/bdssblog/files/2017/03/iris-2lg34dn.csv
2.  Remove the "."'s from the Column Headings
3.  Add a column named "ColorCode" and fill with the desired color to be displayed for that point
4.  Open a command prompt.
5.  In the appropriate directory create the database using 

    ```
    >sqlite3 irisdb.sqlite
    ```
    
6.  Create the table iristbl using the following command
    
    ```
    CREATE TABLE iristbl(  
	    "Sample" INTEGER,
	    "SepalLength" REAL,
	    "SepalWidth" REAL,
	    "PetalLength" REAL,
	    "PetalWidth" REAL,
	    "Species" TEXT,
	    "ColorCode" TEXT
    );
    ```
    
7.  Set the mode to csv and headers on

    ```
    .mode csv
    .headers ON
    ```
    
8.  Import the csv into SQLite and delete the first row as this will be a repeat of the headers

    ```
    .import iris.csv iristbl
    delete from iristbl where rowid=1;
    ```

9.  Preview the table content and schema, then exit back to normal command prompt.
    
    ```
    select * from iristbl limit 5;
    .schema iristbl
    .quit
    ```
