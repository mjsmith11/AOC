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
	fmt.Println("Part 2:", part2_pm())
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

func part2_2() int64 {
	pts, edges := readInput2()
	// _, b := readInput2flood()
	// for _, line := range b {
	// 	for _, myb := range line {
	// 		if myb {
	// 			fmt.Print("#")
	// 		} else {
	// 			fmt.Print(".")
	// 		}
	// 	}
	// 	fmt.Println()
	// }
	max := int64(0)
	for i := 0; i < len(pts); i++ {
		for j := i + 1; j < len(pts); j++ {
			fmt.Println(pts[i], pts[j])
			l := Abs(pts[i].x-pts[j].x) + 1
			w := Abs(pts[i].y-pts[j].y) + 1
			a := l * w
			if a < 0 {
				a *= -1
			}
			if a > max {
				good := true
				for k := 0; k < len(edges); k++ {
					var minX, maxX, minY, maxY int64
					if pts[i].x > pts[j].x {
						maxX = pts[i].x
						minX = pts[j].x
					} else {
						minX = pts[i].x
						maxX = pts[j].x
					}
					if pts[i].y > pts[j].y {
						maxY = pts[i].y
						minY = pts[j].y
					} else {
						minY = pts[i].y
						maxY = pts[j].y
					}
					p1 := point{
						x: minX,
						y: minY,
					}
					p2 := point{
						x: maxX,
						y: maxY,
					}
					if intersect(p1, p2, edges[k]) {
						good = false
						break
					}
					// p1 := pts[i]
					// p2 := point{
					// 	x: pts[j].x,
					// 	y: pts[i].y,
					// }
					// p3 := pts[j]
					// p4 := point{
					// 	x: pts[i].x,
					// 	y: pts[j].y,
					// }
					// if edges[k].intersects(edge{
					// 	p1: &p1,
					// 	p2: &p2,
					// }) {
					// 	good = false
					// 	break
					// }
					// if edges[k].intersects(edge{
					// 	p1: &p2,
					// 	p2: &p3,
					// }) {
					// 	good = false
					// 	break
					// }
					// if edges[k].intersects(edge{
					// 	p1: &p3,
					// 	p2: &p4,
					// }) {
					// 	good = false
					// 	break
					// }
					// if edges[k].intersects(edge{
					// 	p1: &p4,
					// 	p2: &p1,
					// }) {
					// 	good = false
					// 	break
					// }
				}
				if good {
					fmt.Println("  new max", a, pts[i], pts[j])
					max = a
				}
			}
		}
	}
	fmt.Println(len(pts), len(edges))
	return max
}

func part2() int64 {
	pts, b := readInput2flood()
	// for _, line := range b {
	// 	for _, myb := range line {
	// 		fmt.Print(string(myb))
	// 	}
	// 	fmt.Println()
	// }
	count := 0
	max := int64(0)
	for i := 0; i < len(pts); i++ {
		for j := i + 1; j < len(pts); j++ {
			fmt.Println("Rectangle number", count)
			l := pts[i].x - pts[j].x + 1
			w := pts[i].y - pts[j].y + 1
			a := l * w
			if a < 0 {
				a *= -1
			}
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
					for x := minx; x < maxx; x++ {
						if b[y][x] == 'x' {
							good = false
							break
						}
					}
				}
				if good {
					fmt.Println("new max", pts[i], pts[j])
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
		fmt.Println(str)
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

type edge struct {
	p1 *point
	p2 *point
}

func (e *edge) findYMinMax() (int64, int64) {
	if e.p1.y < e.p2.y {
		return e.p1.y, e.p2.y
	} else {
		return e.p2.y, e.p1.y
	}
}

func (e *edge) findXMinMax() (int64, int64) {
	if e.p1.x < e.p2.x {
		return e.p1.x, e.p2.x
	} else {
		return e.p2.x, e.p1.x
	}
}

func intersect(rectA, rectB point, boundary edge) bool {
	if boundary.p1.x == boundary.p2.x {
		if rectA.x == boundary.p1.x && ((rectA.y < boundary.p1.y && boundary.p1.y < rectB.y) || (rectA.y < boundary.p2.y && boundary.p2.y < rectB.y)) {
			fmt.Println("true1")
			return true
		}
		if rectB.x == boundary.p1.x && ((rectA.y < boundary.p1.y && boundary.p1.y < rectB.y) || (rectA.y < boundary.p2.y && boundary.p2.y < rectB.y)) {
			fmt.Println("true2")
			return true
		}
		if rectA.x < boundary.p1.x && boundary.p1.x < rectB.x && boundary.p1.y < rectA.y && rectA.y < boundary.p2.y {
			fmt.Println("true3")
			return true
		}
		if rectA.x < boundary.p1.x && boundary.p1.x < rectB.x && boundary.p1.y < rectB.y && rectB.y < boundary.p2.y {
			fmt.Println("true4")
			return true
		}
	}
	if boundary.p1.y == boundary.p2.y {
		if rectA.y == boundary.p1.y && ((rectA.x < boundary.p1.x && boundary.p1.x < rectB.x) || (rectA.x < boundary.p2.x && boundary.p2.x < rectB.x)) {
			fmt.Println("true5")
			return true
		}
		if rectB.y == boundary.p1.y && ((rectA.x < boundary.p1.x && boundary.p1.x < rectB.x) || (rectA.x < boundary.p2.x && boundary.p2.x < rectB.x)) {
			fmt.Println("true6")
			return true
		}
		if rectA.y < boundary.p1.y && boundary.p1.y < rectB.y && boundary.p1.x < rectA.x && rectA.x < boundary.p2.x {
			fmt.Println("true7")
			return true
		}
		if rectA.y < boundary.p1.y && boundary.p1.y < rectB.y && boundary.p1.x < rectB.x && rectB.x < boundary.p2.x {
			fmt.Println("true8")
			return true
		}
	}
	fmt.Println("false")
	return false
}
func (e1 *edge) intersects(e2 edge) bool {
	// both horizontal
	if e1.p1.y == e1.p2.y && e2.p1.y == e2.p2.y && e1.p1.y == e2.p2.y {
		minX1, maxX1 := e1.findXMinMax()
		minX2, maxX2 := e2.findXMinMax()
		if minX2 > minX1 && minX2 < maxX1 {
			fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|1")
			return true
		}
		if minX1 > minX2 && minX1 < maxX2 {
			fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|2")
			return true
		}
	}
	// both vertical
	if e1.p1.x == e1.p2.x && e2.p1.x == e2.p2.x && e1.p1.x == e2.p2.x {
		minY1, maxY1 := e1.findYMinMax()
		minY2, maxY2 := e2.findYMinMax()
		if minY2 > minY1 && minY2 < maxY1 {
			fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|3")
			return true
		}
		if minY1 > minY2 && minY1 < maxY2 {
			fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|4")
			return true
		}
	}
	//1 vertical and 2 horizontal
	if e1.p1.x == e1.p2.x && e2.p1.y == e2.p2.y {
		xmin, xmax := e2.findXMinMax()
		if xmin < e1.p1.x && xmax > e1.p1.x {
			ymin, ymax := e1.findYMinMax()
			if ymin < e2.p1.y && ymax > e2.p1.y {
				fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|5")
				return true
			}
		}
	}

	//2 vertical and 1 horizontal
	if e2.p1.x == e2.p2.x && e1.p1.y == e1.p2.y {
		xmin, xmax := e1.findXMinMax()
		if xmin < e2.p1.x && xmax > e2.p1.x {
			ymin, ymax := e2.findYMinMax()
			if ymin < e1.p1.y && ymax > e1.p1.y {
				fmt.Println(e1.p1, e1.p2, e2.p1, e2.p2, "|6")
				return true
			}
		}
	}
	return false
}

func readInput2() ([]point, []edge) {
	points := readInput()
	edges := make([]edge, 0)
	for i := 0; i < len(points)-1; i++ {
		edges = append(edges, edge{
			p1: &points[i],
			p2: &points[i+1],
		})
	}
	edges = append(edges, edge{
		p1: &points[len(points)-2],
		p2: &points[0],
	})
	return points, edges
}

func readInput2flood() ([]point, [][]rune) {
	size := 100000
	//97803,50388
	filFrom := point{
		x: 0,
		y: 0,
	}
	pts := readInput()
	b := make([][]rune, size)
	for i := 0; i < size; i++ {
		b[i] = make([]rune, size)
	}
	for i := 0; i < len(pts); i++ {
		next := i + 1
		if next == len(pts) {
			next = 0
		}
		if pts[i].x == pts[next].x {
			var min, max int64
			if pts[i].y < pts[next].y {
				min = pts[i].y
				max = pts[next].y
			} else {
				min = pts[next].y
				max = pts[i].y
			}

			for y := min; y <= max; y++ {
				b[y][pts[i].x] = '#'
			}
		} else {
			var min, max int64
			if pts[i].x < pts[next].x {
				min = pts[i].x
				max = pts[next].x
			} else {
				min = pts[next].x
				max = pts[i].x
			}

			for x := min; x <= max; x++ {
				b[pts[i].y][x] = '#'
			}
		}

	}
	q := make([]point, 0)
	q = append(q, filFrom)
	for len(q) > 0 {
		fmt.Println(len(q))
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

	return pts, b

}

func Abs(n int64) int64 {
	if n < 0 {
		return -1 * n
	}
	return n
}

// 2229569738
// 2229483916 too high
// 4506541577 too high
// 1639143228
// 1543501936
// ---
func readInput2_pm() (map[int64]int, map[int64]int, []point, [][]rune) {
	size := 500
	filFrom := point{
		x: 0,
		y: 0,
	}
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
	q := make([]point, 0)
	q = append(q, filFrom)
	for len(q) > 0 {
		fmt.Println(len(q))
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

	compToRealX := make(map[int64]int, 0)
	compToRealY := make(map[int64]int, 0)

	for k, v := range realToCompX {
		compToRealX[int64(v)] = int(k)
	}
	for k, v := range realToCompY {
		compToRealY[int64(v)] = int(k)
	}
	compPts := make([]point, len(pts))
	for i, p := range pts {
		compPts[i] = point{
			x: int64(realToCompX[p.x]),
			y: int64(realToCompY[p.y]),
		}
	}
	return compToRealX, compToRealY, compPts, b
}

func part2_pm() int64 {
	xMap, yMap, pts, b := readInput2_pm()
	for _, line := range b {
		for _, myb := range line {
			fmt.Print(string(myb))
			if myb == 0 {
				fmt.Print(".")
			}
		}
		fmt.Println()
	}
	count := 0
	max := int64(0)
	for i := 0; i < len(pts); i++ {
		for j := i + 1; j < len(pts); j++ {
			//fmt.Println("Rectangle number", count)
			//fmt.Println("  ", pts[i], pts[j])
			l := Abs(int64(xMap[pts[i].x]-xMap[pts[j].x])) + 1
			w := Abs(int64(yMap[pts[i].y]-yMap[pts[j].y])) + 1
			a := l * w
			//fmt.Println("  ", a)
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
					fmt.Println("new max", pts[i], pts[j])
					max = a
				}
			}
			count++
		}
	}
	return max
}
