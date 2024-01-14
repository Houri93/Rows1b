					****************************************
					*                                      *
					*   1 British Billion Rows Challenge   *
					*                                      *
					****************************************
     
	- Rows1b.Generator project
		1. Project that generates the csv file, it takes almost 30 minutes to generate the file (highly unoptimised solution), no need to generate it yourself.
		2. Download the generated csv file from "Z:\Projects\Challenges\1 Billion Rows\rows1b_100_000_000" "4.15 GB".
		3. The file contains rows and column, the rows are seperated with a newline and the cells are seperated by a tab character.
		4. Each row is formatted as the following "{Id}\t{Name}\t{DateOfBirth:yyyy/MM/dd}\t{State}".

	- Rows1b.Shared
		1. Include this project in your project solution
		2. Your solution must implement the "IResultsProducer" interface, Each of the methods are described in the method's comments.

	- Rows1b.Solution.*
		1. This will be the solution each participant will provide
		2. Create a new project, replace the '*' cahracter with your name.
		3. Include the Rows1b.Shared project as a reference.
		4. Create a class named "Rows1bSolution_*" replacing the '*' character with your initials, this class should implement the IResultsProducer Interface with your solution to the problems.
		5. Check in the code.
		6. Deadline is end of 19/01/2024
		7. Each bench test will initialize your solution class via the constructor, run a single test method, then use Dispose() method from IDisposable for cleanup if needed.

	- Rows1b.Bench
		1. This project is used to benchmark the provided solutions via benchmark dotnet.
		2. Each method has a score of 

	- Rowb1b.Solution.EX
		This is an example project which does not implement any of the methods and earns a score 0 out of 100.

	- Rules:
		1. External Libraries / Tools not allowed, this is a purly C# skills challenge.
		2. returning a value without processing the file will result the test wrong, even if the value is correct.
		3. All benchmarks will be ran on 12th Gen Intel Core i9-12900H, 20 logical and 14 physical cores, .NET SDK 8.0.101
		4. You may run the benchmark yourself to test your code and optimise, adapt & overcome!!
		5. The winner will earn the title of "OptoWiz".


	- First 5 rows of the rows file
	0	Amy Zulauf	2000/09/11	Mississippi
	1	Micheal Heidenreich	1995/01/27	Louisiana
	2	Amy Nienow	1958/01/02	Iowa
	3	Shane Mosciski	1979/02/11	Tennessee
	4	Cecilia Russel	1968/12/05	West Virginia
