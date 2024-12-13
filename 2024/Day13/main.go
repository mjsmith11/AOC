package main

import (
	"bufio"
	"fmt"
	"os"
	"regexp"
	"strconv"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part1() int {
	cost := 0
	games := readInput()
	for _, g := range games {
		cost += g.calculateCost()
	}
	return cost
}

func part2() int {
	cost := 0
	games := readInput()
	for _, g := range games {
		cost += g.calculateCost2()
	}
	return cost
}

type orderedPair struct {
	x int
	y int
}

type game struct {
	prize  orderedPair
	deltaA orderedPair
	deltaB orderedPair
}

func (g game) calculateCost2() int {
	newGame := game{
		deltaA: g.deltaA,
		deltaB: g.deltaB,
		prize: orderedPair{
			x: g.prize.x + 10000000000000,
			y: g.prize.y + 10000000000000,
		},
	}
	return newGame.calculateCost()
}
func (g game) calculateCost() int {
	// prize.x = A * deltaA.x + B * deltaB.x
	// prize.y = A * deltaA.y + B * deltaB.y
	// cost = 3A + B
	// matrix layout
	// a  b
	// c  d

	// make coefficient matrix
	sMA := float64(g.deltaA.x)
	sMB := float64(g.deltaB.x)
	sMC := float64(g.deltaA.y)
	sMD := float64(g.deltaB.y)

	// invert coefficient matrix
	div := float64(sMA*sMD - sMB*sMC)
	invA := sMD / div
	invB := -1 * sMB / div
	invC := -1 * sMC / div
	invD := sMA / div

	// matrix multiplication rhs matrix
	a := int(invA*float64(g.prize.x) + invB*float64(g.prize.y) + .1) // add the .1 for fun floating point precision problems
	b := int(invC*float64(g.prize.x) + invD*float64(g.prize.y) + .1)

	// check that it's exact and we didn't truncate a decimal part
	if g.prize.x == a*g.deltaA.x+b*g.deltaB.x {
		if g.prize.y == a*g.deltaA.y+b*g.deltaB.y {
			return 3*a + b
		}
	}
	return 0
}

func readInput() []game {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	buttonRe := regexp.MustCompile("^Button [AB]: X\\+(?P<x>\\d+), Y\\+(?P<y>\\d+)$")
	prizeRe := regexp.MustCompile("^Prize: X=(?P<x>\\d+), Y=(?P<y>\\d+)$")
	defer f.Close()
	scanner := bufio.NewScanner(f)
	games := make([]game, 0)
	for scanner.Scan() {
		rawA := scanner.Text()
		scanner.Scan()
		rawB := scanner.Text()
		scanner.Scan()
		rawPrize := scanner.Text()
		scanner.Scan() // eat the empty line

		parsedA := buttonRe.FindStringSubmatch(rawA)
		parsedB := buttonRe.FindStringSubmatch(rawB)
		parsedPrize := prizeRe.FindStringSubmatch(rawPrize)

		ax, err := strconv.Atoi(parsedA[1])
		if err != nil {
			panic(err)
		}
		ay, err := strconv.Atoi(parsedA[2])
		if err != nil {
			panic(err)
		}

		bx, err := strconv.Atoi(parsedB[1])
		if err != nil {
			panic(err)
		}
		by, err := strconv.Atoi(parsedB[2])
		if err != nil {
			panic(err)
		}

		px, err := strconv.Atoi(parsedPrize[1])
		if err != nil {
			panic(err)
		}
		py, err := strconv.Atoi(parsedPrize[2])
		if err != nil {
			panic(err)
		}
		games = append(games, game{
			deltaA: orderedPair{
				x: ax,
				y: ay,
			},
			deltaB: orderedPair{
				x: bx,
				y: by,
			},
			prize: orderedPair{
				x: px,
				y: py,
			},
		})
	}
	return games
}
