# AmongUsRegionsEditor
A program which easily allows the editing of the regioninfo.json file which controls the regions you can use in among us. It does not allow editing of official regions, just allows you to import/export (for easy sharing) and add/edit/remove custom regions for private servers

Upon first run, the program will create "Import" and "Export" folders in the location it is put, 

if you click "Export" button for any row in the custom regions table, it will copy this from your regioninfo.json to a new ".aur" file in the Export folder.
if you share a ".aur" file with someone, they can put it in their "Import" folder, open the program, and it will auto import and save this within the regioninfo.json

Once you open the program, you will see various buttons...
Create Region will allow you to add a new region.
Edit (on the custom region rows) will allow you to edit an already existing region.
Remove (on the custom region rows) will allow you to remove an already existing region.
Cancel (on the region edit/add section) will close the Region Add/Edit section without changing anything)
Save Region (on the region edit/add section) will add/edit the region in the custom regions table
Save RegionInfoJson will submit the changes to the regioninfo.json so they can be used in among us.

If while editing or adding a region you leave DNS unchecked, it will auto fill with the IP (recommended).
if you know there is a different DNS name, check the box and enter it.
