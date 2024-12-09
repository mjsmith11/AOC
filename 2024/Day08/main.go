package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

type point struct {
	x int
	y int
}

func (p *point) String() string {
	return fmt.Sprintf("%v,%v", p.x, p.y)
}

func part1() int {
	grid := readInput()
	lenX := len(grid[0])
	lenY := len(grid)
	antenna := make(map[rune][]point, 0)
	antinodes := make(map[string]bool, 0)
	for y, s := range grid {
		for x, r := range s {
			if r != '.' {
				antenna[r] = append(antenna[r], point{x, y})
			}
		}
	}
	for _, v := range antenna {
		for a1i := 0; a1i < len(v); a1i++ {
			for a2i := a1i + 1; a2i < len(v); a2i++ {
				a1 := v[a1i]      // 0,0
				a2 := v[a2i]      // 1,1
				dx := a1.x - a2.x // -1
				dy := a1.y - a2.y // -1

				newX := a1.x + dx
				newY := a1.y + dy
				if newX >= 0 && newY >= 0 && newX < lenX && newY < lenY {
					newP := point{newX, newY}
					antinodes[newP.String()] = true
				}

				newX = a2.x - dx
				newY = a2.y - dy
				if newX >= 0 && newY >= 0 && newX < lenX && newY < lenY {
					newP := point{newX, newY}
					antinodes[newP.String()] = true
				}
			}
		}
	}
	return len(antinodes)
}

func part2() int {
	grid := readInput()
	lenX := len(grid[0])
	lenY := len(grid)
	antenna := make(map[rune][]point, 0)
	antinodes := make(map[string]bool, 0)
	for y, s := range grid {
		for x, r := range s {
			if r != '.' {
				antenna[r] = append(antenna[r], point{x, y})
			}
		}
	}
	for _, v := range antenna {
		for a1i := 0; a1i < len(v); a1i++ {
			for a2i := a1i + 1; a2i < len(v); a2i++ {
				a1 := v[a1i] // 0,0
				a2 := v[a2i] // 1,1
				antinodes[a1.String()] = true
				antinodes[a2.String()] = true
				dx := a1.x - a2.x // -1
				dy := a1.y - a2.y // -1

				newX := a1.x + dx
				newY := a1.y + dy
				for newX >= 0 && newY >= 0 && newX < lenX && newY < lenY {
					newP := point{newX, newY}
					antinodes[newP.String()] = true
					newX += dx
					newY += dy
				}

				newX = a2.x - dx
				newY = a2.y - dy
				for newX >= 0 && newY >= 0 && newX < lenX && newY < lenY {
					newP := point{newX, newY}
					antinodes[newP.String()] = true
					newX -= dx
					newY -= dy
				}
			}
		}
	}
	return len(antinodes)
}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()
	strs := make([]string, 0)
	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		strs = append(strs, scanner.Text())
	}
	return strs
}
