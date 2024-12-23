package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

func main() {
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}

func part1() int {
	nums := readInput()
	total := 0
	for _, n := range nums {
		for range 2000 {
			n = generate(n)
		}
		total += n
	}
	return total
}

func part2() int {
	nums := readInput()
	max := 0
	seq2Bananas := make(map[string]int)
	for _, n := range nums {
		prices := make([]int, 0)
		for range 2000 {
			n = generate(n)
			prices = append(prices, n%10)
		}
		buyerSeqs := make(map[string]bool)
		for i := 4; i < 2000; i++ {
			d4 := prices[i] - prices[i-1]
			d3 := prices[i-1] - prices[i-2]
			d2 := prices[i-2] - prices[i-3]
			d1 := prices[i-3] - prices[i-4]
			seq := fmt.Sprintf("%v,%v,%v,%v", d1, d2, d3, d4)
			if !buyerSeqs[seq] {
				seq2Bananas[seq] += prices[i]
				buyerSeqs[seq] = true
			}
		}
	}
	for _, v := range seq2Bananas {
		if v > max {
			max = v
		}
	}
	return max
}

func generate(current int) int {
	secret := (current ^ (current * 64)) % 16777216
	secret = (secret ^ (secret / 32)) % 16777216
	return (secret ^ (secret * 2048)) % 16777216
}

func readInput() []int {

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	nums := make([]int, 0)

	for scanner.Scan() {
		n, err := strconv.Atoi(scanner.Text())
		if err != nil {
			panic(err)
		}
		nums = append(nums, n)
	}
	return nums
}
