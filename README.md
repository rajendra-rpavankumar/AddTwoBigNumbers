# AddTwoBigNumbers
Application  for adding two large numbers

| | |
| --- | --- |
| **Build** |  [![Build status](https://ci.appveyor.com/api/projects/status/tcx341v1t66ra2e9?svg=true)](https://ci.appveyor.com/project/rajendra-rpavankumar/addtwobignumbers) |


I would have made the UI more better if I had some more time for developing the application.
I would have done code coverage for the Application.
I want to improve the logging by using pagination mechanism in UI by displaying specified number of lines,for improving the 
performance of UI.

Steps to run and test the api

1. Download the application from Gitthub.
2. Open the Application using VS2015 and run the Application.
3. Modify the Api url with the localhost url in Web.Config
4. Test tha API methods using the User Interface provided
5. The logs can be checked by clicking the CheckLog Menu

The API methods can be test based on the given format

Sum of two values can be checked using GetAddResult

http://localhost:port/api/AddTwoNumbers/GetAddResult?num1=100&num2=200

Log Data can be checked using GetLogData

http://localhost:port/api/AddTwoNumbers/GetLogData

