package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part2() int {
	data := readInput()
	dial := 50
	zeros := 0

	for _, inst := range data {
		if inst.direction == 'L' {
			for i := 0; i < int(inst.amount); i++ {
				dial--
				if dial == -1 {
					dial = 99
				}
				if dial == 0 {
					zeros++
				}
			}

		} else if inst.direction == 'R' {
			for i := 0; i < int(inst.amount); i++ {
				dial++
				if dial == 100 {
					dial = 0
				}
				if dial == 0 {
					zeros++
				}
			}

		} else {
			panic("unknown instruction")
		}
	}
	return zeros
}

func part1() int {
	data := readInput()
	dial := 50
	zeros := 0

	for _, inst := range data {
		if inst.direction == 'L' {
			dial -= int(inst.amount)
			for dial < 0 {
				dial += 100
			}
		} else if inst.direction == 'R' {
			dial += int(inst.amount)
			for dial > 99 {
				dial -= 100
			}
		} else {
			panic("unknown instruction")
		}
		if dial == 0 {
			zeros++
		}
	}
	return zeros
}

type instruction struct {
	direction byte
	amount    int64
}

func readInput() []instruction {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]instruction, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		amt, err := strconv.ParseInt(str[1:], 10, 32)
		if err != nil {
			panic(err)
		}
		inst := instruction{
			direction: str[0],
			amount:    amt,
		}
		a = append(a, inst)
	}
	return a
}
