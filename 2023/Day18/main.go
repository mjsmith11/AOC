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
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}
func part1() int {
	instructions := readInput()
	poly := newPolygon()
	poly.addPoint(point{
		x: 0,
		y: 0,
	})
	curX, curY := 0, 0
	for _, s := range instructions {
		splits := strings.Split(s, " ")
		dir := splits[0]
		amt, err := strconv.Atoi(splits[1])
		if err != nil {
			panic(err)
		}
		if dir == "U" {
			curY -= amt
		} else if dir == "D" {
			curY += amt
		} else if dir == "L" {
			curX -= amt
		} else if dir == "R" {
			curX += amt
		} else {
			panic(dir)
		}
		poly.addPoint(point{
			x: curX,
			y: curY,
		})
	}
	return poly.showlaceArea() + poly.perim()/2 + 1
}

func part2() int {
	instructions := readInput()
	poly := newPolygon()
	poly.addPoint(point{
		x: 0,
		y: 0,
	})
	curX, curY := 0, 0
	for _, s := range instructions {
		splits := strings.Split(s, "(#")
		hexStr := splits[1][0:5]
		dir := splits[1][5:6]
		amt64, err := strconv.ParseInt(hexStr, 16, 32)
		if err != nil {
			panic(err)
		}
		amt := int(amt64)
		if dir == "3" {
			curY -= amt
		} else if dir == "1" {
			curY += amt
		} else if dir == "2" {
			curX -= amt
		} else if dir == "0" {
			curX += amt
		} else {
			panic(dir)
		}
		poly.addPoint(point{
			x: curX,
			y: curY,
		})
	}
	return poly.showlaceArea() + poly.perim()/2 + 1
}

// func part1() int {
// 	width := 718
// 	height := 718

// 	grid := make([][]rune, 0)
// 	for y := 0; y < height; y++ {
// 		row := make([]rune, 0)
// 		for x := 0; x < width; x++ {
// 			row = append(row, '.')
// 		}
// 		grid = append(grid, row)
// 	}

// 	curX := 300
// 	curY := 300
// 	grid[curY][curX] = '#'
// 	instructions := readInput()
// 	for _, s := range instructions {
// 		splits := strings.Split(s, " ")
// 		dir := splits[0]
// 		amt, err := strconv.Atoi(splits[1])
// 		if err != nil {
// 			panic(err)
// 		}
// 		for i := 0; i < amt; i++ {
// 			if dir == "U" {
// 				curY--
// 			} else if dir == "D" {
// 				curY++
// 			} else if dir == "L" {
// 				curX--
// 			} else if dir == "R" {
// 				curX++
// 			} else {
// 				panic(dir)
// 			}
// 			grid[curY][curX] = '#'
// 		}
// 	}

// 	// flood
// 	flood(grid, 300, 299)
// 	v := 0
// 	for y := 0; y < height; y++ {
// 		for x := 0; x < width; x++ {
// 			if grid[y][x] == '#' {
// 				v++
// 			}
// 			if x == 300 && y == 300 {
// 				fmt.Print("S")
// 			} else {
// 				fmt.Print(string(grid[y][x]))
// 			}
// 		}
// 		fmt.Println()
// 	}

//		return v
//	}
//
//	func flood(grid [][]rune, x, y int) {
//		if grid[y][x] == '.' {
//			grid[y][x] = '#'
//			flood(grid, x-1, y)
//			flood(grid, x+1, y)
//			flood(grid, x, y+1)
//			flood(grid, x, y-1)
//		}
//	}
func readInput() []string {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	data := make([]string, 0)
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		data = append(data, scanner.Text())
	}

	return data
}

type point struct {
	x int
	y int
}

type polygon struct {
	points []point
}

func newPolygon() *polygon {
	return &polygon{
		points: make([]point, 0),
	}
}

func (p *polygon) addPoint(pt point) {
	p.points = append(p.points, pt)
}

func (p *polygon) showlaceArea() int {
	plusSum := 0
	minusSum := 0
	for i := 0; i < len(p.points)-1; i++ {
		plusSum += (p.points[i].x * p.points[i+1].y)
		minusSum += (p.points[i].y * p.points[i+1].x)
	}
	plusSum += (p.points[len(p.points)-1].x * p.points[0].y)
	minusSum += (p.points[len(p.points)-1].y * p.points[0].x)
	return int(math.Abs(float64(plusSum)-float64(minusSum))) / 2
}

func (p *polygon) perim() int {
	perim := 0
	for i := 0; i < len(p.points)-1; i++ {
		perim += dist(p.points[i], p.points[i+1])
	}
	perim += dist(p.points[0], p.points[len(p.points)-1])
	return perim
}

func dist(p1, p2 point) int {
	return int(math.Sqrt(math.Pow(float64(p1.x-p2.x), 2) + math.Pow(float64(p1.y-p2.y), 2)))
}
