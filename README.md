# TestAssignment
 
Context:

An insurance company insures all the employees of a client company. For each employee, the insurance company calculates an insurance premium (coverage of medical services). A typical insurance policy lasts one year and is prorated depending on when the employee joined. For example, if an employee joins three months after the policy starts, their premium will be calculated for nine months.

Pricing Models:

	- Flat Rate: The full premium is $1000 USD.
	
	- Age Rated: The full premium is calculated based on the member's age:

		o Ages 0 to 9: Age * 100

		o Ages 10 to 19: Age * 200

		o Ages 20 to 29: Age * 300

		o Continue similarly for other age ranges.

	- Gender Age Rated: The full premium depends on gender and age:

		o Male: Calculated as per the Age Rated model.

		o Female: Same as the Age Rated model before age 18. After age 18, the premium is multiplied by 1.5.

Prorating Methods:

	- Prorate by Days: Calculate based on the number of days remaining from the member's addition date to the policy end date. For example, if the member addition date is March 1 and the policy end date is December 31, the remaining 	days are 306. Prorated Premium = Full Premium / 365 * 306

	- Prorate by Month: Calculate based on the number of months remaining from the member's addition date to the policy end date. For example, if the member addition date is March 15 and the policy end date is December 31, the 	remaining months are 10. Prorated Premium = Full Premium / 12 * 10

Task:

Write a class with CalculatePremium that calculates an employee's premium. The method should return a tuple with the full premium and prorated premium values.