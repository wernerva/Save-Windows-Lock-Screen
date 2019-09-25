# Save-Windows-Lock-Screen
A project to copy the lock screens that the Windows 10 OS downloads to the user's My Pictures folder

This project was born from my desire to keep some of the lock screen images that Windows 10 automatically downloads every couple of days.

Some searching on the internet revealed the location of these images.  At first I would manually copy the images to the "My Pictures" 
folder on my computer. This invovled first copying the files to a temporary folder and then renaming them all to JPEG files as they don't 
have file extensions. Then I'd go through them to find the relevant images i wanted and only copy those. It isn't a complicated process 
but it is pretty repetitive, so why not automate.

The solution is a work in progress. I've used .Net Core and created a console app which I compile to a standalone app. I then created a 
shortcut to the EXE file and which I then added to the Startup folder. 

The plan is to create a windows service with and installer. It also needs a logger and some tests. I've created it with testing in mind so 
it should'nt be too hard to write unit tests against the components.

There is still some room for improvement but it works as is for now.
