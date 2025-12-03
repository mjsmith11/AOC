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

func part1() int {
	max := 0
	data := readInput()
	for _, s := range data {
		maxDig1 := s[0] - '0'
		maxInd := 0
		for i := 1; i < len(s)-1; i++ {
			if s[i]-'0' > maxDig1 {
				maxDig1 = s[i] - '0'
				maxInd = i
			}
		}
		maxDig2 := s[maxInd+1] - '0'
		for i := maxInd + 2; i < len(s); i++ {
			if s[i]-'0' > maxDig2 {
				maxDig2 = s[i] - '0'
			}
		}
		max += int(maxDig1*10 + maxDig2)
	}
	return max
}

func part2() int64 {
	var max int64
	max = 0
	data := readInput()
	for _, s := range data {
		left := 0
		right := len(s) - 12
		str := ""
		for len(str) < 12 {
			bestDig := s[left] - '0'
			bestInd := left
			for i := left; i <= right; i++ {
				if s[i]-'0' > bestDig {
					bestDig = s[i] - '0'
					bestInd = i
				}
			}
			str = str + string(s[bestInd])

			left = bestInd + 1
			right++
		}
		num, err := strconv.ParseInt(str, 10, 64)
		if err != nil {
			panic(err)
		}
		max += num
	}
	return max
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]string, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		a = append(a, str)
	}
	return a
}
