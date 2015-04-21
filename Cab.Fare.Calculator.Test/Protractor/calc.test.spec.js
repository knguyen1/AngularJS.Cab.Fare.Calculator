var hasClass = function (element, cls) {
    return element.getAttribute('class').then(function (classes) {
        return classes.split(' ').indexOf(cls) !== -1;
    });
};

describe('NYC Cab Fare Calculator Test', function() {
	beforeEach(function() {
		browser.get('http://localhost:61652/#/');
    });
	
	//check that the message element of the /#/home state loaded correctly
	it("should load the correct view state", function() {
		var message = element(by.id('#message'));
		expect(message.isPresent()).toBe(false);
	});
	
	it("should display a fare for inputs: 5, 2, 2010-10-08, 5:30pm", function() {
		
		//update two numeric inputs by 5 and 2, minutes and miles units, respectively
		element(by.id('numMinutesAbove6mph')).clear().sendKeys(5);
		element(by.id('numMilesBelow6mph')).clear().sendKeys(2);
		
		//click the time elements for 5:30
		element(by.model('hours')).clear().sendKeys(5);
		element(by.model('minutes')).clear().sendKeys(30);
		
		//click if current time is in the AM, click to PM if you're
		//in the AM, if it is, you need to click toggleMeridian()
		var currentTime = new Date();
		if(currentTime.getHours() < 12)
			element(by.css('[ng-click="toggleMeridian()"]')).click();
		
		//first, allow min dates to check for October 08, 2015
		var allowMin = element(by.css('[ng-click="toggleMin()"]'));
		allowMin.click();
		
		//change the dates
		var monthButton = element(by.css('[ng-click="toggleMode()"]'));
		monthButton.click(); //click month button, change to year
		
		//click the back year button
		var backYearButton = element(by.css('[ng-click="move(-1)"]'));
		backYearButton.click();
		backYearButton.click();
		backYearButton.click();
		backYearButton.click();
		backYearButton.click(); //go back to 2010
		
		var octoberButton = element(by.xpath('//button[. = "October"]'));
		octoberButton.click(); //click October
		
		//click on the button for the 8th.  really hacky here... need a new solution
		//what are their two 8th's on the screen?  but i'm lucky here because it works
		var theEighthButton = element(by.xpath('//button[. = "08"]'));
		theEighthButton.click();
		
		//assert
		var computedFare = element(by.id('computedFare'));
		expect(computedFare.getText()).toEqual('$9.75');
	});
	
	it("should then check C# controller calculation (defaulted values)", function() {
		//act
		var cSharpButton = element(by.id('checkCSharp'));
		cSharpButton.click();
		
		//wait for the alert, protractor script is very fast, need
		//to wait for the alertbox to show, otherwise you'll get NoSuchAlertError
		browser.sleep(1000);
		
		//assert
		var alertBox = browser.switchTo().alert();
		expect(alertBox.getText()).toEqual("33.25");
	});
});