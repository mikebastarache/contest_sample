**

Modern Media Contest Template - Version 1.0
----------------------------------------

**

This is a standard contest project template for all Modern Media Visual Studio projects.  


The project is built on top of existing NuGet packages including the Modern Media Contest Library version 2.


----------

Summary
-----------------

The Modern Media .Net team has built a contest template to work on top of the Modern Media Contest Library.   The goal is to continue to find efficiencies and stream line work from one contest to the next.

To enable for this template to work we are setting standards for the forms, labels and messages.  These will all be the same for all contests.  

- This will allow developers to produce contests faster, 
- designers to worry about the important things like branding and spacing,
- copy writers to worry only about important titling and call to actions,
- less things for proof readers to do.

This will create a win, win for all parties involved in the process of developing web applications.  

The key to the success of this template is we MUST stick to the standardized forms.  Click can change the design, content, photos, etc...  but the forms are a no, no.

----------

## How to install template: ##


1. Directory Path: *C:\Users\[user]\Documents\Visual Studio 2012\Templates\ProjectTemplates\*
2. Start Visual Studio 2012
3. Click **'New Project'**
4. Select **'Visual C#'** from the Templates.
5. Choose **'Modern Media Contest Web Application'** template, give it a name, choose a location and click ok to create a new project.
6. Right click on the name of the project solution in the **'Solution Explorer'** and click on **'Enable NuGet Package Restore'** from the menu.  
7. Click on **'Build Solution'**.  This will go online and install all of the NuGet packages required for the web application to run. 


----------


Project Settings
-------------------------------

To customize the web application to run on a client's database, you need to customize the settings that are within the web.config files.

- `connectionStrings` Configure the **'crmContext'** to point to the clients database.
- `ContestId` Place the Id number for the contest.  This is located within the clients database.
- `BallotSource` This tells the database where the ballots come from.  Micro-site, Facebook, etc....
- `ContestUrl_En` This is the English url for the web application.
- `ContestUrl_Fr` This is the French url for the web application.
- `Domain_Fr` This is the basic French domain name with not protocols or other formatting. 
- `Domain_En` This is the basic English domain name with not protocols or other formatting. 
- `ApplicationPath_En` When the web application is hosting in a virtual path, the English folder path needs to be here.  Leave empty if not hosted in virtual path.
- `ApplicationPath_Fr`  When the web application is hosting in a virtual path, the French folder path needs to be here.  Leave empty if not hosted in virtual path.
- `ContestStartDate` Place the start date and time for the web application here.
- `ContestCloseDate` Place the end date and time for the web application here.
- `WebApiUri` This is the URL for the Modern Media Email API service to send emails.
- `AdminEmail` This is the default email address for the web application.
- `GoogleAnalytics_En` This is the code for English analytics.
- `GoogleAnalytics_Fr` This is the code for French analytics.

----------

Default Views/Sections
----------------------------------

The basic contest web application comes with the following sections.

 - **Home** (Enter contest, Prizes, Rules and Privacy policy)
 - **Registration form** (Complete user mailing details. Sends welcome to community email. Registers user within database.  Ability to award ballot.)
 - **Invite a Friend form** (Sends email to invite friend and ability to award extra ballot.  *Optional.*)
 - **Vote** (Poll question that allows user to submit a vote.  *Optional.*)
 - **Messages** (Thank you for entering, Contest Not Open, Contest Closed, Session Timed Out, Generic Error from application, User Does Not Exist, Already Entered Today, Account Creation Failed, Account Update Failed, Ballot Error.


----------

Responsive Design
-------------------

The Modern Media contest template is built using the **960 grid system** from **[http://getskeleton.com](http://getskeleton.com "http://getskeleton.com")**.  Designers can download the **[960 grid PSD template](http://www.getskeleton.com/documentation-assets/Skeleton-Grid.psd.zip)** from there.

The syntax is simple and it's effective cross browser, but the awesome part is that it also has the flexibility to go mobile like a champ. 
      


----------

Current Forms available with this version of template
-----------------
So fair we have three forms that we standardized that will always remain the same.

1. **Enter contents** (email and agree to rules)
2. **Registration** (complete mailing address, year of birth and option to opt into the newsletter)
3. **Invite a friend** (friends name and email)

