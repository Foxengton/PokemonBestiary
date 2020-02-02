using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLibrary
{
	public class MyPokemon
	{
		public MyPokemon(int id, int combatPoint, int ivAttack, int ivDefense, int ivStamina)
		{
			this.id = id;

			//number = pokemon.Number;
			//name = pokemon.Name;

			//generation = pokemon.generation;
			//family = pokemon.Family;
			//stage = pokemon.stage;

			//attack = pokemon.Attack;
			//this.ivAttack = ivAttack;

			//defense = pokemon.Defense;
			//this.ivDefense = ivDefense;

			//stamina = pokemon.Stamina;
			//this.ivStamina = ivStamina;

			//level = StatsCalculator.GetLevel(currentCp, Attack + ivAttack, Defense + ivDefense, Stamina + ivStamina);

			//types = pokemon.types;

			//quickMove = pokemon.quickMove;
			//mainMove = pokemon.mainMove;

			//currentCp = combatPoint;
			//maxCp = pokemon.maxCp;

			//currentHp = StatsCalculator.GetHp(Stamina, ivStamina, level);
			//maxHp = pokemon.maxHp;
		}

		public int id; //ID in your collection

		public double level; //Level of Pokemon

		public int ivAttack; //Base value of attack
		public int ivDefense; //Base value of defense
		public int ivStamina; //Base value of stamina

		public int currentCp;
		public int currentHp;

		public bool isLegendary;
		public bool isShadow;
		public bool isPurify;
		public bool isShiny;
	}
}
