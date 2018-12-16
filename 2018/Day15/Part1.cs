using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            string input = @"################################
###################..###########
#################.....##########
################.......#########
################......#####...##
#################.....G###.....#
###########.#####....#####..####
###########..####.#.###....#####
##########.GG#.....##......#####
###########.........#...G..#####
###########....GG..........#####
##########G.GG....G....GG..#####
#########.G...#####........#####
#######.G...G#######.E...E..####
###########.#########.......####
##########..#########......#####
##...#####..#########.G....#####
####..#..#..#########.#.....####
###.G.#.....#########..#..#.E###
#####........#######.......E.###
#####.........#####.......######
######............E....E..######
#G.###..G.................######
#..####...............#....#####
#....E#...G.......######...#####
#.............E..#######.#######
###.........E#....##############
######.E.....#..################
#######..........###############
#######......#.#################
#####...#...####################
################################";
            // data parsing
            string[] lines = input.Split('\n');
            int[,] board = new int[lines[0].Trim().Length, lines.Length];
            List<Unit> units = new List<Unit>();
            for (int y = 0; y < lines.Length; y++)
            {
                string s = lines[y].Trim();
                for (int x = 0; x < s.Length; x++)
                {
                    board[x, y] = s[x];
                    if (s[x] == 'E' || s[x] == 'G')
                    {
                        Unit u = new Unit();
                        u.type = s[x];
                        u.loc = new Point();
                        u.loc.x = x;
                        u.loc.y = y;
                        u.hp = 200;
                        u.attackPower = 3;
                        units.Add(u);
                    }
                }
            }


            int roundsComplete = 0;
            bool combatOver = false;
            while (!combatOver)
            {
                //sort for the order of turns
                units = units.OrderBy(o => o.loc.y).ThenBy(o => o.loc.x).ToList();

                // run the turns
                foreach (Unit u in units)
                {
                    if (u.hp <= 0)
                    {
                        continue; //dead units don't get a turn
                    }
                    //try to move
                    // look for enemies
                    char enemyType = u.type == 'E' ? 'G' : 'E';
                    List<Unit> enemies = units.Where(o => o.type == enemyType && o.hp > 0).ToList();
                    if (enemies.Count() == 0)
                    {
                        Console.WriteLine("End of Combat!!!");
                        combatOver = true;
                        int sum = 0;
                        foreach (Unit un in units)
                        {
                            sum += un.hp;
                        }
                        Console.WriteLine(roundsComplete * sum);
                        break;
                    }

                    // find in range points
                    bool alreadyInRange = false;
                    List<Point> range = new List<Point>();
                    foreach (Unit e in enemies)
                    {
                        if (board[e.loc.x, e.loc.y - 1] == '.')
                        {
                            Point p = new Point();
                            p.x = e.loc.x;
                            p.y = e.loc.y - 1;
                            range.Add(p);
                        }
                        else if (u.loc.x == e.loc.x && u.loc.y == e.loc.y - 1)
                        {
                            alreadyInRange = true;
                            break;
                        }
                        if (board[e.loc.x, e.loc.y + 1] == '.')
                        {
                            Point p = new Point();
                            p.x = e.loc.x;
                            p.y = e.loc.y + 1;
                            range.Add(p);
                        }
                        else if (u.loc.x == e.loc.x && u.loc.y == e.loc.y + 1)
                        {
                            alreadyInRange = true;
                            break;
                        }
                        if (board[e.loc.x - 1, e.loc.y] == '.')
                        {
                            Point p = new Point();
                            p.x = e.loc.x - 1;
                            p.y = e.loc.y;
                            range.Add(p);
                        }
                        else if (u.loc.x == e.loc.x - 1 && u.loc.y == e.loc.y)
                        {
                            alreadyInRange = true;
                            break;
                        }
                        if (board[e.loc.x + 1, e.loc.y] == '.')
                        {
                            Point p = new Point();
                            p.x = e.loc.x + 1;
                            p.y = e.loc.y;
                            range.Add(p);
                        }
                        else if (u.loc.x == e.loc.x + 1 && u.loc.y == e.loc.y)
                        {
                            alreadyInRange = true;
                            break;
                        }
                    }
                    if (!alreadyInRange && range.Count() > 0)
                    {
                        // what is reachable in range (Dijkstra's)
                        Dictionary<int, int> dist = new Dictionary<int, int>();
                        Dictionary<int, int> prev = new Dictionary<int, int>();
                        List<Vertex> vertices = new List<Vertex>();
                        int ind = 0;
                        for (int y = 0; y < board.GetLength(1); y++)
                        {
                            for (int x = 0; x < board.GetLength(0); x++)
                            {
                                if (board[x, y] == '.')
                                {
                                    dist[ind] = int.MaxValue;
                                    prev[ind] = -2;
                                    Vertex myV = new Vertex();
                                    myV.id = ind;
                                    myV.loc = new Point();
                                    myV.loc.x = x;
                                    myV.loc.y = y;
                                    vertices.Add(myV);
                                    ind++;
                                }
                            }
                        }
                        dist[ind] = 0;
                        dist[ind] = -1;
                        Vertex v = new Vertex();
                        v.id = ind;
                        v.loc = new Point();
                        v.loc.x = u.loc.x;
                        v.loc.y = u.loc.y;
                        vertices.Add(v);
                        List<Vertex> tree = new List<Vertex>();
                        while (vertices.Count() > 0)
                        {
                            int myU = -1;
                            int minUDist = int.MaxValue;
                            foreach (Vertex inQ in vertices)
                            {
                                if (dist[inQ.id] < minUDist)
                                {
                                    myU = inQ.id;
                                    minUDist = dist[inQ.id];
                                }
                            }
                            if (myU == -1)
                            {
                                // nothing else is reachable
                                break;
                            }
                            Vertex vu = vertices.Single(o => o.id == myU);
                            vertices.RemoveAll(o => o.id == myU);
                            tree.Add(vu);

                            List<Vertex> up = vertices.Where(o => o.loc.x == vu.loc.x && o.loc.y == vu.loc.y - 1).ToList();
                            List<Vertex> down = vertices.Where(o => o.loc.x == vu.loc.x && o.loc.y == vu.loc.y + 1).ToList();
                            List<Vertex> left = vertices.Where(o => o.loc.x == vu.loc.x - 1 && o.loc.y == vu.loc.y).ToList();
                            List<Vertex> right = vertices.Where(o => o.loc.x == vu.loc.x + 1 && o.loc.y == vu.loc.y).ToList();
                            List<Vertex> neighbors = new List<Vertex>();
                            if (up.Count() > 0)
                            {
                                neighbors.Add(up[0]);
                            }
                            if (down.Count() > 0)
                            {
                                neighbors.Add(down[0]);
                            }
                            if (left.Count() > 0)
                            {
                                neighbors.Add(left[0]);
                            }
                            if (right.Count() > 0)
                            {
                                neighbors.Add(right[0]);
                            }
                            foreach (Vertex vv in neighbors)
                            {
                                int alt = dist[myU] + 1;
                                if (alt < dist[vv.id])
                                {
                                    dist[vv.id] = alt;
                                    prev[vv.id] = myU;
                                }
                            }
                        }
                        List<Vertex> minDistVerts = new List<Vertex>();
                        int minDist = int.MaxValue;
                        foreach (Point r in range)
                        {
                            Vertex vr;
                            try
                            {
                                vr = tree.Single(o => o.loc.x == r.x && o.loc.y == r.y);
                            }
                            catch (Exception e)
                            {
                                continue; // unreachable 
                            }
                            if (dist[vr.id] < minDist)
                            {
                                minDistVerts = new List<Vertex>();
                                minDist = dist[vr.id];
                                minDistVerts.Add(vr);
                            }
                            else if (dist[vr.id] == minDist)
                            {
                                minDistVerts.Add(vr);
                            }
                        }
                        if (minDistVerts.Count() == 0)
                        {
                            continue; // nothing in range reachable?
                        }
                        Vertex target = minDistVerts.OrderBy(o => o.loc.y).ThenBy(o => o.loc.x).First();


                        //another dijkstra from the target location
                        Dictionary<int, int> dist2 = new Dictionary<int, int>();
                        Dictionary<int, int> prev2 = new Dictionary<int, int>();
                        List<Vertex> vertices2 = new List<Vertex>();
                        // just use vertices in tree and we don't have to worry about unreachables.
                        foreach (Vertex vt in tree)
                        {
                            dist2[vt.id] = int.MaxValue;
                            prev2[vt.id] = -2;
                            vertices2.Add(vt);
                        }
                        // find the target
                        dist2[target.id] = 0;
                        prev2[target.id] = -1;

                        while (vertices2.Count() > 0)
                        {
                            int myU2 = -1;
                            int minUDist2 = int.MaxValue;
                            foreach (Vertex inQ in vertices2)
                            {
                                if (dist2[inQ.id] < minUDist2)
                                {
                                    myU2 = inQ.id;
                                    minUDist2 = dist2[inQ.id];
                                }
                            }
                            Vertex vu = vertices2.Single(o => o.id == myU2);
                            vertices2.RemoveAll(o => o.id == myU2);

                            List<Vertex> up2 = vertices2.Where(o => o.loc.x == vu.loc.x && o.loc.y == vu.loc.y - 1).ToList();
                            List<Vertex> down2 = vertices2.Where(o => o.loc.x == vu.loc.x && o.loc.y == vu.loc.y + 1).ToList();
                            List<Vertex> left2 = vertices2.Where(o => o.loc.x == vu.loc.x - 1 && o.loc.y == vu.loc.y).ToList();
                            List<Vertex> right2 = vertices2.Where(o => o.loc.x == vu.loc.x + 1 && o.loc.y == vu.loc.y).ToList();
                            List<Vertex> neighbors = new List<Vertex>();
                            if (up2.Count() > 0)
                            {
                                neighbors.Add(up2[0]);
                            }
                            if (down2.Count() > 0)
                            {
                                neighbors.Add(down2[0]);
                            }
                            if (left2.Count() > 0)
                            {
                                neighbors.Add(left2[0]);
                            }
                            if (right2.Count() > 0)
                            {
                                neighbors.Add(right2[0]);
                            }

                            foreach (Vertex vv in neighbors)
                            {
                                int alt = dist2[myU2] + 1;
                                if (alt < dist2[vv.id])
                                {
                                    dist2[vv.id] = alt;
                                    prev2[vv.id] = myU2;
                                }
                            }
                        }
                        Point moveTo = new Point();
                        int minToGo = int.MaxValue;
                        List<Vertex> up3 = tree.Where(o => o.loc.x == u.loc.x && o.loc.y == u.loc.y - 1).ToList();
                        List<Vertex> down3 = tree.Where(o => o.loc.x == u.loc.x && o.loc.y == u.loc.y + 1).ToList();
                        List<Vertex> left3 = tree.Where(o => o.loc.x == u.loc.x - 1 && o.loc.y == u.loc.y).ToList();
                        List<Vertex> right3 = tree.Where(o => o.loc.x == u.loc.x + 1 && o.loc.y == u.loc.y).ToList();
                        if (up3.Count() > 0)
                        {
                            if (dist2[up3[0].id] < minToGo)
                            {
                                minToGo = dist2[up3[0].id];
                                moveTo.x = u.loc.x;
                                moveTo.y = u.loc.y - 1;
                            }
                        }
                        if (left3.Count() > 0)
                        {
                            if (dist2[left3[0].id] < minToGo)
                            {
                                minToGo = dist2[left3[0].id];
                                moveTo.x = u.loc.x - 1;
                                moveTo.y = u.loc.y;
                            }
                        }
                        if (right3.Count() > 0)
                        {
                            if (dist2[right3[0].id] < minToGo)
                            {
                                minToGo = dist2[right3[0].id];
                                moveTo.x = u.loc.x + 1;
                                moveTo.y = u.loc.y;
                            }
                        }
                        if (down3.Count() > 0)
                        {
                            if (dist2[down3[0].id] < minToGo)
                            {
                                minToGo = dist2[down3[0].id];
                                moveTo.x = u.loc.x;
                                moveTo.y = u.loc.y + 1;
                            }
                        }
                        // execute move
                        board[u.loc.x, u.loc.y] = '.';
                        board[moveTo.x, moveTo.y] = u.type;
                        u.loc.x = moveTo.x;
                        u.loc.y = moveTo.y;
                    }
                    // attack
                    Unit attackEnemy = null;
                    int minHp = 201;

                    // up
                    if (board[u.loc.x, u.loc.y - 1] == enemyType)
                    {
                        Unit enemy = units.Single(o => o.loc.x == u.loc.x && o.loc.y == u.loc.y - 1);
                        if (enemy.hp < minHp)
                        {
                            minHp = enemy.hp;
                            attackEnemy = enemy;
                        }
                    }
                    // left
                    if (board[u.loc.x - 1, u.loc.y] == enemyType)
                    {
                        Unit enemy = units.Single(o => o.loc.x == u.loc.x - 1 && o.loc.y == u.loc.y);
                        if (enemy.hp < minHp)
                        {
                            minHp = enemy.hp;
                            attackEnemy = enemy;
                        }
                    }
                    // right
                    if (board[u.loc.x + 1, u.loc.y] == enemyType)
                    {
                        Unit enemy = units.Single(o => o.loc.x == u.loc.x + 1 && o.loc.y == u.loc.y);
                        if (enemy.hp < minHp)
                        {
                            minHp = enemy.hp;
                            attackEnemy = enemy;
                        }
                    }
                    // down
                    if (board[u.loc.x, u.loc.y + 1] == enemyType)
                    {
                        Unit enemy = units.Single(o => o.loc.x == u.loc.x && o.loc.y == u.loc.y + 1);
                        if (enemy.hp < minHp)
                        {
                            minHp = enemy.hp;
                            attackEnemy = enemy;
                        }
                    }

                    if (attackEnemy != null)
                    {
                        attackEnemy.hp -= u.attackPower;
                        if (attackEnemy.hp <= 0)
                        {
                            board[attackEnemy.loc.x, attackEnemy.loc.y] = '.';
                            attackEnemy.hp = 0;
                        }
                    }
                }
                // cleanup
                units.RemoveAll(o => o.hp == 0);
                roundsComplete++;
            }

            Console.ReadLine();
        }
    }
    public class Unit
    {
        public Point loc;
        public char type;
        public int hp;
        public int attackPower;
    }
    public class Point
    {
        public int x;
        public int y;
    }
    public class Vertex
    {
        public int id;
        public Point loc;
    }
}
