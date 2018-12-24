using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// part one: set boost on line 155 to 0
// part two: expirement with boost on line 155 to find the min for immune to win.
namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Group> groups = new List<Group>();
			Group gr = new Group(1, "infection", 1237, 50749, 12, 70, "radiation");
			gr.weaknesses.Add("radiation");
			gr.immune.Add("cold");
			gr.immune.Add("slashing");
			gr.immune.Add("bludgeoning");
			groups.Add(gr);
			gr = new Group(2, "infection", 4686, 25794, 14, 10, "bludgeoning");
			gr.immune.Add("cold");
			gr.immune.Add("slashing");
			gr.weaknesses.Add("bludgeoning");
			groups.Add(gr);
			gr = new Group(3, "infection", 1518, 38219, 16, 42, "radiation");
			gr.weaknesses.Add("slashing");
			gr.weaknesses.Add("fire");
			groups.Add(gr);
			gr = new Group(4, "infection", 4547, 21147, 4, 7, "slashing");
			gr.weaknesses.Add("fire");
			gr.immune.Add("radiation");
			groups.Add(gr);
			gr = new Group(5, "infection", 1275, 54326, 20, 65, "cold");
			gr.immune.Add("cold");
			groups.Add(gr);
			gr = new Group(6, "infection", 436, 36859, 18, 164, "fire");
			gr.immune.Add("fire");
			gr.immune.Add("cold");
			groups.Add(gr);
			gr = new Group(7, "infection", 728, 53230, 5, 117, "fire");
			gr.weaknesses.Add("radiation");
			gr.weaknesses.Add("bludgeoning");
			groups.Add(gr);
			gr = new Group(8, "infection", 2116, 21754, 10, 17, "bludgeoning");
			groups.Add(gr);
			gr = new Group(9, "infection", 2445, 21224, 13, 16, "cold");
			gr.immune.Add("cold");
			groups.Add(gr);
			gr = new Group(10, "infection", 3814, 22467, 1, 10, "cold");
			gr.weaknesses.Add("bludgeoning");
			gr.weaknesses.Add("radiation");
			groups.Add(gr);
			
			gr = new Group(1, "immune", 597, 4458, 6, 73, "slashing");
			groups.Add(gr);
			gr = new Group(2, "immune", 4063, 9727, 9, 18, "radiation");
			gr.weaknesses.Add("radiation");
			groups.Add(gr);
			gr = new Group(3, "immune", 2408, 5825, 2, 17, "slashing");
			gr.weaknesses.Add("slashing");
			gr.immune.Add("fire");
			gr.immune.Add("radiation");
			groups.Add(gr);
			gr = new Group(4, "immune", 5199, 8624, 15, 16, "radiation");
			gr.immune.Add("fire");
			groups.Add(gr);
			gr = new Group(5, "immune", 1044, 4485, 3, 41, "radiation");
			gr.weaknesses.Add("bludgeoning");
			groups.Add(gr);
			gr = new Group(6, "immune", 4890, 9477, 7, 19, "slashing");
			gr.immune.Add("cold");
			gr.weaknesses.Add("fire");
			groups.Add(gr);
			gr = new Group(7, "immune", 1280, 10343, 19, 64, "cold");
			groups.Add(gr);
			gr = new Group(8, "immune", 609, 6435, 17, 86, "cold");
			groups.Add(gr);
			gr = new Group(9, "immune", 480, 2750, 11, 57, "fire");
			gr.weaknesses.Add("cold");
			groups.Add(gr);
			gr = new Group(10, "immune", 807, 4560, 8, 56, "radiation");
			gr.immune.Add("fire");
			gr.immune.Add("slashing");
			gr.weaknesses.Add("bludgeoning");
			groups.Add(gr);

			while (groups.Where(g => g.type == "immune").Count() > 0 && groups.Where(g => g.type == "infection").Count() > 0)
			{
				//selection
				// order groups
				groups = groups.OrderByDescending(g => g.getEffectivePower()).ThenByDescending(g => g.initiative).ToList();
				foreach (Group g in groups)
				{
					int bestDamage = 0;
					List<Group> choices = groups.Where(v => v.type != g.type && !v.selected).ToList();
					foreach (Group v in choices)
					{
						if (g.calculateDamage(v) > bestDamage)
						{
							if (g.attack != null)
							{
								g.attack.selected = false;
							}
							g.attack = v;
							v.selected = true;
							bestDamage = g.calculateDamage(v);
						}
						else if (g.calculateDamage(v) == bestDamage && bestDamage != 0)
						{
							if (v.getEffectivePower() > g.attack.getEffectivePower())
							{
								g.attack.selected = false;
								g.attack = v;
								v.selected = true;
							}
							else if (v.getEffectivePower() == g.attack.getEffectivePower())
							{
								if (v.initiative > g.attack.initiative)
								{
									g.attack.selected = true;
									g.attack = v;
									v.selected = true;
								}
							}
						}
					}
				}

				// attack
				// sort for attack
				groups = groups.OrderByDescending(g => g.initiative).ToList();
				foreach (Group g in groups)
				{
					g.doAttack();
				}
				// Cleanup
				groups.RemoveAll(g => g.units <= 0);
				foreach (Group g in groups)
				{
					g.attack = null;
					g.selected = false;
				}
			}
			Console.WriteLine("immune units " + groups.Where(g => g.type == "immune").Sum(g => g.units));
			Console.WriteLine("infection units " + groups.Where(g => g.type == "infection").Sum(g => g.units));
			Console.ReadLine();
		}

	}
	public class Group
	{
		public static int boost = 43;
		public int id;
		public string type;
		public int units;
		public int hp;
		public int initiative;
		public int attackDamage;
		public string attackType;
		public List<string> weaknesses;
		public List<string> immune;
		public bool selected;
		public Group attack;

		public Group(int id, string type, int units, int hp, int initiative, int attackDamage, string attackType)
		{
			this.id = id;
			this.type = type;
			this.units = units;
			this.hp = hp;
			this.initiative = initiative;
			this.attackDamage = attackDamage;
			this.attackType = attackType;

			this.weaknesses = new List<string>();
			this.immune = new List<string>();
			this.selected = false;
			this.attack = null;
			if (type == "immune")
			{
				this.attackDamage += boost;
			}

		}
		public int calculateDamage(Group victim)
		{
			if (victim.immune.Contains(attackType))
			{
				return 0;
			}
			int totalAttack = units * attackDamage;
			if (victim.weaknesses.Contains(attackType))
			{
				totalAttack *= 2;
			}
			return totalAttack;
		}

		public void doAttack()
		{
			if (attack == null)
			{
				return;
			}
			int damage = calculateDamage(attack);
			int killedUnits = damage / attack.hp;
			killedUnits = Math.Min(killedUnits, attack.units);
			attack.units -= killedUnits;
		}

		public int getEffectivePower()
		{
			return units * attackDamage;
		}
	}

}
