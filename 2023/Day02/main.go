package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1: ", part1())
	fmt.Println("Part 2: ", part2())
}

func part1() int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	total := 0
	gameId := 1
	for scanner.Scan() {
		s := scanner.Text()
		gameParts := strings.Split(s, ": ")
		grabs := strings.Split(gameParts[1], "; ")
		allGrabsOk := true
		for _, g := range grabs {
			red, green, blue := 0, 0, 0
			colors := strings.Split(g, ", ")
			for _, c := range colors {
				parts := strings.Split(c, " ")
				num, err := strconv.Atoi(parts[0])
				if err != nil {
					panic(err)
				}
				if parts[1] == "red" {
					red = num
				} else if parts[1] == "green" {
					green = num
				} else if parts[1] == "blue" {
					blue = num
				} else {
					panic("Unknown color " + parts[1])
				}
				if !isOk1(red, green, blue) {
					allGrabsOk = false
					break
				}
			}
			if !allGrabsOk {
				break
			}
		}
		if allGrabsOk {
			total += gameId
		}
		gameId++
	}
	return total
}

func part2() int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	total := 0
	for scanner.Scan() {
		s := scanner.Text()
		gameParts := strings.Split(s, ": ")
		grabs := strings.Split(gameParts[1], "; ")
		redMax, greenMax, blueMax := 0, 0, 0
		for _, g := range grabs {
			colors := strings.Split(g, ", ")
			for _, c := range colors {
				parts := strings.Split(c, " ")
				num, err := strconv.Atoi(parts[0])
				if err != nil {
					panic(err)
				}
				if parts[1] == "red" && num > redMax {
					redMax = num
				} else if parts[1] == "green" && num > greenMax {
					greenMax = num
				} else if parts[1] == "blue" && num > blueMax {
					blueMax = num
				}
			}
		}
		power := redMax * blueMax * greenMax
		total += power
	}
	return total
}

func isOk1(red, green, blue int) bool {
	if red > 12 {
		return false
	}
	if green > 13 {
		return false
	}
	if blue > 14 {
		return false
	}
	return true
}
