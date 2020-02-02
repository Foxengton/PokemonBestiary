using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLibrary
{
	static class StatsCalculator
	{
		//Получить уровень покемона
		public static double GetLevel(int combatPoint, int attack, int defense, int stamina)
		{
			for (int i = 0; i < _cpModifiers.Length; i++)
				if (combatPoint == getCp(attack, defense, stamina, i / 2))
					return i / 2;

			return 0;
		}

		//Получить боевые очки покемона
		public static int getCp(int attack, int defense, int stamina, double level)
		{
			double cpm = _cpModifiers[Convert.ToInt32(level / 0.5) - 1];

			return Math.Max(10, Convert.ToInt32(Math.Floor(0.1 * (attack * cpm) * Math.Pow(defense * cpm, 0.5) * Math.Pow(stamina * cpm, 0.5))));
		}

		//Получить очки здоровья покемона
		public static int GetHp(int baseStamina, int ivStamina, double level)
		{
			return Math.Max(10, Convert.ToInt32(Math.Floor((baseStamina + ivStamina) * _cpModifiers[Convert.ToInt32(level / 0.5) - 1])));
		}

		//Список модификаторов боевых очков
		private static readonly double[] _cpModifiers = new double[]
		{
			0.094,
			0.135137432,
			0.16639787,
			0.192650919,
			0.21573247,
			0.236572661,
			0.25572005,
			0.273530381,
			0.29024988,
			0.306057377,
			0.3210876,
			0.335445036,
			0.34921268,
			0.362457751,
			0.37523559,
			0.387592406,
			0.39956728,
			0.411193551,
			0.42250001,
			0.432926419,
			0.44310755,
			0.4530599578,
			0.46279839,
			0.472336083,
			0.48168495,
			0.4908558,
			0.49985844,
			0.508701765,
			0.51739395,
			0.525942511,
			0.53435433,
			0.542635767,
			0.55079269,
			0.558830576,
			0.56675452,
			0.574569153,
			0.58227891,
			0.589887917,
			0.59740001,
			0.604818814,
			0.61215729,
			0.619399365,
			0.62656713,
			0.633644533,
			0.64065295,
			0.647576426,
			0.65443563,
			0.661214806,
			0.667934,
			0.674577537,
			0.68116492,
			0.687680648,
			0.69414365,
			0.700538673,
			0.70688421,
			0.713164996,
			0.71939909,
			0.725571552,
			0.7317,
			0.734741009,
			0.73776948,
			0.740785574,
			0.74378943,
			0.746781211,
			0.74976104,
			0.752729087,
			0.75568551,
			0.758630378,
			0.76156384,
			0.764486065,
			0.76739717,
			0.770297266,
			0.7731865,
			0.776064962,
			0.77893275,
			0.781790055,
			0.78463697,
			0.787473578,
			0.79030001
		};
	}
}
