package main

import (
	"fmt"
	"math"
)

func main() {
	fmt.Println("Part 1: ", part1())
	fmt.Println("Part 2: ", part2())
}

func part1() int {
	ways := 1
	for length, record := range getInput() {
		waysForThisRace := 0
		for hold := 0; hold <= length; hold++ {
			distance := hold * (length - hold)
			if distance > record {
				waysForThisRace++
			}
		}
		ways *= waysForThisRace
	}
	return ways
}

func part2() int64 {
	length, record := getInput2()
	// record=hold*length-hold
	// 0 = -hold^2 + hold*length - record

	//round both up and subtract

	h1 := (float64(-1*length) + math.Sqrt(math.Pow(float64(length), 2)-float64(4*record))) / float64(-2)
	h2 := (float64(-1*length) - math.Sqrt(math.Pow(float64(length), 2)-float64(4*record))) / float64(-2)

	// round both up then subtract
	return int64(h2+1) - int64(h1+1)
}

func getInput() map[int]int {
	return map[int]int{
		// 7:  9,
		// 15: 40,
		// 30: 200,

		49: 356,
		87: 1378,
		78: 1502,
		95: 1882,
	}
}

func getInput2() (int64, int64) {
	//return 71530, 940200
	return 49877895, 356137815021882
}
