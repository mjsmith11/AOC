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
			string input = @"                /-->------------------------------\  /-----------------------------------------------------------\                                    
                |      /--------------------------+--+------------------------------------\                      |                /------------------\
                |      |                          |  |      /-----------------------------+----------------------+----------\     |                  |
                |      |                          |  |      |                             |                      |          |     |                  |
               /+------+--------------------------+--+------+-----------------------------+----------\           |          |     |                  |
               ||      |  /-----------------------+--+------+-----------------------------+----------+-----------+----------+-----+--\               |
/--------------++------+--+--------------------\  |  |  /---+-----------------------------+----------+-----------+----------+-----+-\|               |
|  /-----------++------+--+--------------------+--+--+--+---+-----------------------------+---\      |        /--+-------\  |     | ||               |
|  |           ||      |  |                    |  |  |  |   |                             |   | /----+--------+--+-------+\ |     | ||               |
|  |           ||      |  |     /--------------+--+--+--+---+------------------\          |   | |    |        |  |       || |     | ||               |
|  |           ||      |  |     |              |  |  |  |   |    /-------------+----------+---+-+----+--------+-\|       || |     | ||               |
|  |           ||      |  | /---+--------------+--+--+--+---+----+----\        |          |   | |    |        | ||       || |     | ||               |
|  |           ||      |  | |   |              |  |  |  |   |    |    |     /--+----------+---+-+----+--------+-++-------++-+-----+-++--------\      |
|  |           ||      |  | |   |          /---+--+--+--+---+----+--\ |     |  |          |   | |/---+--------+-++--\    || |     | ||        |      |
|  |           ||      \--+-+---+----------+---+--+--+--+---+----+--+-+-----+--+----------/   | ||   |        | ||  |    || |     | ||        |      |
|  |           ||         \-+---+----------+---+--+--+--+---+----+--+-+-----+--+--------------+-++---+--------+-++--+----++-+-----+-+/        |      |
|  |           ||  /--------+---+----\     |   |  |  |  |   |    |  v |     |  |/-------------+-++---+-----\  | ||  |    || |     | |         |      |
|  |           ||  |        |   |   /+-----+---+--+--+--+-\ |    |  | |     |  ||             | ||   |     |  | ||  |    || |     | |         |      |
|  |           ||  |       /+---+---++-----+---+--+--+--+-+-+----+--+-+-----+--++-------------+-++---+-----+--+-++--+----++-+-----+\|         |      |
|  |           ||  |       ||   |   ||     | /-+--+--+--+-+-+----+-\|/+-----+--++-------------+-++---+---\ |  | ||  |    || |     |||         |      |
|  |          /++--+-------++---+-\ ||     | | |  |  |  | | |    | ||||     |  ||             | ||   |   | |  | ||  |    || |  /--+++---------+-----\|
|/-+----------+++--+-------++---+\| ||     | | |  |  |  | | |    | ||||     |  ||             | ||   |   | |  | ||  |    || |  |  |||         |     ||
|| |          |||  |       ||   ||| ||     | | |  |  |  | |/+----+-++++-----+--++-------------+-++---+---+-+--+-++--+----++-+--+--+++----\    |     ||
|| |      /---+++--+-------++---+++-++\    | | |  |  |  | |||    | ||||     |  ||             | ||   |   | |  | ||  |    || |  |  |||    |    |     ||
|| |      |/--+++--+-\     ||   ||| |||    | | |  |  |  | |||    | ||||     |  ||             | ||   |   | |  | ||  |    || |  |  |||    |    |     ||
|| |      ||  |||  | |     ||   ||| |||/---+-+-+--+--+--+-+++----+-++++-----+--++-----\       | ||   |   | |  | ||  |    || |  |  |||    |    |     ||
|| |      ||  |||  | |     ||   \++-++++---+-+-+--+--+--+-+++----+-++++-----+--/|     |       | ||   |   | |  | ||  |    || |  |  |||    |    |     ||
|| |      ||  |\+--+-+-----++----++-++++---+-+-+--+--+--+-+++----+-++++-----+---+-----+-------+-++---/   | |  \-++--+----/| |  |  |||    |    |     ||
|| |      ||  | |  | |  /--++----++-++++---+-+\|  ^  | /+-+++----+-++++-----+---+-----+-------+-++-------+-+----++--+-----+-+--+--+++--\ |    |     ||
|| \------++--+-+--+-+--+--++----++-++++---+-+++--+--+-++-+++----+-++++-----+---+-----+-------/ ||       | |    ||  |     | |  |  |||  | |    |     ||
||        ||  | |  | |  |  \+----++-++++---+-+++--+--+-++-+++----+-++++-----+---+-----+---------++-------+-+----++--+-----+-+--+--+/|  | |    |     ||
||        ||  | |  | |  |   |    || |||| /-+-+++--+--+-++-+++----+-++++-----+---+-----+---------++-------+-+----++--+-----+-+--+-\| |  | |    |     ||
||        ||  | |  | |  |   |    || |||| | | |||  |  | || |||   /+-++++-----+---+-----+---------++-------+-+----++--+-----+-+--+-++-+--+-+--\ |     ||
||  /-----++--+-+\ | |  |   |    || |||| | | |||  | /+-++-+++---++-++++-----+---+-----+---------++-------+-+----++--+-----+-+--+-++-+\ | |  | |     ||
||  |     ||  | || | |  |   |    || |||| | | |||  | |\-++-+++---++-++++-----+---+-----+---------++-------+-+----+/  |     | |  | || || | |  | |     ||
||  |     ||  | || | | /+---+----++-++++-+-+-+++--+-+--++-+++---++-++++-----+---+-----+--\      ||       | |    |   |     | |  | |\-++-+-+--+-+-----+/
||  |/----++--+-++-+-+-++---+----++-++++-+-+-+++--+-+--++-+++---++-++++-----+---+-----+-\|      ||       | |    |   |     | |  | |  || | |  | |     | 
||  ||    ||  | || | | ||   |    || |||| | | |||  | |  || |||   || ||||/----+---+-\   | ||      ||/------+-+----+---+-----+-+--+-+--++-+-+--+-+-\   | 
||  ||    ||  | || | | ||   |    || |||| | | \++--+-+--++-+++---++-/||||    |  /+-+---+-++------+++------+-+----+---+-----+-+--+-+\ || | |  | | |   | 
||  ||    || /+-++-+-+-++---+--\ || |||| | |  ||  | |  || |||   ||  ||||    |  ||/+---+-++-\    |||/-----+-+----+---+-----+-+--+\|| || | |  | | |   | 
||  ||    || || || \-+-++---+--+-++-+/||/+-+--++--+-+--++-+++---++--++++----+--++++---+-++-+----++++-----+-+--\ |   |     | |  |||| || | |  | | |   | 
||  ||    || || ||   | ||  /+--+-++-+-++++\|  ||  | |  || |||   ||  ||||    |  ||||   | || |    ||||     | |  | |   |     | |  \+++-++-+-+--+-+-+---/ 
||  ||    || || ||   | ||  |\--+-++-+-++++++--++--+-+--++-+++---++--++/|    |  ||||   | || |    ||||     | |  | |   |     | |   ||| || | |  | | |     
||  ||    || || ||/--+-++--+---+-++-+-++++++--++--+-+--++-+++---++--++-+----+--++++---+-++-+----++++-----+-+--+-+-\ |     |/+---+++-++-+-+--+-+-+---\ 
||/-++----++-++-+++--+-++--+---+-++-+-++++++--++--+-+--++-+++---++--++-+----+--++++---+-++-+----++++---\ | |  | | | |     |||   ||| || | |  | | |   | 
||| ||    || || |||  | ||  |   | || | ||||||  ||  | \--++-+++---++--++-+----+--++++---+-++-+----++++---+-+-+--+-+-+-+-----+++---+++-+/ | |  | | |   | 
||| ||    || || |||  | ||  |   | ||/+-++++++--++--+----++-+++---++--++-+----+--++++---+-++-+----++++---+-+-+\ | | | |     |||   ||| |  | |  | | |   | 
||| ||    || || |||  | ||  |   | |||| ||||||/-++--+----++-+++---++--++-+----+--++++---+-++-+----++++---+-+-++-+-+-+-+-----+++---+++-+--+-+--+-+\|   | 
||| ||    || || |||  | ||  |   | |||| |\+++++-++--+----++-+++---++--++-+----+--++++---/ || |    |||^   | | || | | | |     |||   ||| |  | |  | |||   | 
|\+-++----++-++-+++--+-++--+---+-/||| | ||||| ||  |    || |||   ||  || |/---+--++++-----++-+----++++---+-+-++-+-+-+-+-----+++---+++-+--+-+--+-+++-\ | 
| | ||    || || |||  | ||  |   |  ||| | ||||| ||  |    || |||   ||  || || /-+--++++-----++-+----++++---+-+-++-+-+-+-+--\  |||   ||| |  | |  | ||| | | 
| | ||   /++-++-+++--+-++--+---+--+++-+-+++++-++--+----++-+++---++--++-++-+-+--++++-----++-+----++++---+-+-++-+\| | |  |  |||   ||| |  | |  | ||| | | 
| | ||   ||| || |||  | ||  |   |  ||| | ||||| ||  |    || |||   ||  || || | |  ||||     || |    ||||   | | || ||| | |  |  |||   ||| |  | |  | ||| | | 
| | ||   ||| || |||  | ||  |   |  ||| | ||||| ||  |    || |||   ||  || || | |  ||||     || |  /-++++---+-+-++-+++-+-+--+\ |||   ||| |  | |  | ||| | | 
| | ||   ||| || |||  | ||  |   |  ||| | ||||| ||  |    || |||   ||  || || | |/-++++-----++-+--+-++++\  | | |v ||| | |  || |||   ||| |  | |  | ||| | | 
| | ||   ||| || |||  | ||  |   |/-+++-+-+++++-++--+----++-+++---++--++\|| | || ||||     || |  | |||||  | | || ||| | |  || |||   ||| |  | |  | ||| | | 
| | \+---+++-++-+/|  | ||  \---++-+++-+-++/|| ||  |    \+-+++---++--+++++-+-++-++++-----++-+--+-+++++--+-+-++-+++-+-+--++-+++---+++-+--/ |  | ||| | | 
| |  |   ||| || | |  | ||      || ||| | || || ||  |     |/+++---++--+++++-+-++\||||     || |  | |||||  | | || ||| | |  || |||   ||| |    |  | ||| | | 
| |  |   ||| || | |  | ||      || ||| | || || || /+-----+++++---++--+++++-+-+++++++-----++-+--+-+++++--+-+-++-+++-+-+--++-+++---+++-+----+\ | ||| | | 
| |  |   ||| || | v  | ||      || ||| | || || || ||     |||||   ||  ||||| | \++++++-----++-+--+-+++++--+-+-++-+++-+-+--++-+++---+++-+----++-+-/|| | | 
| |  |   ||| || | |  | ||      || ||| | || |\-++-++-----+++++---++--+++++-+--++++++-----++-+--+-+++++--+-+-++-+++-+-+--++-+++---+++-+----++-+--/| | | 
| |  |   ||| || | |  | ||      || ||| | || |  || ||     |||||   ||  ||||| |  ||||||     || |  | |||||  | | || ||| | |  || |||   ||| |    || |   | | | 
| |  |   ||| || | |  | ||      || ||| | || |  || ||     |||||   |\--+++++-+--++++++-----++-+--+-+++++--+-+-++-++/ | |  || |||   ||| |    || |   | | | 
| |  |   ||| || | |  | ||      || ||| | || |  || ||     |||||   |   ||||| |  ||||||     || |  |/+++++--+\| || ||  | |  || |||   ||| |    || |   | | | 
| |  |   ||| || | |  | ||      || ||| | || |  || ||     |||||   |   ||||| |/-++++++-----++-+--+++++++--+++-++-++--+-+--++-+++---+++-+\   || |   | | | 
| |  |   ||| || | |  | ||      || ||| | || |  || ||     |||^|   |   ||||| || ||||||     || |  |||\+++--+++-++-++--+-/  || |||   ||| ||   || |   | | | 
| |  |/--+++-++-+-+--+-++------++-+++-+-++-+--++-++-----+++++---+---+++++-++\||||||     || |  ||| |||  ||| || ||  |    || |||   ||| ||   || |   | | | 
| \--++--+++-++-+-+--+-++------++-+++-+-++-+--++-++-----+++++---+---+++++-+++++++++-----++-+--+++-+++--/|| || ||  |    || |||   ||| ||   || |   | | | 
|    ||  ||| || | |  | ||      || ||| | || |  || ||/----+++++---+---+++++-+++++++++-----++-+--+++-+++---++-++-++-\|    || |\+---+++-++---++-+---+-+-/ 
|    ||  ||| || | |  | ||      || ||| | || |  || |||    |||||   |   ||||| |||||||||     || |/-+++-+++---++-++-++-++----++-+-+---+++-++\/-++-+---+-+-\ 
|    ||  ||| || | |  | ||      || ||| | || |  || |||    |||||   |   ||||| ||||||||| /---++-++-+++\|||   || || || ||    || | |   ||| |||| || |   | | | 
|    ||  ||| || | |  | ||      || |||/+-++-+--++-+++----+++++---+---+++++-+++++++++-+---++-++-+++++++---++-++-++\||    || | | /-+++-++++-++-+\  | | | 
|    ||  ||| || | |  |/++------++-+++++-++-+--++\|||    |||||   |   ||||| ||||||||| |   || || |||||||   || || |||||    || | | | ||| |||| || ||  | | | 
|/---++--+++-++-+-+\ ||||   /--++-+++++-++-+--++++++----+++++--\|   ^|||| |||\+++++-+---++-++-++++++/   || || |||||    || | | | ||| |||| || ||  | | | 
||   ||  ||| || | || ||||   |  || ||||| || |  ||||||    |||||  ||   ||||\-+++-+++++-+---++-++-++++++----++-++-+++++----++-+-+-+-+++-++++-++-++--+-/ | 
||   ||  ||| || | || ||||   |  || ||||| || |  ||||||    |||||  ||/--++++--+++-+++++-+---++-++-++++++----++-++-+++++----++-+-+-+-+++-++++-++-++--+---+\
||   ||  ||| || | || ||||   |  || ||||| || |  ||||||    |||||  |||  ||||  ||| ||||| |/--++-++-++++++----++-++-+++++----++-+-+-+-+++-++++-++-++-\|   ||
||/--++--+++-++-+\|| ||||   |  || ||||| || |  ||||||    |||||  |||  ||||  ||| ||||| ||  || || ||||||    || || |||||    || | | | ||| |||| || || ||   ||
|||  ||  ||| || |||| ||||/--+--++-+++++-++-+--++++++----+++++--+++--++++--+++-+++++-++\ || || ||||||    || || |||||    || | | | ||| |||| || || ||   ||
|||  ||  ||| || |||| |||||  |  || ||||| || |  ||||||    |||||  |||  ||||  ||| ||||| ||| || || ||\+++----++-++-+++++----++-/ | | ||| |||| || || ||   ||
|||  ||  ||| || |||| |||||  |  || ||||| || |  ||||||    |||||  |||  ||||  ||| ||||| ||| || || || |||    || || |||||    ||   | | ||| |||| || || ||   ||
|||/-++--+++-++-++++-+++++--+--++-+++++-++-+--++++++--\ |||||  |||  ||||  ||| ||||| ||| || || || |||    || || |||||    ||   | | ||| |||| || || ||   ||
|||| ||  ||| || \+++-+++++--+--++-+++++-++-+--++++/|  | |||||  |||  ||||  ||| ||||| ||| || || || |||    || || |||||    ||   | | ||| |||| || || ||   ||
|||| ||  ||\-++--+++-/||||  |  || ||||| || |  |||| |  | ||||| /+++--++++--+++-+++++-+++-++-++-++-+++----++-++-+++++----++---+-+-+++-++++-++-++\||   ||
|||| ||  ||  ||  |||  ||||  |  || ||||| ||/+--++++-+--+-+++++-++++--++++--+++-+++++-+++-++-++-++-+++----++-++-+++++--\ ||   | | ||| |||| || |||||   ||
||v| ||  ||  ||  |||  ||||  |  || ||||| ||||  |||| |  | ||||| ||||  ||||  ||| ||||| ||| ||/++-++-+++----++-++-+++++\ | ||   | | ||| |||| || |||||   ||
|||| ||  ||  ||  |||  ||||  |  || ||||| ||||  |||| |  | \++++-++++--++++--+++-+++++-+++-+++++-++-+++----++-++-++++++-+-++---+-+-+++-/||| || |||||   ||
|||| ||  ||  ||  |||  ||||  \--++-+++++-++++--++++-+--+--++++-+/||  |\++--+++-+++++-+++-+++++-++-+++----+/ || |||||| | ||   | | |||  ||| || |||||   ||
|||| ||  ||  ||  |||  ||||     || ||||| ||||  |||| |  |  |||| | ||  | ||  ||| ||||| ||| ||||| || |||    |  || |||||| | ||   | | |||  ||| || |||||   ||
\+++-++--++--++--+++--++++-----++-+++++-++++--+/|| | /+--++++-+-++\ | ||  ||| ||||| ||| ||||| || |||    |  || |||||| | ||   | | |||  ||| || |||||   ||
 ||| ||  ||  ||  |||  ||||     || ||\++-++++--+-++-+-++--+/|| | ||| | ||  ||| ||||| ||| ||||| || |||    |  || |||||| | ||   | | |||  ||| || |||||   ||
 ||\-++--++--++--+++--++++-----++-++-++-++++--+-++-+-+/  | || | ||| | ||  |\+-+++++-+++-+++++-++-+++----+--++-++++++-+-++---+-+-+++--/|| || |||||   ||
 ||  ||  ||  ||  |||  ||||     || || || ||||  | || | |   | || | \++-+-++--+-+-+++++-+++-+++++-++-+++----+--++-++++++-+-++---+-+-+++---++-++-/||||   ||
 ||  ||  ||  ||  |||  ||\+-----++-++-++-++++--/ || | |   | || |  || | ||  | ^ ||||| ||| ||||| || |||    |  || |||||| | ||   | | |||   || ||  ||||   ||
 ||  ||  ||  ||  |||  || |     || || || ||||    || | |   | || |  || | ||  | | ||||| ||| ||||| || |||    |  || |||||| | ||   | | |||   || ||  ||||   ||
 ||  ||  ||  ||/-+++--++-+-----++-++-++-++++----++-+-+---+-++-+--++-+-++--+-+-+++++-+++-+++++-++-+++---\|  || |||||| | ||   | | |||   || ||  ||||   ||
 ^|  ||  \+--+++-+++--++-+-----++-++-++-++++----++-+-+---+-++-+--++-+-++--+-+-+++++-+++-+++++-++-+++---++--++-+/|||| | ||   | \-+++---++-++--/|||   ||
 ||  ||   |  ||| |||  ||/+-----++-++-++-++++----++-+-+---+-++-+--++-+-++\ | | ||||| ||| ||||| || |||   ||  || | |||| | ||   |   |||   || ||   |||   ||
 ||  ||/--+--+++-+++--++++-----++-++-++-++++\   || \-+---+-++-+--++-+-+++-+-+-+++++-+++-+++++-++-+++---++--++-+-+/|| | ||   |   |||   || ||   |||   ||
 ||  |||  |  ||| |||  ^|||     || || ||/+++++---++---+---+-++-+--++-+-+++-+-+-+++++-+++-+++++-++\|||   ||  || | | || | ||   |   |||   || ||   |||   ||
 ||  |||  |  ||| |||  ||||     || || ||||||\+---++---+---+-++-+--++-/ ||| | | ||||| \++-+++++-+++/||   ||  || | | || | ||/--+---+++---++-++--\|||   ||
 ||  |||  |  ||| |||  ||||     || || |||||| |   ||   |   | |\-+--++---+++-+-+-+++++--++-+++++-+++-++---++--++-+-+-++-+-+++--/   |||   || ||  ||||   ||
 ||  \++--+--+++-+++--++++-----++-++-++++++-+---++---+---+-+--+--++---+++-+-+-+++++--++-/|||| ||| |\---++--++-+-+-++-+-+++------/||   || ||  ||||   ||
 ||   ||  |/-+++-+++--++++-----++-++-++++++-+---++---+---+-+--+--++---+++-+-+-+++++--++--++++-+++-+--\ ||  || | | || | |||       ||   || ||  ||||   ||
 ||   ||  || ||| |||  ||||     || || |||||| |   ||   |   | |/-+--++---+++-+-+-+++++--++--++++-+++-+--+-++--++-+-+-++-+-+++------\||   || ||  ||v|   ||
 ||   ||  || ||| |||  ||||     || || |||||| |   ||   |   | || |  ||   ||v | | ||\++--++--++++-+++-+--+-++--/| | | || | |||      |||   || ||  ||||   ||
 ||   ||  || ||| |||  ||||/----++-++-++++++-+---++\  |   | || |  ||   |||/+-+-++-++--++--++++-+++\|  | ||  /+-+-+-++-+-+++-----\|||   || ||  ||||   ||
 ||   \+--++-+++-+++--+++++----++-++-++++++-+---+++--+---+-++-+--++---+++++-/ |\-++--++--++++-+++++--+-++--++-+-+-++-+-+++-----+++/   || ||  ||||   ||
 ||    |  || ||| |||  |||||    || || ||\+++-+---+++--+---+-++-+--++---+++++---+--++--++--++++-++/||  | ||  || | | || | |||     |||    || ||  ||||   ||
 ||    |  || ||| |||  \++++----++-++-++-+++-+---/||  |   | || |  ||   |||||   |  ||  \+--++++-++-++--+-++--++-+-+-++-+-+++-----+++----++-++--++/|   ||
 ||    |  || ||| |||   ||||    || || || \++-+----++--+---+-++-+--++---+++++---+--++---+--++++-++-++--+-++--++-/ | || | |||     |||    || ||  || |   ||
 ||    |  || |\+-+++---++++----++-/| ||  || |    ||  |   | || |  ||   |||||   |  ||   |  |||| || ||  | ||  ||   | || | |||     |||/---++-++--++-+--\||
 ||    |  |\-+-+-+++---++++----++--+-++--++-+----++--+---+-++-+--++---+++++---+--++---+--++++-++-++--/ ||  ||   | || | |||     ||||   || ||  || |  |||
 ||    | /+--+-+-+++-\ ||||    ||  | ||  || |    ^|  |   \-++-+--++---+++++---/  ||   |  |||| \+-++----++--++<--+-++-+-+/|     ||||   || ||  || |  |||
/++----+-++--+-+-+++-+\||||    ||  | ||  || |    ||  |     |\-+--++---+++++------++---+--++++--+-++----++--++---+-++-+-+-+-----+/||   || ||  || |  |||
|||    | ||  | | ||| ||||||    ||  | ||  |\-+----++--+-----+--+--++---+++++------++---+--++++--+-++----++--++---+-++-/ | |     | ||   || ||  || |  |||
|||    | ||  | | ||| ||||||    ||  | ||  |  |    ||/-+-----+--+--++---+++++------++---+--++++--+-++----++--++---+-++---+-+-----+-++---++-++-\|| |  |||
|||    | ||  | | ||| ||||\+----++--+-++--+--+----+++-+-----+--+--++---+++++------++---/  ||||  | ||    ||  \+---+-++---+-+-----/ ||   || || ||| |  |||
|||    | ||  | | ||| |||| |    ||  | ||  \--+----+++-+-----+--+--++---+++++------++------++++--+-++----++---+---+-++---+-+-------/|   || || ||| |  |||
|||    | ||  | | ||| |||| |    ||/-+-++-----+----+++-+-----+<-+\ ||   |||||      \+------++/|  | |\----++---+---+-++---+-+--------+---++-++-+++-/  |||
|||    | ||  | \-+++-++++-+----+++-+-++-----+----+++-+-----+--++-++---+++++-------+------++-+--+-+-----/|   |   | ||   | |        |   || || |||    |||
|||    | ||  |   ||| |||| |    ||| | ||     |    ||| |     |  || ||   |\+++-------/      || |  | |      |   |   | ||   | |        |   || || |||    |||
|||    | ||  |   ||| |||| |    ||| | ||     |    ||| \-----+--++-+/   | |||              || |  | |      |   |   | ||   | |        |   || || |||    |||
|||    | ||  |   ||| |||| |    ||| | ||     |    |||       \--++-+----+-+++--------------++-+--+-+------+---+---+-++---+-+--------+---++-/| |||    |||
|||    | ||  | /-+++-++++-+----+++-+-++-----+----+++----------++-+----+-+++-----------\  || |  | |      |   |   | ||   | |        |   ||  | |||    |||
|||    | |\--+-+-+++-++++-+----+++-+-+/  /--+----+++----------++-+----+-+++-----------+--++-+--+-+\     |   |   | ||   | |        |   ||  | |||    |||
|||    | |   | | ||| |||| |    ||| | |   |  |    |||          || |    | |||       /---+--++-+--+-++-----+---+---+\||   | |        |   ||  | |||    |||
|||    | |   | | ||| |||| |    ||| \-+---+--+----+++----------++-+----+-+++-------+---+--++-+--+-++-----+---/   ||||   | \--------+---++--+-+/|    |||
|||    | |   | | ||| |||| |    |||   |   |  |    ||\----------++-+----+-+++-------+---+--++-+--+-++-----+-------++++---+----------+---++--+-/ |    |||
|||    | |   | | ||| |||| |    |||   |   |  |    ||           || |    | |||       |   |  |\-+--+-++-----+-------+++/   |          |   ||  |   |    |||
|||    | |   | | ||| |||| | /--+++---+---+--+----++-----------++-+----+-+++------\|   |  |  |  | ||     |       |||    |          |   ||  |   |    |||
|||    | |   | | ||| |||| | |  |||   |   |  |    ||           || \----+-+++------++---+--+--+--+-++-----+-------+++----+----------+---++--+---+----++/
|||    | |   | | |\+-++++-+-+--+++---+---+--+----++-----------++------+-+++------++---+--+--+--+-++-----+-------++/    |          |   ||  |   |    || 
|||    \-+---+-+-+-+-++++-+-+--+++---+---+--/    ||           ||      | |||      ||   |  |  |  | ||     |       ||     |  /-------+---++--+---+-\  || 
|||      |   | | | | |||| | |  |||   |   |       ||           ||      | |||      ||   |  |  |  | ||     |       ||     |  |       |   ||  |   | |  || 
|||      |   \-+-+-+-++++-+-+--/||   |   |       ||           ||      | |||      |\---+--+--+--+-++-----+-------+/     |  |       |   ||  |   | |  || 
|||      |     | | | |||| \-+---++---+---+-------+/           ||      | |||      |    |  |  |  | ||     |       |      |  |       |   ||  |   | |  || 
|||      |     | | | ||||   |   ||   |   |       |            \+------+-+++------+----+--+--+--+-++-----+-------+------+--+-------+---++--+---/ |  || 
\++------+-----+-+-+-+/||   |   ||   |   |       \-------------+------+-+++------+----+--+--+--+-++-----+-------+------+--+-------+---++--/     |  || 
 |\------+-----+-/ | | ||   |   \+---+---+---------------------+------/ |||      |    |  |  \--+-++-----+-------+------+--+-------+---/|        |  || 
 |       |     |   | | ||   |    \---+---+---------------------/        |||      |    |  |     | ||     |       |      |  |       |    |        |  || 
 |       |     |   | | |\---+--------+---+------------------------------/\+------+----+--+-----+-/|     |       |      |  |       |    |        |  || 
 |       \-----+---+-/ \----+--------+---+--------------------------------+------+----+--/     |  |     |       |      |  |       |    |        |  || 
 \-------------+---/        |        \---+--------------------------------+------+----+--------+--+-----+-------/      |  |       |    |        |  || 
               |            \------------+--------------------------------+------/    |        |  |     |              |  |       |    \--------+--+/ 
               |                         |                                \-----------+--------+--+-----+--------------/  |       |             |  |  
               |                         |                                            |        |  |     |                 |       |             |  |  
               |                         |                                            |        \--+-----/                 |       |             |  |  
               \-------------------------+--------------------------------------------/           |                       |       \-------------+--/  
                                         \--------------------------------------------------------/                       \---------------------/     ";

			string[] splits = input.Split('\n');
			char[,] board = new char[151, 151];
			List<Cart> carts = new List<Cart>();
			for (int y = 0; y < splits.Length; y++)
			{
				for (int x = 0; x < splits[y].Length; x++)
				{
					char cur = splits[y][x];
					if (cur == '>')
					{
						Cart c = new Cart();
						c.x = x;
						c.y = y;
						c.dir = 'R';
						c.next = 'L';
						carts.Add(c);
						cur = '-';
					}
					else if (cur == '<')
					{
						Cart c = new Cart();
						c.x = x;
						c.y = y;
						c.dir = 'L';
						c.next = 'L';
						carts.Add(c);
						cur = '-';
					}
					else if (cur == '^')
					{
						Cart c = new Cart();
						c.x = x;
						c.y = y;
						c.dir = 'U';
						c.next = 'L';
						carts.Add(c);
						cur = '|';
					}
					else if (cur == 'v')
					{
						Cart c = new Cart();
						c.x = x;
						c.y = y;
						c.dir = 'D';
						c.next = 'L';
						carts.Add(c);
						cur = '|';
					}
					board[x,y] = cur;
				}
			}
			int tick = 0;
			while (tick < 1000)
			{
				//Console.WriteLine(tick);
				carts = carts.OrderBy(o => o.y).OrderBy(o => o.x).ToList();
				foreach (Cart c in carts)
				{
					c.move();
					c.updateDir(board[c.x, c.y]);

					List<Cart> atPt = carts.Where(o => (o.x == c.x && o.y == c.y)).ToList();
					if (atPt.Count() > 1)
					{
						Console.WriteLine(c.x + " " + c.y);
					}
				}
				tick++;
			}
			Console.ReadLine();
		}
	}
	public class Cart{
		public int x;
		public int y;
		public char dir;
		public char next;

		public void move()
		{
			if (dir == 'U')
			{
				y--;
			}
			else if (dir == 'D')
			{
				y++;
			}
			else if (dir == 'L')
			{
				x--;
			}
			else if (dir == 'R')
			{
				x++;
			}
		}

		public void updateDir(char space)
		{
			if(space == '+') 
			{
				if (next != 'S') {
					this.turn(next);
				}
				updateNext();
			}
			else if (space == '/')
			{
				if (dir == 'U')
				{
					turn('R');
				}
				else if (dir == 'D')
				{
					turn('R');
				}
				else if (dir == 'L')
				{
					turn('L');
				}
				else if (dir == 'R')
				{
					turn('L');
				}
			}
			else if (space == '\\')
			{
				if (dir == 'U')
				{
					turn('L');
				}
				else if (dir == 'D')
				{
					turn('L');
				}
				else if (dir == 'L')
				{
					turn('R');
				}
				else if (dir == 'R')
				{
					turn('R');
				}
			}
		}

		private void updateNext() {
			if (next == 'L') {
				next = 'S';
			} else if (next == 'S') {
				next = 'R';
			} else {
				next = 'L';
			}
		}

		private void turn(char direction)
		{
			if (dir == 'U')
			{
				if (direction == 'L')
				{
					dir = 'L';
				}
				else {
					dir = 'R';
				}
			}
			else if (dir == 'D')
			{
				if (direction == 'L')
				{
					dir = 'R';
				}
				else {
					dir = 'L';
				}
			}
			else if (dir == 'L')
			{
				if (direction == 'L')
				{
					dir = 'D';
				}
				else {
					dir = 'U';
				}
			}
			else if (dir == 'R')
			{
				if (direction == 'L')
				{
					dir = 'U';
				}
				else {
					dir = 'D';
				}
			}
		}

	}
}
