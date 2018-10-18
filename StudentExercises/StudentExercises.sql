CREATE TABLE Cohort (
	Id 	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	CohortName TEXT NOT NULL
);

CREATE TABLE Student (
	Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	CohortId INTEGER NOT NULL,
	SlackHandle TEXT NOT NULL,
	FOREIGN KEY (CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Instructor (
	Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	FirstName TEXT NOT NULL,
	LastName TEXT NOT NULL,
	CohortId INTEGER NOT NULL,
		SlackHandle TEXT NOT NULL,
	FOREIGN KEY (CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Exercise (
	Id 	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	ExerciseName TEXT NOT NULL,
	ExerciseLanguage TEXT NOT NULL
);

CREATE TABLE StudentExercise (
	Id 	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	StudentId 	INTEGER NOT NULL,
	ExerciseId INTEGER NOT NULL,
	FOREIGN KEY (StudentId) REFERENCES Student(Id),
	FOREIGN KEY (ExerciseId) REFERENCES Exercise(Id)
);

INSERT INTO Cohort (CohortName) VALUES ("Day Cohort 26");
INSERT INTO Cohort (CohortName) VALUES ("Day Cohort 27");
INSERT INTO Cohort (CohortName) VALUES ("Day Cohort 28");
INSERT INTO Cohort (CohortName) VALUES ("Evening Cohort 8");

INSERT INTO Student (FirstName, LastName, CohortId, SlackHandle) VALUES ("Taylor", "Gulley", 2, "taylor1");
INSERT INTO Student (FirstName, LastName, CohortId, SlackHandle) VALUES ("Nolan", "Little", 3, "nolan1");
INSERT INTO Student (FirstName, LastName, CohortId, SlackHandle) VALUES ("Mark", "Hale", 2, "mark1");
INSERT INTO Student (FirstName, LastName, CohortId, SlackHandle) VALUES ("Sathvik", "Reddy", 1, "vik1");
INSERT INTO Student (FirstName, LastName, CohortId, SlackHandle) VALUES ("Jon", "Snow", 4, "jon1");


INSERT INTO Instructor (FirstName, LastName, CohortId, SlackHandle) VALUES ("Steve", "Brownlee", 2, "coach");
INSERT INTO Instructor (FirstName, LastName, CohortId, SlackHandle) VALUES ("Meg", "Ducharme", 2, "meg1");
INSERT INTO Instructor (FirstName, LastName, CohortId, SlackHandle) VALUES ("Andy", "Collins", 2, "andy1");
INSERT INTO Instructor(FirstName, LastName, CohortId, SlackHandle) VALUES ("Kimmy", "Bird", 2, "kimmy1");

INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ("Loops", "C#");
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ("Local Storage", "Javascript");
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ("Modularization", "Javascript");
INSERT INTO Exercise (ExerciseName, ExerciseLanguage) VALUES ("Props", "React");

SELECT * FROM Instructor;