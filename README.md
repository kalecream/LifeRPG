# LifeRPG
Since the developer of [LifeRPG](https://play.google.com/store/apps/details?id=com.jayvant.liferpgmissions&hl=en_US) seems to have abandoned his app, I'm hoping it's ok to make an open-source black-box version of it...

# Plan
First up is to get the .NET Core web app working with one user, with all the same functionality as the Android app.

Then, I'll work on extending the DB schema to allow multiple users, in order to be able to deploy on Azure (free hosting FTW!)

After all of that is working, I want to tackle re-creating the Android app, but I'll keep it open-source, so that hopefully together we can build a free life gamification app that keeps working and keeps helping people into the future.

# Want to help?
Contributors are welcome!  Either put in a pull request, or drop me a note asking to be added.  I'm not picky about who can contribute, but if you wreck my app on the master branch I'll probably drop you. :)

_Currently I'm letting the app database drive the design; if you need a LifeRPG database to start with, download the app and use the Settings-->Export Database option.  When I start editing the database schema, I'll set up EF Code First migrations._