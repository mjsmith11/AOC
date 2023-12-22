package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

const (
	X_SIZE = 10
	Y_SIZE = 10
	Z_SIZE = 370
)

var moved map[int]int

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}

func part2() int {
	masterS, dirs := readInput()
	for drop(masterS, dirs) {
	}
	total := 0
	for k := range dirs {
		moved = make(map[int]int)
		copyS := deepCopy(masterS, k)
		for drop(copyS, dirs) {
		}
		total += len(moved)
	}
	return total
}

func deepCopy(s [][][]int, without int) [][][]int {
	space := make([][][]int, Z_SIZE)
	for z := 0; z < Z_SIZE; z++ {
		space[z] = make([][]int, Y_SIZE)
		for y := 0; y < Y_SIZE; y++ {
			space[z][y] = make([]int, X_SIZE)
		}
	}

	for z := Z_SIZE - 1; z >= 0; z-- {
		for y := 0; y < Y_SIZE; y++ {
			for x := 0; x < X_SIZE; x++ {
				if s[z][y][x] == without {
					space[z][y][x] = 0
				} else {
					space[z][y][x] = s[z][y][x]
				}
			}
		}
	}
	return space
}

func part1() int {
	space, dirs := readInput()
	moved = make(map[int]int, 0)
	for drop(space, dirs) {
	}
	canDis := 0
	for k := range dirs {
		if isStable(space, dirs, k) {
			canDis++
		}
	}
	return canDis
}

func printLayers(s [][][]int) {
	for z := Z_SIZE - 1; z >= 0; z-- {
		for y := 0; y < Y_SIZE; y++ {
			for x := 0; x < X_SIZE; x++ {
				fmt.Print(s[z][y][x])
			}
			fmt.Println()
		}
		fmt.Println()
	}
}
func isStable(s [][][]int, dirs map[int]rune, remove int) bool {
	checked := make(map[int]int, len(dirs))
	for x := 0; x < X_SIZE; x++ {
		for y := 0; y < Y_SIZE; y++ {
			for z := 2; z < Z_SIZE; z++ { // start at 2 because floor is 0 and if its on 1 already, we can't drop
				if s[z][y][x] != 0 && s[z][y][x] != remove {
					if _, done := checked[s[z][y][x]]; !done {
						checked[s[z][y][x]] = 1
						if dirs[s[z][y][x]] == 'z' || dirs[s[z][y][x]] == 's' {
							if !isStableZ(s, x, y, z, remove) {
								return false
							}
						}
						if dirs[s[z][y][x]] == 'x' {
							if !isStableX(s, x, y, z, remove) {
								return false
							}
						}
						if dirs[s[z][y][x]] == 'y' {
							if !isStableY(s, x, y, z, remove) {
								return false
							}
						}
					}
				}
			}
		}
	}
	return true
}
func drop(s [][][]int, dirs map[int]rune) bool {
	checked := make(map[int]int, len(dirs))
	drops := false
	for x := 0; x < X_SIZE; x++ {
		for y := 0; y < Y_SIZE; y++ {
			for z := 2; z < Z_SIZE; z++ { // start at 2 because floor is 0 and if its on 1 already, we can't drop
				if s[z][y][x] != 0 {
					if _, done := checked[s[z][y][x]]; !done {
						checked[s[z][y][x]] = 1
						if dirs[s[z][y][x]] == 'z' || dirs[s[z][y][x]] == 's' {
							drops = drops || dropZ(s, x, y, z)
						}
						if dirs[s[z][y][x]] == 'x' {
							drops = drops || dropX(s, x, y, z)
						}
						if dirs[s[z][y][x]] == 'y' {
							drops = drops || dropY(s, x, y, z)
						}
					}
				}
			}
		}
	}
	return drops
}
func dropX(s [][][]int, x, y, z int) bool {
	// find out how big the brick is
	brickNum := s[z][y][x]
	xMin := x
	xMax := x
	for myX := x; myX < X_SIZE; myX++ {
		if s[z][y][myX] == brickNum {
			xMax = myX
		}
	}
	for myX := x; myX >= 0; myX-- {
		if s[z][y][myX] == brickNum {
			xMin = myX
		}
	}
	// see if i can move down
	newZ := z
	for myZ := z - 1; myZ > 0; myZ-- {
		good := true
		for myX := xMin; myX <= xMax; myX++ {
			if s[myZ][y][myX] != 0 {
				good = false
				break

			}
		}
		if good {
			newZ = myZ
		} else {
			break
		}
	}

	if newZ != z {
		moved[brickNum] = 1
		for myX := xMin; myX <= xMax; myX++ {
			s[z][y][myX] = 0
			s[newZ][y][myX] = brickNum
		}
		return true
	}
	return false
}
func dropY(s [][][]int, x, y, z int) bool {
	// find out how big the brick is
	brickNum := s[z][y][x]
	yMin := y
	yMax := y
	for myY := y; myY < Y_SIZE; myY++ {
		if s[z][myY][x] == brickNum {
			yMax = myY
		}
	}
	for myY := x; myY >= 0; myY-- {
		if s[z][myY][x] == brickNum {
			yMin = myY
		}
	}
	// see if i can move down
	newZ := z
	for myZ := z - 1; myZ > 0; myZ-- {
		good := true
		for myY := yMin; myY <= yMax; myY++ {
			if s[myZ][myY][x] != 0 {
				good = false
				break
			}
		}
		if good {
			newZ = myZ
		} else {
			break
		}
	}
	if newZ != z {
		moved[brickNum] = 1
		for myY := yMin; myY <= yMax; myY++ {
			s[z][myY][x] = 0
			s[newZ][myY][x] = brickNum
		}
		return true
	}
	return false
}
func dropZ(s [][][]int, x, y, z int) bool {
	brickNum := s[z][y][x]
	// find out how big the brick is
	zMin := z
	zMax := z
	for myZ := z; myZ < Z_SIZE; myZ++ {
		if s[myZ][y][x] == brickNum {
			zMax = myZ
		}
	}
	for myZ := z; myZ > 0; myZ-- {
		if s[myZ][y][x] == brickNum {
			zMin = myZ
		}
	}
	// see if i can move down
	newZMin := zMin
	for myZ := zMin - 1; myZ > 0; myZ-- {
		if s[myZ][y][x] == 0 {
			newZMin = myZ
		} else {
			break
		}
	}
	//move
	if newZMin != zMin {
		moved[brickNum] = 1
		newZMax := newZMin + (zMax - zMin)
		for myZ := zMin; myZ <= zMax; myZ++ {
			s[myZ][y][x] = 0
		}
		for myZ := newZMin; myZ <= newZMax; myZ++ {
			s[myZ][y][x] = brickNum
		}
		return true
	}
	return false
}
func isStableX(s [][][]int, x, y, z, blockMissing int) bool {
	// find out how big the brick is
	brickNum := s[z][y][x]
	xMin := x
	xMax := x
	for myX := x; myX < X_SIZE; myX++ {
		if s[z][y][myX] == brickNum {
			xMax = myX
		}
	}
	for myX := x; myX >= 0; myX-- {
		if s[z][y][myX] == brickNum {
			xMin = myX
		}
	}
	// see if i can move down
	newZ := z
	for myZ := z - 1; myZ > 0; myZ-- {
		good := true
		for myX := xMin; myX <= xMax; myX++ {
			if s[myZ][y][myX] != 0 && s[myZ][y][myX] != blockMissing {
				good = false
				break
			}
		}
		if good {
			newZ = myZ
		} else {
			break
		}
	}

	if newZ != z {
		return false
	}
	return true
}

// safe 2,3,4,5,7 unsafe 1,6
func isStableY(s [][][]int, x, y, z, blockMissing int) bool {
	// find out how big the brick is
	brickNum := s[z][y][x]
	yMin := y
	yMax := y
	for myY := y; myY < Y_SIZE; myY++ {
		if s[z][myY][x] == brickNum {
			yMax = myY
		}
	}
	for myY := x; myY >= 0; myY-- {
		if s[z][myY][x] == brickNum {
			yMin = myY
		}
	}
	// see if i can move down
	newZ := z
	for myZ := z - 1; myZ > 0; myZ-- {
		good := true
		for myY := yMin; myY <= yMax; myY++ {
			if s[myZ][myY][x] != 0 && s[myZ][myY][x] != blockMissing {
				good = false
				break
			}
		}
		if good {
			newZ = myZ
		} else {
			break
		}
	}
	if newZ != z {
		return false
	}
	return true
}
func isStableZ(s [][][]int, x, y, z, blockMissing int) bool {
	brickNum := s[z][y][x]
	// find out how big the brick is
	zMin := z
	for myZ := z; myZ > 0; myZ-- {
		if s[myZ][y][x] == brickNum {
			zMin = myZ
		}
	}
	// see if i can move down
	newZMin := zMin
	for myZ := zMin - 1; myZ > 0; myZ-- {
		if s[myZ][y][x] == 0 || s[myZ][y][x] == blockMissing {
			newZMin = myZ
		} else {
			break
		}
	}
	//move
	if newZMin != zMin {
		return false
	}
	return true
}

func readInput() ([][][]int, map[int]rune) {
	space := make([][][]int, Z_SIZE)
	for z := 0; z < Z_SIZE; z++ {
		space[z] = make([][]int, Y_SIZE)
		for y := 0; y < Y_SIZE; y++ {
			space[z][y] = make([]int, X_SIZE)
		}
	}
	dirs := make(map[int]rune, 0)

	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	blockNum := 1
	for scanner.Scan() {
		t := scanner.Text()
		pointsStrs := strings.Split(t, "~")
		x0, y0, z0 := getCoords(pointsStrs[0])
		x1, y1, z1 := getCoords(pointsStrs[1])
		if x0 != x1 {
			dirs[blockNum] = 'x'
			var min, max int
			if x0 < x1 {
				min, max = x0, x1
			} else {
				min, max = x1, x0
			}
			for x := min; x <= max; x++ {
				space[z0][y0][x] = blockNum
			}
		} else if y0 != y1 {
			dirs[blockNum] = 'y'
			var min, max int
			if y0 < y1 {
				min, max = y0, y1
			} else {
				min, max = y1, y0
			}
			for y := min; y <= max; y++ {
				space[z0][y][x0] = blockNum
			}
		} else if z0 != z1 {
			dirs[blockNum] = 'z'
			var min, max int
			if z0 < z1 {
				min, max = z0, z1
			} else {
				min, max = z1, z0
			}
			for z := min; z <= max; z++ {
				space[z][y0][x0] = blockNum
			}
		} else {
			dirs[blockNum] = 's'
			space[z0][y0][x0] = blockNum
		}
		blockNum++
	}

	return space, dirs
}

func getCoords(s string) (int, int, int) {
	strCoords := strings.Split(s, ",")
	x, err := strconv.Atoi(strCoords[0])
	if err != nil {
		panic(strCoords[0])
	}
	y, err := strconv.Atoi(strCoords[1])
	if err != nil {
		panic(strCoords[0])
	}
	z, err := strconv.Atoi(strCoords[2])
	if err != nil {
		panic(strCoords[0])
	}
	return x, y, z
}
