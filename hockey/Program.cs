using System;
using System.Collections.Generic;
using Accord.Statistics.Distributions.Univariate;

namespace HockeyStats
{
	public class Program
	{
		static readonly double HomeGoalsAverage = 3.075;
		static readonly double AwayGoalsAverage = 2.785;
		static readonly int trials = 10;

		static int shutouts = 0;

		static double atlanticPointsToWin = 0;
		static double metropolitanPointsToWin = 0;
		static double pacificPointsToWin = 0;
		static double centralPointsToWin = 0;

		public static void Main(string[] args)
		{
			#region Team Data
			// Create list to hold teams for Atlantic Division
			List<Team> atlanticDivision = new List<Team>
			{
				// Fill division with teams
				new Team("Boston Bruins", 1.167, 0.912, 1.052, 0.849),
				new Team("Buffalo Sabres", 0.722, 1.199, 0.937, 1.118),
				new Team("Detroit Red Wings", 0.810, 1.023, 0.962, 1.086),
				new Team("Florida Panthers", 1.063,  1.016, 0.973, 1.008),
				new Team("Montreal Canadiens", 0.910, 0.991, 0.804, 1.151),
				new Team("Ottawa Senators", 0.992, 1.303, 0.822, 1.070),
				new Team("Tampa Bay Lightning", 1.151, 1.052, 1.271, 0.904),
				new Team("Toronto Maple Leafs", 1.086, 0.955, 1.164, 0.959)
			};

			// Create list to hold teams for Metropolitan Division
			List<Team> metropolitanDivision = new List<Team>
			{
				// Fill division with teams
				new Team("Carolina Hurricanes", 0.855, 1.059, 1.024, 1.047),
				new Team("Columbus Blue Jackets", 0.897, 0.851, 1.077, 1.024),
				new Team("New Jersey Devils", 0.953, 0.991, 1.077, 1.008),
				new Team("New York Islanders", 1.102, 1.332, 1.070, 1.118),
				new Team("New York Rangers", 0.982,  1.095, 0.912, 1.096),
				new Team("Philadelphia Flyers", 0.992, 1.023, 1.085, 0.943),
				new Team("Pittsburgh Penguins", 1.180, 0.962, 1.059, 1.096),
				new Team("Washington Capitals", 1.080, 0.901, 1.052, 1.070)
			};

			// Create list to hold teams for Pacific Division
			List<Team> pacificDivision = new List<Team>
			{
				// Fill division with teams
				new Team("Calgary Flames", 0.855, 1.131, 0.945, 0.904),
				new Team("San Jose Sharks", 1.070, 0.930, 0.980, 0.953),
				new Team("Vegas Golden Knights", 1.158, 0.894, 1.070, 0.975),
				new Team("Arizona Coyotes", 0.793, 1.005, 0.930, 1.079),
				new Team("Edmonton Oilers", 0.927, 1.235, 0.980, 0.959),
				new Team("Vancouver Canucks", 0.943, 1.210, 0.866, 0.959),
				new Team("Anaheim Ducks", 0.998, 0.883, 0.919, 0.855),
				new Team("Los Angeles Kings", 0.936, 0.865, 1.041, 0.816)
			};

			// Create list to hold teams for Central Division
			List<Team> centralDivision = new List<Team>
			{
				// Fill division with teams
				new Team("Winnipeg Jets", 1.236, 0.883, 1.024, 0.910),
				new Team("Nashville Predators", 1.096, 0.912, 1.077, 0.793),
				new Team("St. Louis Blues", 0.897, 0.912, 0.962, 0.936),
				new Team("Dallas Stars", 0.992, 0.865, 0.930, 0.975),
				new Team("Colorado Avalanche", 1.151,  0.858, 0.962, 1.096),
				new Team("Minnesota Wild", 1.070, 0.779, 1.006, 1.109),
				new Team("Chicago Blackhawks", 0.936, 0.973, 0.962, 1.135)
			};
			#endregion
			for (int counter = 0; counter < trials; counter++)
			{
				#region Season Schedule
				// Loop through each team in division to playe home games - Total 41 games
				for (int i = 0; i < atlanticDivision.Count; i++)
				{
					// Play each team in the division twice - 14 games
					for (int j = 0; j < atlanticDivision.Count; j++)
					{
						if (i == j)
						{
							continue;
						}

						PlayGames(atlanticDivision[i], atlanticDivision[j]);
						PlayGames(atlanticDivision[i], atlanticDivision[j]);
					}

					// Play every team in other division of the same conference - 12 games
					for (int j = 0; j < metropolitanDivision.Count; j++)
					{
						if (i % 2 == 0 && j % 2 == 0)
						{
							PlayGames(atlanticDivision[i], metropolitanDivision[j]);
						}
						else if (i % 2 == 1 && j % 2 == 1)
						{
							PlayGames(atlanticDivision[i], metropolitanDivision[j]);
						}
						PlayGames(atlanticDivision[i], metropolitanDivision[j]);
					}

					// Play every team in first division of the other conference - 8 games
					for (int j = 0; j < pacificDivision.Count; j++)
					{
						PlayGames(atlanticDivision[i], pacificDivision[j]);
					}

					// Play every team in second division of the other conference - 7 games
					for (int j = 0; j < centralDivision.Count; j++)
					{
						PlayGames(atlanticDivision[i], centralDivision[j]);
					}
				}

				// Loop through each team in division to playe home games - Total 41 games
				for (int i = 0; i < metropolitanDivision.Count; i++)
				{
					// Play each team in the division twice - 14 games
					for (int j = 0; j < metropolitanDivision.Count; j++)
					{
						if (i == j)
						{
							continue;
						}

						PlayGames(metropolitanDivision[i], metropolitanDivision[j]);
						PlayGames(metropolitanDivision[i], metropolitanDivision[j]);
					}

					// Play every team in other division of the same conference - 12 games
					for (int k = 0; k < atlanticDivision.Count; k++)
					{
						if (i % 2 == 0 && k % 2 == 0)
						{
							PlayGames(metropolitanDivision[i], atlanticDivision[k]);
						}
						else if (i % 2 == 1 && k % 2 == 1)
						{
							PlayGames(metropolitanDivision[i], atlanticDivision[k]);
						}
						PlayGames(metropolitanDivision[i], atlanticDivision[k]);
					}

					// Play every team in first division of the other conference - 8 games
					for (int m = 0; m < pacificDivision.Count; m++)
					{
						PlayGames(metropolitanDivision[i], pacificDivision[m]);
					}

					// Play every team in second division of the other conference - 7 games
					for (int n = 0; n < centralDivision.Count; n++)
					{
						PlayGames(metropolitanDivision[i], centralDivision[n]);
					}
				}

				// Loop through each team in division to playe home games - Total 41 games
				for (int i = 0; i < pacificDivision.Count; i++)
				{
					// Play each team in the division twice - 14 games
					for (int j = 0; j < pacificDivision.Count; j++)
					{
						if (i == j)
						{
							continue;
						}

						PlayGames(pacificDivision[i], pacificDivision[j]);
						PlayGames(pacificDivision[i], pacificDivision[j]);
					}

					if (i % 2 == 1)
					{
						PlayGames(pacificDivision[i], pacificDivision[(i + 2) % pacificDivision.Count]);
					}

					// Play every team in other division of the same conference - 8 games
					for (int k = 0; k < centralDivision.Count; k++)
					{
						if (i % 2 == 1 && k % 2 == 1)
						{
							PlayGames(pacificDivision[i], centralDivision[k]);
						}
						else if (i % 2 == 0 && k % 2 == 0)
						{
							PlayGames(pacificDivision[i], centralDivision[k]);
						}

						PlayGames(pacificDivision[i], centralDivision[k]);
					}

					// Play every team in both divisions of the other conference - 16 games
					for (int m = 0; m < atlanticDivision.Count; m++)
					{
						PlayGames(pacificDivision[i], atlanticDivision[m]);
						PlayGames(pacificDivision[i], metropolitanDivision[m]);
					}
				}

				// Loop through each team in division to playe home games - Total 41 games
				for (int i = 0; i < centralDivision.Count; i++)
				{
					// Play each team in the division twice - 14 games
					for (int j = 0; j < centralDivision.Count; j++)
					{
						if (i == j)
						{
							continue;
						}

						PlayGames(centralDivision[i], centralDivision[j]);
						PlayGames(centralDivision[i], centralDivision[j]);
					}

					PlayGames(centralDivision[i], centralDivision[(i + 1) % centralDivision.Count]);

					// Play every team in other division of the same conference - 8 games
					for (int k = 0; k < pacificDivision.Count; k++)
					{
						if (i % 2 == 1 && k % 2 == 1)
						{
							PlayGames(centralDivision[i], pacificDivision[k]);
						}
						else if (i % 2 == 0 && k % 2 == 0)
						{
							PlayGames(centralDivision[i], pacificDivision[k]);
						}

						PlayGames(centralDivision[i], pacificDivision[k]);
					}

					// Play every team in both divisions of the other conference - 16 games
					for (int m = 0; m < metropolitanDivision.Count; m++)
					{
						PlayGames(centralDivision[i], atlanticDivision[m]);
						PlayGames(centralDivision[i], metropolitanDivision[m]);
					}
				}
				#endregion

				// Sort division by total points
				atlanticDivision.Sort((y, x) => x.Points.CompareTo(y.Points));
				metropolitanDivision.Sort((y, x) => x.Points.CompareTo(y.Points));
				pacificDivision.Sort((y, x) => x.Points.CompareTo(y.Points));
				centralDivision.Sort((y, x) => x.Points.CompareTo(y.Points));

				//
				RecordResults(atlanticDivision, ref atlanticPointsToWin);
				RecordResults(metropolitanDivision, ref metropolitanPointsToWin);
				RecordResults(pacificDivision, ref pacificPointsToWin);
				RecordResults(centralDivision, ref centralPointsToWin);

				foreach (Team team in pacificDivision)
				{
					team.Reset();
				}
				foreach (Team team in centralDivision)
				{
					team.Reset();
				}
				foreach (Team team in metropolitanDivision)
				{
					team.Reset();
				}
				foreach (Team team in atlanticDivision)
				{
					team.Reset();
				}
				Console.WriteLine("Trial " + counter + " Shutouts: " + shutouts);
				shutouts = 0;
			}
			atlanticDivision.Sort((y, x) => x.FirstPlaceFinishes.CompareTo(y.FirstPlaceFinishes));
			metropolitanDivision.Sort((y, x) => x.FirstPlaceFinishes.CompareTo(y.FirstPlaceFinishes));
			pacificDivision.Sort((y, x) => x.FirstPlaceFinishes.CompareTo(y.FirstPlaceFinishes));
			centralDivision.Sort((y, x) => x.FirstPlaceFinishes.CompareTo(y.FirstPlaceFinishes));

			
			atlanticPointsToWin = atlanticPointsToWin / trials;
			metropolitanPointsToWin = metropolitanPointsToWin / trials;
			pacificPointsToWin = pacificPointsToWin / trials;
			centralPointsToWin = centralPointsToWin / trials;

			/*
			#region Display Results
			// Display standing headers
			Console.WriteLine($"{"Atlantic",-12}{"1st",16}{"2nd",8}{"3rd",8}{"Mean",8}");

			// Loop through division to display standings
			foreach (Team team in atlanticDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.FirstPlaceFinishes,7}{team.SecondPlaceFinishes,8}" +
					$"{team.ThirdPlaceFinishes,8}{atlanticPointsToWin,10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Metropolitan",-12}{"1st",16}{"2nd",8}{"3rd",8}{"Mean",8}");

			// Loop through division to display standings
			foreach (Team team in metropolitanDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.FirstPlaceFinishes,7}{team.SecondPlaceFinishes,8}" +
					$"{team.ThirdPlaceFinishes,8}{metropolitanPointsToWin,10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Pacific",-12}{"1st",16}{"2nd",8}{"3rd",8}{"Mean",8}");

			// Loop through division to display standings
			foreach (Team team in pacificDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.FirstPlaceFinishes,7}{team.SecondPlaceFinishes,8}" +
					$"{team.ThirdPlaceFinishes,8}{pacificPointsToWin,10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Central",-12}{"1st",16}{"2nd",8}{"3rd",8}{"Mean",8}");

			// Loop through Central division to display standings
			foreach (Team team in centralDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.FirstPlaceFinishes,7}{team.SecondPlaceFinishes,8}" +
					$"{team.ThirdPlaceFinishes,8}{centralPointsToWin,10}");
			}
			Console.WriteLine();
			#endregion
			/*
			#region Display Standings
			// Display standing headers
			Console.WriteLine($"{"Atlantic",-12}{"GP",12}{"W",4}{"L",4}{"OTL",5}{"PTS",5}{"GF",4}{"GA",4}");

			// Loop through division to display standings
			foreach (Team team in atlanticDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.Wins + team.Losses + team.OvertimeLosses,3}{team.Wins,4}" +
					$"{team.Losses,4}{team.OvertimeLosses,5}{team.Points,5}{team.GoalsFor,4}{team.GoalsAgainst,4}{team.homeGames + " H",10}{team.awayGames + " A",10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Metropolitan",-12}{"GP",12}{"W",4}{"L",4}{"OTL",5}{"PTS",5}{"GF",4}{"GA",4}");

			// Loop through division to display standings
			foreach (Team team in metropolitanDivision)
			{
				Console.WriteLine($"{team.Name,-21}{team.Wins + team.Losses + team.OvertimeLosses,3}{team.Wins,4}" +
					$"{team.Losses,4}{team.OvertimeLosses,5}{team.Points,5}{team.GoalsFor,4}{team.GoalsAgainst,4}{team.homeGames + " H",10}{team.awayGames + " A",10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Pacific",-12}{"GP",12}{"W",4}{"L",4}{"OTL",5}{"PTS",5}{"GF",4}{"GA",4}");

			// Loop through division to display standings
			foreach (Team team in pacificDivision)
			{
				Console.WriteLine($"{team.Name, -21}{team.Wins + team.Losses + team.OvertimeLosses, 3}{team.Wins, 4}" +
					$"{team.Losses, 4}{team.OvertimeLosses, 5}{team.Points, 5}{team.GoalsFor, 4}{team.GoalsAgainst, 4}{team.homeGames + " H",10}{team.awayGames + " A",10}");
			}
			Console.WriteLine();

			// Display standing headers
			Console.WriteLine($"{"Central",-12}{"GP",12}{"W",4}{"L",4}{"OTL",5}{"PTS",5}{"GF",4}{"GA",4}");

			// Loop through Central division to display standings
			foreach (Team team in centralDivision)
			{
				Console.WriteLine($"{team.Name, -21}{team.Wins + team.Losses + team.OvertimeLosses, 3}{team.Wins, 4}" +
					$"{team.Losses, 4}{team.OvertimeLosses, 5}{team.Points, 5}{team.GoalsFor, 4}{team.GoalsAgainst, 4}{team.homeGames + " H",10}{team.awayGames + " A",10}");
			}
			Console.WriteLine();
			#endregion
			*/
			Console.ReadLine();
		}
		
		//
		public static void PlayGames(Team home, Team away)
		{
			home.homeGames++;
			away.awayGames++;

			// Get lambda value for both teams
			double homeLambda = home.HomeAttackStrength * away.AwayDefenseStrength * HomeGoalsAverage;
			double awayLambda = away.AwayAttackStrength * home.HomeDefenseStrength * AwayGoalsAverage;
			
			var poissonHome = new PoissonDistribution(homeLambda);
			var poissonAway = new PoissonDistribution(awayLambda);

			// Determine number of goals each team scored
			int homeGoals = poissonHome.Generate();
			int awayGoals = poissonAway.Generate();

			// Record game results 
			home.GoalsFor += homeGoals;
			away.GoalsFor += awayGoals;
			home.GoalsAgainst += awayGoals;
			away.GoalsAgainst += homeGoals;

			if (homeGoals > awayGoals)
			{
				home.Wins++;
				home.Points += 2;
				away.Losses++;
			}
			else if (awayGoals > homeGoals)
			{
				home.Losses++;
				away.Wins++;
				away.Points += 2;
			}
			else
			{
				while (homeGoals == awayGoals)
				{
					homeGoals = poissonHome.Generate();
					awayGoals = poissonAway.Generate();

					if (homeGoals > awayGoals)
					{
						home.Wins++;
						home.Points += 2;
						away.OvertimeLosses++;
						away.Points++;
						home.GoalsFor++;
						away.GoalsAgainst++;
					}
					else if (awayGoals > homeGoals)
					{
						home.OvertimeLosses++;
						home.Points++;
						away.Wins++;
						away.Points += 2;
						home.GoalsAgainst++;
						away.GoalsFor++;
					}
				}
			}
			if (homeGoals == 0 || awayGoals == 0)
				shutouts++;
		}

		// 
		public static void RecordResults(List<Team> division, ref double pointsToWin)
		{
			pointsToWin += division[0].Points;
			division[0].FirstPlaceFinishes++;
			division[1].SecondPlaceFinishes++;
			division[2].ThirdPlaceFinishes++;
		}
	}

	// Class to hold all needed statistics about a given team
	public class Team
	{
		public int homeGames = 0;
		public int awayGames = 0;

		// Team stats
		public string Name { get; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public int OvertimeLosses { get; set; }
		public int Points { get; set; }
		public int GoalsFor { get; set; }
		public int GoalsAgainst { get; set; }
		public int FirstPlaceFinishes { get; set; }
		public int SecondPlaceFinishes { get; set; }
		public int ThirdPlaceFinishes { get; set; }
		public double HomeAttackStrength { get; }
		public double HomeDefenseStrength { get; }
		public double AwayAttackStrength { get; }
		public double AwayDefenseStrength { get; }

		// Constructor
		public Team(string name, double homeAttackStrength, double homeDefenseStrength, double awayAttackStrength, double awayDefenseStrength)
		{
			Name = name;
			HomeAttackStrength = homeAttackStrength;
			HomeDefenseStrength = homeDefenseStrength;
			AwayAttackStrength = awayAttackStrength;
			AwayDefenseStrength = awayDefenseStrength;

			Wins = 0;
			Losses = 0;
			OvertimeLosses = 0;
			Points = 0;
			GoalsFor = 0;
			GoalsAgainst = 0;

			FirstPlaceFinishes = 0;
			SecondPlaceFinishes = 0;
			ThirdPlaceFinishes = 0;
		}

		public void Reset()
		{
			Wins = 0;
			Losses = 0;
			OvertimeLosses = 0;
			Points = 0;
			GoalsFor = 0;
			GoalsAgainst = 0;
		}
	}
}