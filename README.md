MWOStatScraper
==============

MWO Stat Scraper, a tool to scrape your personal stats from the MWO website.

There are .sql files that show the schema for the database tables. You can use SQLCEToolbox program from http://sqlcetoolbox.codeplex.com/ to access/create the database, or you can use Visual Studio to do it. The DB directory here on github should have a readme file listing the tables and their schema, in addition to the "create table" scripts. Make sure to name the database properly, or change the code to access whatever DB you make.

This repository contains a Visual Studio 2012 solution/project. The source should work under any .NET 4.0 framework IDE you use, you'll just have to pull the files into your own project. Please do not upload a different version of the solution file.

<s>This project uses SQLServer Compact Edition 4.0. I will not be uploading the redistributable compact server files, you should track those down and download them from Microsoft (or elsewhere on the web). I might consider making a full distributable MWOStatScraper zip which will include the DLLs needed for runtime, but at present I'm not doing that. If I do, I don't know if it will be here on github or someplace else... we'll have to see.</s>

( I've decided to package up a binary distribution which includes an empty database -- no matches, details, login info, or baseline data -- and the compact server runtime dlls. It can be downloaded from here:
https://www.amazon.com/clouddrive/share?s=Ts30E1gPRUghJA0gptgSFQ
Check the <a href="https://github.com/Savantster/MWOStatScraper/wiki/Binary-distribution-usage"> Wiki page</a> for useage information)


The MWO website often changes.. in addition, they like to forget to post certain bits of match data, or in the case of at least the KitFox, they post 3 lines of "mech" for the Prime.. (PRIME, PRIME(I), and PRIME(G)). It causes the parser to report "mutliple mechs found for this match" type errors, but they can be ignored.. just make sure you leave the extras in the Mechs talbe after the first scrape, or you will keep adding them to the Mechs table and burning up mechids for no real reason.

There used to be a "transaction file" being built, for data recovery.. but with all the errors from the website (and a few logical bugs in the re-write of the code), the file was innacurate. There is currently no built in recovery mechanism for the data in the database. I might put in an "archive data" button/menu so all the current data can be dumped in the event something bad happens to the database.. but that will still mean manual archiving and keeping your directories cleaned out on occasion. Alternatively, just make occasional copies of the database file and remember to dump the baseline and re-seed if you ever have to switch to an older DB for some reason.

That's about it.. this isn't meant to be a general consumption application. I made it for personal use, and a few co-workers figured they'd use it too, but we're all programmers so modifying/tweaking things in here is no big deal. But given the odd behaviors of the MWO site, and the occasional bug that needs to get squished, this isn't really for Joe Computer User and is not being offered as a general application for MWO gamers.
