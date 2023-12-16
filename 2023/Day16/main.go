package main

import (
	"bufio"
	"fmt"
	"os"
)

func main() {
	fmt.Println("Part 1", run(&lightBeam{
		x:   -1,
		y:   0,
		dir: 'R',
	}))
	fmt.Println("Part 2", part2())
}

func part2() int {
	max := 0
	grid := readInput()
	height := len(grid)
	width := len(grid[0])

	// top and bottom
	for x := 0; x < width; x++ {
		val := run(&lightBeam{
			x:   x,
			y:   -1,
			dir: 'D',
		})
		if val > max {
			max = val
		}
		val = run(&lightBeam{
			x:   x,
			y:   height,
			dir: 'U',
		})
		if val > max {
			max = val
		}
	}
	// sides
	for y := 0; y < height; y++ {
		val := run(&lightBeam{
			x:   -1,
			y:   y,
			dir: 'R',
		})
		if val > max {
			max = val
		}
		val = run(&lightBeam{
			x:   width,
			y:   y,
			dir: 'L',
		})
		if val > max {
			max = val
		}
	}
	return max
}

func run(start *lightBeam) int {
	hist := make(map[string]int, 0)
	grid := readInput()
	height := len(grid)
	width := len(grid[0])
	beams := make([]*lightBeam, 0)
	beams = append(beams, start)
	beam1 := true
	for len(beams) > 0 {
		beam := beams[0]
		beams = beams[1:]
		if _, seen := hist[beam.String()]; seen {
			continue
		}
		hist[beam.String()] = 1
		if !beam1 { // we start off the grid
			grid[beam.y][beam.x].energized = true
		} else {
			beam1 = false
		}

		newBeam := &lightBeam{
			x:   moveX(beam.x, beam.dir),
			y:   moveY(beam.y, beam.dir),
			dir: beam.dir,
		}
		if newBeam.x < 0 || newBeam.y < 0 || newBeam.x >= width || newBeam.y >= height {
			continue // off grid
		}
		if grid[newBeam.y][newBeam.x].symbol == '.' {
			beams = append(beams, newBeam)
		} else if grid[newBeam.y][newBeam.x].symbol == '/' {
			newBeam.dir = mirrorNewDir('/', newBeam.dir)
			beams = append(beams, newBeam)
		} else if grid[newBeam.y][newBeam.x].symbol == '\\' {
			newBeam.dir = mirrorNewDir('\\', newBeam.dir)
			beams = append(beams, newBeam)
		} else if grid[newBeam.y][newBeam.x].symbol == '-' {
			if newBeam.dir == 'U' || newBeam.dir == 'D' {
				newBeam.dir = 'L'
				beams = append(beams, newBeam)
				beams = append(beams, &lightBeam{
					x:   newBeam.x,
					y:   newBeam.y,
					dir: 'R',
				})
			} else {
				beams = append(beams, newBeam)
			}
		} else if grid[newBeam.y][newBeam.x].symbol == '|' {
			if newBeam.dir == 'L' || newBeam.dir == 'R' {
				newBeam.dir = 'U'
				beams = append(beams, newBeam)
				beams = append(beams, &lightBeam{
					x:   newBeam.x,
					y:   newBeam.y,
					dir: 'D',
				})
			} else {
				beams = append(beams, newBeam)
			}
		}
	}

	energized := 0
	for _, r := range grid {
		for _, beam := range r {
			if beam.energized {
				energized++
			}
		}
	}
	return energized

}

func mirrorNewDir(mirror rune, curDir rune) rune {
	if mirror == '/' {
		if curDir == 'U' {
			return 'R'
		} else if curDir == 'D' {
			return 'L'
		} else if curDir == 'L' {
			return 'D'
		} else {
			return 'U'
		}
	} else { // \
		if curDir == 'U' {
			return 'L'
		} else if curDir == 'D' {
			return 'R'
		} else if curDir == 'L' {
			return 'U'
		} else {
			return 'D'
		}
	}
}

func moveY(curY int, dir rune) int {
	if dir == 'U' {
		return curY - 1
	}
	if dir == 'D' {
		return curY + 1
	}
	return curY
}

func moveX(curX int, dir rune) int {
	if dir == 'L' {
		return curX - 1
	}
	if dir == 'R' {
		return curX + 1
	}
	return curX
}

func readInput() [][]*tile {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	grid := make([][]*tile, 0)
	scanner := bufio.NewScanner(f)
	defer f.Close()

	for scanner.Scan() {
		row := make([]*tile, 0)
		t := scanner.Text()
		for _, r := range t {
			row = append(row, &tile{
				symbol:    r,
				energized: false,
			})
		}
		grid = append(grid, row)
	}

	return grid
}

type tile struct {
	symbol    rune
	energized bool
}

type lightBeam struct {
	x   int
	y   int
	dir rune
}

func (l *lightBeam) String() string {
	return fmt.Sprintf("%v,%v,%v", l.x, l.y, l.dir)
}
