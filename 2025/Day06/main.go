package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int64 {
	nums, ops := readInput()
	var total int64
	total = 0
	for col := 0; col < len(nums[0]); col++ {
		var ans int64
		if ops[col] == "+" {
			ans = 0
		} else {
			ans = 1
		}
		for row := 0; row < len(nums); row++ {
			if ops[col] == "+" {
				ans += nums[row][col]
			} else {
				ans *= nums[row][col]
			}
		}
		total += ans
	}
	return total
}

func part2() int64 {
	nums, ops := readInput2()
	start := 0
	end := 0
	var total int64
	total = 0
	for start < len(ops) {
		if end+2 == len(ops) {
			end = 3684 // this might be specific to my input
		} else {
			for end < len(ops) && ops[end+1] == ' ' {
				end++
			}
		}

		var ans int64
		if ops[start] == '+' {
			ans = 0
		} else {
			ans = 1
		}

		for c := start; c < end; c++ {
			var num int64
			num = 0
			for r := 0; r < len(nums); r++ {
				if nums[r][c] != ' ' {
					num = num*10 + int64(nums[r][c]-'0')
				}
			}
			if ops[start] == '+' {
				ans += num
			} else {
				ans *= num
			}
		}
		total += ans
		start = end + 1
		end += 2
	}
	return total
}

func readInput() ([][]int64, []string) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([][]string, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		splits := strings.Split(str, " ")
		line := make([]string, 0)
		for _, s := range splits {
			if s != "" {
				line = append(line, s)
			}
		}
		a = append(a, line)
	}

	ints := make([][]int64, 0)
	for i := 0; i < len(a)-1; i++ {
		line := make([]int64, 0)
		for j := 0; j < len(a[i]); j++ {
			n, err := strconv.ParseInt(a[i][j], 10, 64)
			if err != nil {
				panic(err)
			}
			line = append(line, n)
		}
		ints = append(ints, line)
	}

	return ints, a[len(a)-1]
}

func readInput2() ([]string, string) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	a := make([]string, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		a = append(a, scanner.Text())
	}

	div := len(a) - 1
	return a[:div], a[div]
}
