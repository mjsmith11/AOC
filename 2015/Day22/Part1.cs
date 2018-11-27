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
			Queue<WizardSim> q = new Queue<WizardSim>();
			q.Enqueue(new WizardSim(500, 50, 10, 71, 0, 0, 0, 0, 0));
			int minToWin = int.MaxValue;
			while (q.Count() > 0)
			{
				WizardSim state = q.Dequeue();
				if (state.pMana >= 53)
				{
					WizardSim copy = new WizardSim(state);
					copy.playerTurn(1);
					if (copy.playerWon())
					{
						if (copy.manaSpent < minToWin)
						{
							minToWin = copy.manaSpent;
						}
					}
					else
					{
						copy.bossTurn();
						if (copy.playerWon())
						{
							if (copy.manaSpent < minToWin)
							{
								minToWin = copy.manaSpent;
							}
						}
						else if (!copy.bossWon())
						{
							q.Enqueue(copy);
						}
					}
				}
				if (state.pMana >= 73)
				{
					WizardSim copy = new WizardSim(state);
					copy.playerTurn(2);
					if (copy.playerWon())
					{
						if (copy.manaSpent < minToWin)
						{
							minToWin = copy.manaSpent;
						}
					}
					else
					{
						copy.bossTurn();
						if (copy.playerWon())
						{
							if (copy.manaSpent < minToWin)
							{
								minToWin = copy.manaSpent;
							}
						}
						else if (!copy.bossWon())
						{
							q.Enqueue(copy);
						}
					}
				}
				if (state.pMana >= 113 && state.shieldTimer <= 1)
				{
					WizardSim copy = new WizardSim(state);
					copy.playerTurn(3);
					if (copy.playerWon())
					{
						if (copy.manaSpent < minToWin)
						{
							minToWin = copy.manaSpent;
						}
					}
					else
					{
						copy.bossTurn();
						if (copy.playerWon())
						{
							if (copy.manaSpent < minToWin)
							{
								minToWin = copy.manaSpent;
							}
						}
						else if (!copy.bossWon())
						{
							q.Enqueue(copy);
						}
					}
				}
				if (state.pMana >= 173 && state.poisonTimer <= 1)
				{
					WizardSim copy = new WizardSim(state);
					copy.playerTurn(4);
					if (copy.playerWon())
					{
						if (copy.manaSpent < minToWin)
						{
							minToWin = copy.manaSpent;
						}
					}
					else
					{
						copy.bossTurn();
						if (copy.playerWon())
						{
							if (copy.manaSpent < minToWin)
							{
								minToWin = copy.manaSpent;
							}
						}
						else if (!copy.bossWon())
						{
							q.Enqueue(copy);
						}
					}
				}
				if (state.pMana >= 229 && state.rechargeTimer <= 1)
				{
					WizardSim copy = new WizardSim(state);
					copy.playerTurn(5);
					if (copy.playerWon())
					{
						if (copy.manaSpent < minToWin)
						{
							minToWin = copy.manaSpent;
						}
					}
					else
					{
						copy.bossTurn();
						if (copy.playerWon())
						{
							if (copy.manaSpent < minToWin)
							{
								minToWin = copy.manaSpent;
							}
						}
						else if (!copy.bossWon())
						{
							q.Enqueue(copy);
						}
					}
				}
			}
			Console.WriteLine(minToWin);
			Console.Read();
		}
	}
	class WizardSim
	{

		public int pMana;
		public int pHit;
		public int bDamage;
		public int bHit;
		public int pArmor;
		public int shieldTimer;
		public int poisonTimer;
		public int rechargeTimer;
		public int manaSpent;

		public WizardSim(WizardSim w)
		{
			this.pMana = w.pMana;
			this.pHit = w.pHit;
			this.bDamage = w.bDamage;
			this.bHit = w.bHit;
			this.pArmor = w.pArmor;
			this.shieldTimer = w.shieldTimer;
			this.poisonTimer = w.poisonTimer;
			this.rechargeTimer = w.rechargeTimer;
			this.manaSpent = w.manaSpent;
		}

		public WizardSim(int pMana, int pHit, int bDamage, int bHit, int pArmor, int shieldTimer, int poisonTimer, int rechargeTimer, int manaSpent)
		{
			this.pMana = pMana;
			this.pHit = pHit;
			this.bDamage = bDamage;
			this.bHit = bHit;
			this.pArmor = pArmor;
			this.shieldTimer  = shieldTimer;
			this.poisonTimer = poisonTimer;
			this.rechargeTimer = rechargeTimer;
			this.manaSpent = manaSpent;
		}

		public void playerTurn(int spell)
		{
			beginTurn();
			if (spell == 1)
			{
				MagicMissile();
			}
			else if (spell == 2)
			{
				Drain();
			}
			else if (spell == 3)
			{
				Shield();
			}
			else if (spell == 4)
			{
				Poison();
			}
			else if (spell == 5)
			{
				Recharge();
			}
		}

		public void bossTurn()
		{
			beginTurn();
			pHit -= (bDamage - pArmor);
		}

		private void beginTurn()
		{
			if (shieldTimer > 0)
			{
				shieldTimer--;
				if (shieldTimer == 0)
				{
					pArmor = 0;
				}
			}

			if (poisonTimer > 0)
			{
				bHit -= 3;
				poisonTimer--;
			}

			if (rechargeTimer > 0)
			{
				pMana += 101;
				rechargeTimer--;
			}
		}

		private void MagicMissile() {
			pMana -= 53;
			manaSpent += 53;
			bHit -= 4;
		}

		private void Drain()
		{
			pMana -= 73;
			manaSpent += 73;
			bHit -= 2;
			pHit += 2;
		}

		private void Shield()
		{
			pMana -= 113;
			manaSpent += 113;
			pArmor = 7;
			shieldTimer = 6;
		}

		private void Poison()
		{
			pMana -= 173;
			manaSpent += 173;
			poisonTimer = 6;

		}

		private void Recharge()
		{
			pMana -= 229;
			manaSpent += 229;
			rechargeTimer = 5;
		}

		public bool bossWon()
		{
			return (pMana < 53) || (pHit <= 0);
		}

		public bool playerWon()
		{
			return bHit <= 0;
		}
	}
}
