package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

var (
	wires map[string]bool
	gates map[string]operation
)

func main() {
	fmt.Println("Part 1:", part1())
	part2()
}

// will currently be wrong. Input is fixed so the adder works
func part1() int {
	wires, gates = readInput()
	for k, _ := range gates {
		if k[0] == 'z' {
			eval(k)
		}
	}
	res := 0
	for k, v := range wires {
		if k[0] == 'z' && v {
			numeric, err := strconv.Atoi(k[1:])
			if err != nil {
				panic(err)
			}
			res = res | (1 << numeric)
		}
	}
	return res
}

func part2() {
	part1()
	x := getInt('x')
	y := getInt('y')
	expectedZ := x + y
	z := getInt('z')
	fmt.Println(x, y, expectedZ, z)
	fmt.Println(expectedZ ^ z)
}

func getInt(prefix byte) int {
	res := 0
	for k, v := range wires {
		if k[0] == prefix && v {
			numeric, err := strconv.Atoi(k[1:])
			if err != nil {
				panic(err)
			}
			res = res | (1 << numeric)
		}
	}
	return res
}

func eval(w string) bool {
	if v, ok := wires[w]; ok {
		return v
	}
	op := gates[w]
	wA := eval(op.wireA)
	wB := eval(op.wireB)
	if op.gate == "AND" {
		wires[w] = wA && wB
		return wA && wB
	} else if op.gate == "OR" {
		wires[w] = wA || wB
		return wA || wB
	} else if op.gate == "XOR" {
		wires[w] = wA != wB
		return wA != wB
	} else {
		panic(op.gate)
	}

}

type operation struct {
	wireA string
	wireB string
	gate  string
}

func readInput() (map[string]bool, map[string]operation) {
	wires := make(map[string]bool, 0)
	ops := make(map[string]operation)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		if scanner.Text() == "" {
			break
		}
		parts := strings.Split(scanner.Text(), ": ")
		wires[parts[0]] = parts[1] == "1"
	}

	for scanner.Scan() {
		parts1 := strings.Split(scanner.Text(), " -> ")
		parts2 := strings.Split(parts1[0], " ")
		ops[parts1[1]] = operation{
			wireA: parts2[0],
			wireB: parts2[2],
			gate:  parts2[1],
		}
	}
	return wires, ops
}

// LANGUAGE: Kotlin] 1488/612

// I initially solved it manually but then wrote a beautiful and short (11 lines of logic) generic solution.

// Our goal is to have a Ripple Carry Adder. To find the 8 wrong gates in a ripple carry adder circuit, we can break it down into three groups: The first 3 wrong gates can be found by looking at gates that produce a z output. In a correct ripple carry adder, any gate producing z must use an XOR operation. So we identify 3 gates that output z but don't use XOR and also are not gate z45, that one can be a bit different because it's the last gate - these are wrong. For the next 3 wrong gates, we need to understand that in a ripple carry adder, XOR operations should only be used when dealing with inputs and outputs, not for intermediate calculations. We can find 3 gates that use XOR but don't have x, y, or z in their inputs or outputs. Since these gates are using XOR in the wrong place, they are incorrect.

// Now we have 6 gates, but we don't know which ones to swap, to find the correct pairings, we want the number behind the first z-output in the recursive chain, so we write a recursive function. Say we have a chain of gates like this: a, b -> c where c is the output of one of our non-z XOR gates. Then c, d -> e then e, f -> z09 and we know we want to get to z09. Our recursive function would start with the first gate (a, b -> c), see that its output 'c' is used as input in the next gate, follow this to (c, d -> e), see that its output 'e' is used as input in the z09 gate, and finally reach (e, f -> z09). Now we just swap c and z09 - 1, so we swap c and z08. The -1 is there because this function finds the NEXT z gate, not the current one we need.

// The final 2 wrong gates require comparing the circuit's actual output with what we expect (x+y). When we convert both numbers to binary and compare them, we'll find a section where they differ. If we XOR these two binary numbers, we'll get zeros where the bits match and ones where they differ. Count the number of zeros at the start (LSB) of this XOR result - let's call this number N. The last two wrong gates will be the ones that use inputs xN and yN, swap them.

// https://github.com/eagely/adventofcode/blob/main/src/main/kotlin/solutions/y2024/Day24.kt
