package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", run(25))
	fmt.Println("Part 2:", run(75))
}

func run(blinks int) int {
	nums := readInput()
	inventory := make(map[int]int)
	for _, n := range nums {
		inventory[n]++
	}
	for i := 0; i < blinks; i++ {
		newInventory := make(map[int]int)
		for k, v := range inventory {
			if k == 0 {
				newInventory[1] += v
			} else if ok, l, r := trySplit(k); ok {
				newInventory[l] += v
				newInventory[r] += v
			} else {
				newInventory[2024*k] += v
			}
		}
		inventory = newInventory
	}
	sum := 0
	for _, v := range inventory {
		sum += v
	}
	return sum
}

func trySplit(n int) (bool, int, int) {
	s := fmt.Sprintf("%v", n)
	if len(s)%2 != 0 {
		return false, -1, -1
	}
	left, err := strconv.Atoi(s[:len(s)/2])
	if err != nil {
		panic(err)
	}
	right, err := strconv.Atoi(s[len(s)/2:])
	if err != nil {
		panic(err)
	}
	return true, left, right
}

func readInput() []int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	scanner := bufio.NewScanner(f)
	scanner.Scan()
	splits := strings.Split(scanner.Text(), " ")
	res := make([]int, len(splits))
	for i, s := range splits {
		n, err := strconv.Atoi(s)
		if err != nil {
			panic(err)
		}
		res[i] = n
	}
	return res
}
