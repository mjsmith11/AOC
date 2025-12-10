package main

import (
	"bufio"
	"fmt"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

type point struct {
	x int64
	y int64
}

func part1() int64 {
	pts := readInput()
	max := int64(0)
	for i := 0; i < len(pts); i++ {
		for j := i + 1; j < len(pts); j++ {
			l := Abs(pts[i].x-pts[j].x) + 1
			w := Abs(pts[i].y-pts[j].y) + 1
			a := l * w
			if a < 0 {
				a *= -1
			}
			if a > max {
				max = a
			}
		}
	}
	return max
}

func part2() int64 {
	xMap, yMap, pts, b := readInput2()
	count := 0
	max := int64(0)
	for i := 0; i < len(pts); i++ {
		for j := i + 1; j < len(pts); j++ {
			// area must be computed with decompressed coordinates
			// checks to see if it's inside the required polygon can be done with compressed coords
			l := Abs(int64(xMap[pts[i].x]-xMap[pts[j].x])) + 1
			w := Abs(int64(yMap[pts[i].y]-yMap[pts[j].y])) + 1
			a := l * w
			if a > max {
				var minx, maxx, miny, maxy int64
				if pts[i].x > pts[j].x {
					maxx = pts[i].x
					minx = pts[j].x
				} else {
					maxx = pts[j].x
					minx = pts[i].x
				}
				if pts[i].y > pts[j].y {
					maxy = pts[i].y
					miny = pts[j].y
				} else {
					maxy = pts[j].y
					miny = pts[i].y
				}
				good := true
				for y := miny; y <= maxy; y++ {
					if !good {
						break
					}
					for x := minx; x <= maxx; x++ {
						if b[y][x] == 'x' {
							good = false
							break
						}
					}
				}
				if good {
					max = a
				}
			}
			count++
		}
	}
	return max
}
func readInput() []point {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	nodes := make([]point, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		splits := strings.Split(str, ",")
		x, err := strconv.ParseInt(splits[0], 10, 64)
		if err != nil {
			panic(err)
		}
		y, err := strconv.ParseInt(splits[1], 10, 64)
		if err != nil {
			panic(err)
		}
		nodes = append(nodes, point{
			x: x,
			y: y,
		})
	}

	return nodes
}

func Abs(n int64) int64 {
	if n < 0 {
		return -1 * n
	}
	return n
}

func readInput2() (map[int64]int, map[int64]int, []point, [][]rune) {
	size := 500
	filFrom := point{
		x: 0,
		y: 0,
	}

	// setting up a compression scheme where the smallest x coord maps to 1, next x coord maps to 2 and so on.  Y is done similarly
	xCoords := make([]int64, 0)
	yCoords := make([]int64, 0)
	pts := readInput()
	for _, p := range pts {
		xCoords = append(xCoords, p.x)
		yCoords = append(yCoords, p.y)
	}
	sort.Slice(xCoords, func(i, j int) bool {
		return xCoords[i] < xCoords[j]
	})
	sort.Slice(yCoords, func(i, j int) bool {
		return yCoords[i] < yCoords[j]
	})

	realToCompX := make(map[int64]int, 0)
	realToCompY := make(map[int64]int, 0)
	compX := 1
	compY := 1
	for _, x := range xCoords {
		if _, ok := realToCompX[x]; !ok {
			realToCompX[x] = compX
			compX++
		}
	}
	for _, y := range yCoords {
		if _, ok := realToCompY[y]; !ok {
			realToCompY[y] = compY
			compY++
		}
	}
	// create a map of the peremeter using compressed coords
	b := make([][]rune, size)
	for i := 0; i < size; i++ {
		b[i] = make([]rune, size)
	}
	for i := 0; i < len(pts); i++ {
		next := i + 1
		if next == len(pts) {
			next = 0
		}
		compI := point{
			x: int64(realToCompX[pts[i].x]),
			y: int64(realToCompY[pts[i].y]),
		}
		compNext := point{
			x: int64(realToCompX[pts[next].x]),
			y: int64(realToCompY[pts[next].y]),
		}
		if compI.x == compNext.x {
			var min, max int64
			if compI.y < compNext.y {
				min = compI.y
				max = compNext.y
			} else {
				min = compNext.y
				max = compI.y
			}

			for y := min; y <= max; y++ {
				b[y][compI.x] = '#'
			}
		} else {
			var min, max int64
			if compI.x < compNext.x {
				min = compI.x
				max = compNext.x
			} else {
				min = compNext.x
				max = compI.x
			}

			for x := min; x <= max; x++ {
				b[compI.y][x] = '#'
			}
		}

	}

	// flood fill outside of red and green with 'x'
	q := make([]point, 0)
	q = append(q, filFrom)
	for len(q) > 0 {
		pt := q[0]
		q = q[1:]
		if pt.x < 0 {
			continue
		}
		if pt.y < 0 {
			continue
		}
		if pt.x >= int64(size) {
			continue
		}
		if pt.y >= int64(size) {
			continue
		}
		if b[pt.y][pt.x] != 'x' && b[pt.y][pt.x] != '#' {
			b[pt.y][pt.x] = 'x'
			q = append(q, point{
				x: pt.x + 1,
				y: pt.y,
			})
			q = append(q, point{
				x: pt.x - 1,
				y: pt.y,
			})
			q = append(q, point{
				x: pt.x,
				y: pt.y + 1,
			})
			q = append(q, point{
				x: pt.x,
				y: pt.y - 1,
			})
		}
	}

	// create decompression maps
	compToRealX := make(map[int64]int, 0)
	compToRealY := make(map[int64]int, 0)

	for k, v := range realToCompX {
		compToRealX[int64(v)] = int(k)
	}
	for k, v := range realToCompY {
		compToRealY[int64(v)] = int(k)
	}
	// compress the list of points
	compPts := make([]point, len(pts))
	for i, p := range pts {
		compPts[i] = point{
			x: int64(realToCompX[p.x]),
			y: int64(realToCompY[p.y]),
		}
	}
	return compToRealX, compToRealY, compPts, b
}
