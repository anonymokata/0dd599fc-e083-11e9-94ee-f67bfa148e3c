
How to run the app:
The machimne you run the app on does not need to have a copy of .Net Core or Visual Studio installed on it.

For your convience (and so you do not have to have .Net Core installed on the machine running the app), I have built an application exe, 
zipped it up and included it in the root directory of the repo.  Unqip this file (EHale.Wordsearch.App.zip) into a location on your 
machine and then run the command 'EHale.Wordsearch.App' in the directory which you unzipped the application to.

The aplication will prompt you for the location of a txt file with a puzzle in place.  I have included a sample txt file generated using
http://puzzlemaker.discoveryeducation.com/WordSearchSetupForm.asp?campaign=flyout_teachers_puzzle_wordcross.  The sample file is in the
root directory of the repo as puzzle.txt

How to run the tests:
The machine you run the tests on needs to have a copy of Visual Studio 2017 installed on it to be able to execute the tests.

I have included a built copy of the Test project for your convience in the root of the repo as 'Ehale.Wordsearch.Test.zip'.  To run the
tests, unzip this file to a location on your machine and then using a 'Developer Command Prompt for Visual Studio 2017' run he command
'vstest.console.exe Ehale.Wordsearch.Test.dll'.  This will run the tests and display the results.

Notes / Comments:
- For file reading I make the assumption that the path is valid.  I would check this and give appropriate messages in a live app.
- The kata specified the assumptions (which should be verified in a live app):
	- Format of text file
	- A square puzzle board
	- Existance of the words in the puzzle (only once)
- I assumed 'straight' words (words could not be in an L shape)

You will see the evolution of my thinking in the check ins of this repo.  I appreciate any feedback you have!

Thank you for your time!
Eric Hale





-- THe files contained within this repo are for the explicit use of Eric Hale and Pillar Technologies for Code Demonstration Purposes
   Only.  Any reuse or redistribution of this code or any piece of code in this repository by anyone is strictly forbidden.