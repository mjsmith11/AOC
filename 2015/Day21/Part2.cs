using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Part2
	{
		static void Main(string[] args)
		{
			const int playerPoints = 100;
			const int bossPoints = 103;
			const int bossDamage = 9;
			const int bossArmor = 2;
			List<Item> Weapons = new List<Item>();
			Weapons.Add(new Item(8, 4, 0));
			Weapons.Add(new Item(10, 5, 0));
			Weapons.Add(new Item(25, 6, 0));
			Weapons.Add(new Item(40, 7, 0));
			Weapons.Add(new Item(74, 8, 0));

			List<Item> Armor = new List<Item>();
			Armor.Add(new Item(0,0,0)); // Armor is optional
			Armor.Add(new Item(13, 0, 1));
			Armor.Add(new Item(31, 0, 2));
			Armor.Add(new Item(53, 0, 3));
			Armor.Add(new Item(75, 0, 4));
			Armor.Add(new Item(102, 0, 5));

			List<Item> Rings = new List<Item>();
			Rings.Add(new Item(0, 0, 0));
			Rings.Add(new Item(0, 0, 0)); //0-2 rings
			Rings.Add(new Item(25, 1, 0));
			Rings.Add(new Item(50, 2, 0));
			Rings.Add(new Item(100, 3, 0));
			Rings.Add(new Item(20, 0, 1));
			Rings.Add(new Item(40, 0, 2));
			Rings.Add(new Item(80, 0, 3));

			int maxWinCost = int.MinValue;

			for (int w = 0; w < Weapons.Count(); w++)
			{
				for (int a = 0; a < Armor.Count(); a++)
				{
					for (int r1 = 0; r1 < Rings.Count(); r1++)
					{
						for (int r2 = 0; r2 < Rings.Count(); r2++)
						{
							if (r1 == r2) { continue; }
							int cost = Weapons[w].Cost + Armor[a].Cost + Rings[r1].Cost + Rings[r2].Cost;
							int armor = Weapons[w].Armor + Armor[a].Armor + Rings[r1].Armor + Rings[r2].Armor;
							int damage = Weapons[w].Damage + Armor[a].Damage + Rings[r1].Damage + Rings[r2].Damage;
							if (!playerWins(playerPoints, damage, armor, bossPoints, bossDamage, bossArmor) && cost > maxWinCost)
							{
								maxWinCost = cost;
							}
						}
					}
				}
			}
			Console.WriteLine(maxWinCost);
			Console.Read();
		}
		public static bool playerWins(int playerPoints, int playerDamage, int playerArmor, int bossPoints, int bossDamage, int bossArmor)
		{
			int playerAttack = playerDamage - bossArmor;
			if (playerAttack < 1) { playerAttack = 1; }
			int bossAttack = bossDamage - playerArmor;
			if (bossAttack < 1) { bossAttack = 1; }

			while (true)
			{
				bossPoints -= playerAttack;
				if (bossPoints <= 0)
				{
					return true;
				}
				playerPoints -= bossAttack;
				if (playerPoints <= 0)
				{
					return false;
				}
			}
		}
	}
	class Item
	{
		public int Cost;
		public int Damage;
		public int Armor;

		public Item(int Cost, int Damage, int Armor)
		{
			this.Cost = Cost;
			this.Damage = Damage;
			this.Armor = Armor;
		}
	}
}
