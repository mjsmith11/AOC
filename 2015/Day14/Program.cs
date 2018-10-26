using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Reindeer> ponies = new List<Reindeer>();
			ponies.Add(new Reindeer(22, 8, 165));
			ponies.Add(new Reindeer(8, 17, 114));
			ponies.Add(new Reindeer(18, 6, 103));
			ponies.Add(new Reindeer(25, 6, 145));
			ponies.Add(new Reindeer(11, 12, 125));
			ponies.Add(new Reindeer(21, 6, 121));
			ponies.Add(new Reindeer(18, 3, 50));
			ponies.Add(new Reindeer(20, 4, 75));
			ponies.Add(new Reindeer(7, 20, 119));

			for (int i = 0; i < 2503; i++)
			{
				int max = 0;
				foreach (Reindeer r in ponies) {
					r.tick();
					if (r.getDistance() > max)
					{
						max = r.getDistance();
					}
				}
				foreach (Reindeer r in ponies)
				{
					if (r.getDistance() == max)
					{
						r.givePoint();
					}
				}
				
			}


			int maxPoints = 0;
			int maxDist = 0;
			foreach (Reindeer r in ponies)
			{
				if (r.getDistance() > maxDist)
				{
					maxDist = r.getDistance();
				}
				if (r.getPoints() > maxPoints)
				{
					maxPoints = r.getPoints();
				}
			}
			Console.WriteLine(maxDist);
			Console.WriteLine(maxPoints);
			Console.Read();
		}

	}

	class Reindeer
	{
		private int speed;
		private int flyTime;
		private int restTime;
		private int points;
		private int traveled;
		private bool isFlying;
		private int time;

		public Reindeer(int speed, int flyTime, int restTime)
		{
			this.speed = speed;
			this.flyTime = flyTime;
			this.restTime = restTime;
			this.points = 0;
			this.traveled = 0;
			this.isFlying = true;
			this.time = 0;
		}

		public int getDistance()
		{
			return this.traveled;
		}

		public int getPoints()
		{
			return this.points;
		}

		public void givePoint()
		{
			points++;
		}

		public void tick()
		{
			if (isFlying)
			{
				time++;
				traveled += speed;
				if (time == flyTime)
				{
					time = 0;
					isFlying = false;
				}
			}
			else
			{
				time++;
				if (time == restTime)
				{
					time = 0;
					isFlying = true;
				}
			}
		}
	}

}
