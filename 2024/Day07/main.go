package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int64 {
	eqns := readInput()
	total := int64(0)
	for _, e := range eqns {
		if e.IsPossible1() {
			total += e.target
		}
	}
	return total
}

func part2() int64 {
	eqns := readInput()
	total := int64(0)
	for _, e := range eqns {
		if e.IsPossible2(make([]string, 0)) {
			total += e.target
		}
	}
	return total
}

type equation struct {
	target int64
	nums   []int64
}

func equationFromString(s string) equation {
	parts1 := strings.Split(s, ": ")
	target, err := strconv.ParseInt(parts1[0], 10, 64)
	if err != nil {
		panic(err)
	}
	parts2 := strings.Split(parts1[1], " ")
	nums := make([]int64, 0)
	for _, n := range parts2 {
		ni, err := strconv.ParseInt(n, 10, 64)
		if err != nil {
			panic(err)
		}
		nums = append(nums, ni)
	}
	return equation{
		target: target,
		nums:   nums,
	}
}

func (e *equation) IsPossible1() bool {
	possibilities := int(math.Pow(2, float64(len(e.nums)-1)))
	for iter := 0; iter < possibilities; iter++ {
		res := e.nums[0]
		for i := 1; i < len(e.nums); i++ {
			if isBitSet(iter, i-1) {
				res += e.nums[i]
			} else {
				res *= e.nums[i]
			}
		}
		if res == e.target {
			return true
		}
	}
	return false
}

func (e *equation) IsPossible2(ops []string) bool {
	if len(ops) == len(e.nums)-1 {
		return e.eval(ops) == e.target
	}
	ops = append(ops, "+")
	if e.IsPossible2(ops) {
		return true
	}
	ops[len(ops)-1] = "*"
	if e.IsPossible2(ops) {
		return true
	}
	ops[len(ops)-1] = "||"
	return e.IsPossible2(ops)
}

func (e *equation) eval(ops []string) int64 {
	res := e.nums[0]
	for i := 1; i < len(e.nums); i++ {
		if ops[i-1] == "+" {
			res += e.nums[i]
		} else if ops[i-1] == "*" {
			res *= e.nums[i]
		} else if ops[i-1] == "||" {
			res = concat(res, e.nums[i])
		} else {
			panic(ops[i-1])
		}
	}
	return res
}

func concat(a, b int64) int64 {
	ns := fmt.Sprintf("%v%v", a, b)
	n, err := strconv.ParseInt(ns, 10, 64)
	if err != nil {
		panic(err)
	}
	return n
}

func isBitSet(n int, bitNum int) bool {
	mask := 1 << bitNum
	return (n & mask) > 0
}

func readInput() []equation {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	inp := make([]equation, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		inp = append(inp, equationFromString(scanner.Text()))
	}
	return inp
}
