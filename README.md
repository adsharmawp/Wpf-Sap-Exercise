# Wpf-Sap-Exercise
Wpf Sap Exercise

##Problem Statement

1. Build a screen using WPF which will allow a user to add a script (Microsoft script MSFT, Yahoo script YHOO) to a grid. The script can be of Type A or Type B. See below for the sample screen. The screen allows user to enter Script title, Script type and initial value of the script/stock.
2. Script title can consist of only alphabets and can be of maximum 4 characters.
3. The grid shows script title, type, last rate and current rate. Last rate and current rate is obtained from formula given in step 5.
4. Every 5 seconds Type A script current rate refreshes in the grid. For the Type B script current rate refreshes every 10  seconds.
5. Implement the current rate using the following formula
6. randome number between -50 t9 50 for Type A script
7. randome number between -100 to 100 for Type B script
8. In the grid, if for a particular script, the current rate is negative, show the background in red otherwise show the background in green.
9. Program should be able to handle future script additions e.g. Type C script with a diffrent current rate formaula

User Input Area:

| Script Title  | Script Type   | Initial Value  |          |
| ------------- |:-------------:| --------------:|---------:|
| NEWS          | A             |             12 |Add Button|

Output Grid Area:

| Script Title  | Type          | Last Rate      | Current Rate  |
|-------------  |:-------------:| --------------:|--------------:|
| MSFT          | A             |             10 |            -50|
| YHOO          | B             |             15 |             30|

===========================================================
Note: 
* Separated into logical layers loosely coupled to each other
* Extensible, Performant
* Able to use WPF features as much as possible
* Code Structure: Modularity, usage of OO principles and design patterns, size of classes, and functions, n-path complexity of functions
* Code Quality: class/function/variable naming convntions, package/class structure
* Choice of data structures
* Efficiency of code (leverage multi-threading wherever it makes sense)
