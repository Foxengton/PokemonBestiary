using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLibrary
{
	public class Pokemon
	{
		public string Number { get; set; }
		public string Name { get; set; }
		public string Family { get; set; }
		public string Member { get; set; }
		public string Region { get; set; }
		public string Type { get; set; }
		public string Attack { get; set; }
		public string Defense { get; set; }
		public string Stamina { get; set; }
		public string FastAttacks { get; set; }
		public string ChargedAttacks { get; set; }
		public string CatchRate { get; set; }
		public string FleeRate { get; set; }
		public string BuddyDistance { get; set; }
		public string AvailableEggs { get; set; }
		public string AvailableWild { get; set; }
		public string AvailableForms { get; set; }
		public string Rarity { get; set; }

		public static List<Pokemon> GetAll()
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				return cnn.Query<Pokemon>("select * from pokemons", new DynamicParameters()).ToList();
			}
		}
		public static Pokemon[] GetFamily(int family, int stage = -1)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				string command = $"select * from pokemons where family = '{family}'";
				if (stage != -1) command += $" and member = '{stage}'";

				return cnn.Query<Pokemon>(command, new DynamicParameters()).ToArray();
			}
		}

		public static Pokemon GetOne(int number)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				IEnumerable<Pokemon> output = cnn.Query<Pokemon>("select * from pokemons", new DynamicParameters());
				return output.Where(x => x.Number == number.ToString()).ToArray()[0];
			}
		}

		public static int GetFamiliesCount()
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
				return cnn.Query("select distinct family from pokemons").Count();
		}
		public static int[] ForSearchBar(string name)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				return cnn.Query<int>($"select distinct family from pokemons where name like '%{name}%'").ToArray();
			}
		}

		public void Save()
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute("insert into pokemons (number, name, family, member, region, type, attack, defense, stamina, fastAttacks, chargedAttacks, catchRate, fleeRate, buddyDistance, availableEggs, availableWild, availableForms, rarity) " +
					"values (@number, @name, @family, @member, @region, @type, @attack, @defense, @stamina, @fastAttacks, @chargedAttacks, @catchRate, @fleeRate, @buddyDistance, @availableEggs, @availableWild, @availableForms, @rarity)", this);
			}
		}

		private static string LoadConnectionString(string id = "Default") => ConfigurationManager.ConnectionStrings[id].ConnectionString;
	}
}