package main

import (
	"bufio"
	"os"
	"strconv"
	"strings"
)

const (
	file20 = "day20/input.txt"
)

type point3D struct {
	X int
	Y int
	Z int
}

type particle struct {
	Number       int
	Position     *point3D
	Velocity     *point3D
	Acceleration *point3D
	Destroyed    bool
}

func part1() int {
	arr := loadFromFile()
	minInd := 0

	for k, v := range arr {
		if v.isLessThan(arr[minInd]) {
			minInd = k
		}
	}
	return minInd

}
func d20part2() int {
	arr := loadFromFile()
	for i := 0; i < 100; i++ {
		// update all
		for _, v := range arr {
			v.update()
		}

		//handle collisions
		for k, v := range arr {
			if !v.Destroyed {
				for j := k + 1; j < len(arr); j++ {
					if v.Position.equals(arr[j].Position) {
						v.Destroyed = true
						arr[j].Destroyed = true
					}
				}
			}
		}

	}

	count := 0
	for _, v := range arr {
		if !v.Destroyed {
			count++
		}
	}
	return count
}

func (p1 point3D) equals(p2 *point3D) bool {
	return (p1.X == p2.X) && (p1.Y == p2.Y) && (p1.Z == p2.Z)
}
func (p *particle) update() {
	if !p.Destroyed {
		p.Velocity.X += p.Acceleration.X
		p.Velocity.Y += p.Acceleration.Y
		p.Velocity.Z += p.Acceleration.Z

		p.Position.X += p.Velocity.X
		p.Position.Y += p.Velocity.Y
		p.Position.Z += p.Velocity.Z
	}
}

func (p1 particle) isLessThan(p2 *particle) bool {
	if p1.Acceleration.manhattenDist() < p2.Acceleration.manhattenDist() {
		return true
	} else if p1.Acceleration.manhattenDist() > p2.Acceleration.manhattenDist() {
		return false
	}

	//Acceleration equal at this point
	if p1.Velocity.manhattenDist() < p2.Velocity.manhattenDist() {
		return true
	} else if p1.Velocity.manhattenDist() > p2.Velocity.manhattenDist() {
		return false
	}

	//Velocity equal at this point
	if p1.Position.manhattenDist() < p2.Position.manhattenDist() {
		return true
	}
	return false

}

func (p point3D) manhattenDist() int {
	var absX, absY, absZ int
	if p.X < 0 {
		absX = -1 * p.X
	} else {
		absX = p.X
	}

	if p.Y < 0 {
		absY = -1 * p.Y
	} else {
		absY = p.Y
	}

	if p.Z < 0 {
		absZ = -1 * p.Z
	} else {
		absZ = p.Z
	}

	return absX + absY + absZ
}

func parseLine(num int, line string) *particle {
	part := new(particle)
	part.Number = num

	ltSplits := strings.Split(line, "<")
	pstring := strings.Split(ltSplits[1], ">")[0]
	vstring := strings.Split(ltSplits[2], ">")[0]
	astring := strings.Split(ltSplits[3], ">")[0]

	p := new(point3D)
	pcoords := strings.Split(pstring, ",")
	p.X, _ = strconv.Atoi(pcoords[0])
	p.Y, _ = strconv.Atoi(pcoords[1])
	p.Z, _ = strconv.Atoi(pcoords[2])
	part.Position = p

	v := new(point3D)
	vcoords := strings.Split(vstring, ",")
	v.X, _ = strconv.Atoi(vcoords[0])
	v.Y, _ = strconv.Atoi(vcoords[1])
	v.Z, _ = strconv.Atoi(vcoords[2])
	part.Velocity = v

	a := new(point3D)
	acoords := strings.Split(astring, ",")
	a.X, _ = strconv.Atoi(acoords[0])
	a.Y, _ = strconv.Atoi(acoords[1])
	a.Z, _ = strconv.Atoi(acoords[2])
	part.Acceleration = a

	part.Destroyed = false

	return part
}

func loadFromFile() []*particle {
	particles := make([]*particle, 1000)
	file, err := os.Open(file20)
	if err != nil {
		panic(err)
	}
	defer func() {
		if err := file.Close(); err != nil {
			panic(err)
		}
	}()
	scanner := bufio.NewScanner(file)
	index := 0
	for scanner.Scan() {
		particles[index] = parseLine(index, scanner.Text())
		index++
	}

	return particles
}
