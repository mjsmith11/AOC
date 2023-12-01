package main

import (
	"bufio"
	"fmt"
	"os"
	"unicode"
)

func main() {
	fmt.Println("Part 1: ", run(getValue1))
	fmt.Println("Part 2: ", run(getValue2))
}

func run(getValueFunc func(string) int) int {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	scanner := bufio.NewScanner(f)
	total := 0
	for scanner.Scan() {
		total += getValueFunc(scanner.Text())
	}
	return total
}

func getValue1(s string) int {
	list := make([]rune, 0)
	for _, c := range s {
		if unicode.IsDigit(c) {
			list = append(list, c)
		}
	}
	return 10*(int(list[0])-'0') + (int(list[len(list)-1] - '0'))
}

func getValue2(s string) int {
	first := findFirst(s)
	last := findLast(s)
	return last + 10*first
}

func reverse(s string) string {
	rns := []rune(s)
	for i, j := 0, len(rns)-1; i < j; i, j = i+1, j-1 {
		rns[i], rns[j] = rns[j], rns[i]
	}
	return string(rns)
}

func findFirst(s string) int {
	for i, c := range s {
		if unicode.IsDigit(c) {
			return int(c) - '0'
		}
		if i+3 <= len(s) && s[i:i+3] == "one" {
			return 1
		}
		if i+3 <= len(s) && s[i:i+3] == "two" {
			return 2
		}
		if i+5 <= len(s) && s[i:i+5] == "three" {
			return 3
		}
		if i+4 <= len(s) && s[i:i+4] == "four" {
			return 4
		}
		if i+4 <= len(s) && s[i:i+4] == "five" {
			return 5
		}
		if i+3 <= len(s) && s[i:i+3] == "six" {
			return 6
		}
		if i+5 <= len(s) && s[i:i+5] == "seven" {
			return 7
		}
		if i+5 <= len(s) && s[i:i+5] == "eight" {
			return 8
		}
		if i+4 <= len(s) && s[i:i+4] == "nine" {
			return 9
		}
	}
	return -1
}

func findLast(s string) int {
	s = reverse(s)
	for i, c := range s {
		if unicode.IsDigit(c) {
			return int(c) - '0'
		}
		if i+3 <= len(s) && s[i:i+3] == "eno" {
			return 1
		}
		if i+3 <= len(s) && s[i:i+3] == "owt" {
			return 2
		}
		if i+5 <= len(s) && s[i:i+5] == "eerht" {
			return 3
		}
		if i+4 <= len(s) && s[i:i+4] == "ruof" {
			return 4
		}
		if i+4 <= len(s) && s[i:i+4] == "evif" {
			return 5
		}
		if i+3 <= len(s) && s[i:i+3] == "xis" {
			return 6
		}
		if i+5 <= len(s) && s[i:i+5] == "neves" {
			return 7
		}
		if i+5 <= len(s) && s[i:i+5] == "thgie" {
			return 8
		}
		if i+4 <= len(s) && s[i:i+4] == "enin" {
			return 9
		}
	}
	return -1
}
