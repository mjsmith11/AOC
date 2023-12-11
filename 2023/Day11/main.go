package main

import (
	"bufio"
	"fmt"
	"math"
	"os"
)

func main() {
	fmt.Println("Part 1", run(1))
	fmt.Println("Part 2", run(999999))
	// 634325539488 high
}

func run(expSize int64) int64 {
	inp := readInput()
	galaxies := make([]point, 0)
	doubleCols := make(map[int]int, 0)
	doubleRows := make(map[int]int, 0)

	ySize := len(inp)
	xSize := len(inp[0])

	for y, l := range inp {
		emptyRow := true
		for x, c := range l {
			if c == '#' {
				emptyRow = false
				galaxies = append(galaxies, point{
					x: x,
					y: y,
				})
			}
		}
		if emptyRow {
			doubleRows[y] = 0
		}
	}
	for x := 0; x < xSize; x++ {
		emptyCol := true
		for y := 0; y < ySize; y++ {
			if inp[y][x] == '#' {
				emptyCol = false
			}
		}
		if emptyCol {
			doubleCols[x] = 0
		}
	}
	totalDist := int64(0)

	for i, p1 := range galaxies {
		for j := i + 1; j < len(galaxies); j++ {
			p2 := galaxies[j]
			manhattan := math.Abs(float64(p1.x-p2.x)) + math.Abs(float64(p1.y-p2.y))
			totalDist += int64(manhattan)
			var bigX, littleX, bigY, littleY int
			if p1.x < p2.x {
				littleX = p1.x
				bigX = p2.x
			} else {
				littleX = p2.x
				bigX = p1.x
			}
			if p1.y < p2.y {
				littleY = p1.y
				bigY = p2.y
			} else {
				littleY = p2.y
				bigY = p1.y
			}
			for x := littleX; x < bigX; x++ {
				if _, ok := doubleCols[x]; ok {
					totalDist += expSize
				}
			}
			for y := littleY; y < bigY; y++ {
				if _, ok := doubleRows[y]; ok {
					totalDist += expSize
				}
			}
		}
	}

	return totalDist

}

func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	strs := make([]string, 0)
	for scanner.Scan() {
		strs = append(strs, scanner.Text())
	}
	return strs
}

type point struct {
	x int
	y int
}
