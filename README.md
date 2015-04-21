# AngularJS.Cab.Fare.Calculator
A light-weight cab fare calculator built in AngularJS and supported by MVC 3 C#

## Hello

This project is written in Angular JS with some simple controllers to calculate a cab fare with some inputted parameters.  A directive has been written to validate numeric fields.  We used components from the Angular Bootstrap library.

A C# controller, supported by dependency injection to make testing easier, has been added as an exercise.  The controller delivers the same calculation in a `JsonResult`.

## Testing

You can find the test files here:

  /root/Cab.Fare.Calculator.Test/
  
MS Test file here:

  /root/Cab.Fare.Calculator.Test/FareCalcTest
  
Q Unit test file here:

  /root/Cab.Fare.Calculator.Test/QUnitTest_AngularJS.Cab.Fare.Calculator.html
  
Protractor test for integration testing here:

  /root/Cab.Fare.Calculator.Test/Protractor
  
Simply launch protractor with:

  ~ protractor conf.js
  
You will need to install node.js and protractor.  More info here: https://github.com/angular/protractor