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
            int myRow = 3010;
            int myCol = 3019;
            int rowStart = 1;
            int row = 1;
            // add (col - 1) to row to find out what row we need to start on so that when we move back up diagonally, we end up on myRow
            while(row<= (myRow +myCol -1))
            {
                rowStart += row;
                row++;
            }
            row--; // undo last loop updates
            rowStart -= row;
            int col = 1;
            int seq = rowStart;

            while(col<myCol)
            {
                col++;
                row--;
                seq++;
            }
            long code = 20151125;
            for (int i=2; i<=seq; i++)
            {
                code = (code * 252533) % 33554393;
            }
            Console.WriteLine(code);
            Console.ReadLine();
        }
    }
}
