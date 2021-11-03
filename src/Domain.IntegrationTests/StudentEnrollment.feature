Feature: Student Enrollment
	As a student
	I must be able to enroll to a new course and be notified

@enrollment
Scenario: Student enroll to a new course
	Given a student
	| FirstName | LastName | Email          |
	| John      | Doe      | j.doe@univ.com |
	And a course
	| Title            | Start Date |
	| Computer science | 2021-09-01 |
	When the student enroll to the course as of 2021-08-01
	Then the student should be enrolled
	And an email should be sent


@enrollment
Scenario: Student can't enroll to an already started course
	Given a student
	  | FirstName | LastName | Email          |
	  | John      | Doe      | j.doe@univ.com |
	And a course
	  | Title            | Start Date |
	  | Computer science | 2021-09-01 |
	When the student enroll to the course as of 2021-10-01
	Then the student should not be enrolled
	And no email should be sent
