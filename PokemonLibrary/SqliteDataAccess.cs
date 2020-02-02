using Dapper;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLibrary
{
	public class SqliteDataAccess
	{
		public static List<string> LoadPokemons()
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				var output = cnn.Query<string>("select * from pokemons", new DynamicParameters());
				return output.ToList();
			}
		}

		public static void SavePokemon(string pokemon)
		{
			using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
			{
				cnn.Execute("insert into pokemons (nunber) values(@pokemon)", pokemon);
			}
		}

		private static string LoadConnectionString(string id = "Default")
		{
			//return "Data Source=.\\pokemongo.db;Version=3;";
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
