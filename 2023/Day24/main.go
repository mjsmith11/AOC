package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

const (
	RANGE_START = 200000000000000
	RANGE_END   = 400000000000000
)

func main() {
	fmt.Println("Part 1", part1())

	part2()
	// adding my starting coords for p2
	fmt.Println(335849990884055 + 362494628861890 + 130073711567420)
}
func part2() {
	// This is black magic from https://github.com/DeadlyRedCube/AdventOfCode/blob/main/2023/AOC2023/D24.h
	// It spits out a system of 6 equations in 6 vars.  Solve that system elsewhere.  t,u,v are the initial location
	// of the rock.  x,y,z are the velocity of the rock.
	// Can use any 3 hailstones to calculate, but maybe there's an issue if they have the same or parallel velocity.

	// [Avy - Bvy]Px - [Avx - Bvx]Py - [A0y - B0y]Qx + [A0x - B0x]Qy = (B0y * Bvx - B0x * Bvy) - (A0y * Avx - A0x * Avy)
	// [Avy - Cvy]Px - [Avx - Cvx]Py - [A0y - C0y]Qx + [A0x - C0x]Qy = (C0y * Cvx - C0x * Cvy) - (A0y * Avx - A0x * Avy)
	// [Avx - Bvx]Pz - [Avz - Bvz]Px - [A0x - B0x]Qz + [A0z - B0z]Qx = (B0x * Bvz - B0z * Bvx) - (A0x * Avz - A0z * Avx)
	// [Avx - Cvx]Pz - [Avz - Cvz]Px - [A0x - C0x]Qz + [A0z - C0z]Qx = (C0x * Cvz - C0z * Cvx) - (A0x * Avz - A0z * Avx)
	// [Avz - Bvz]Py - [Avy - Bvy]Pz - [A0z - B0z]Qy + [A0y - B0y]Qz = (B0z * Bvy - B0y * Bvz) - (A0z * Avy - A0y * Avz)
	// [Avz - Cvz]Py - [Avy - Cvy]Pz - [A0z - C0z]Qy + [A0y - C0y]Qz = (C0z * Cvy - C0y * Cvz) - (A0z * Avy - A0y * Avz)
	stones := readInput()
	A := stones[0]
	B := stones[1]
	C := stones[2]

	abvx := A.vx - B.vx
	abvy := A.vy - B.vy
	abvz := A.vz - B.vz

	acvx := A.vx - C.vx
	acvy := A.vy - C.vy
	acvz := A.vz - C.vz

	ab0x := A.px - B.px
	ab0y := A.py - B.py
	ab0z := A.pz - B.pz

	ac0x := A.px - C.px
	ac0y := A.py - C.py
	ac0z := A.pz - C.pz

	h0 := (B.py*B.vx - B.px*B.vy) - (A.py*A.vx - A.px*A.vy)
	h1 := (C.py*C.vx - C.px*C.vy) - (A.py*A.vx - A.px*A.vy)
	h2 := (B.px*B.vz - B.pz*B.vx) - (A.px*A.vz - A.pz*A.vx)
	h3 := (C.px*C.vz - C.pz*C.vx) - (A.px*A.vz - A.pz*A.vx)
	h4 := (B.pz*B.vy - B.py*B.vz) - (A.pz*A.vy - A.py*A.vz)
	h5 := (C.pz*C.vy - C.py*C.vz) - (A.pz*A.vy - A.py*A.vz)

	// abvy*Px - abvx*Py - ab0y*Qx + ab0x*Qy = h0
	// acvy*Px - acvx*Py - ac0y*Qx + ac0x*Qy = h1
	// abvx*Pz - abvz*Px - ab0x*Qz + ab0z*Qx = h2
	// acvx*Pz - acvz*Px - ac0x*Qz + ac0z*Qx = h3
	// abvz*Py - abvy*Pz - ab0z*Qy + ab0y*Qz = h4
	// acvz*Py - acvy*Pz - ac0z*Qy + ac0y*Qz = h5

	equPrint(abvy, -1*abvx, 0, -1*ab0y, ab0x, 0, h0)
	equPrint(acvy, -1*acvx, 0, -1*ac0y, ac0x, 0, h1)
	equPrint(-1*abvz, 0, abvx, ab0z, 0, -1*ab0x, h2)
	equPrint(-1*acvz, 0, acvx, ac0z, 0, -1*ac0x, h3)
	equPrint(0, abvz, -1*abvy, 0, -1*ab0z, ab0y, h4)
	equPrint(0, acvz, -1*acvy, 0, -1*ac0z, ac0y, h5)

}
func equPrint(u, v, w, x, y, z, rhs int) {
	fmt.Printf("%du", u)
	if v >= 0 {
		fmt.Print("+")
	}
	fmt.Printf("%dv", v)
	if w >= 0 {
		fmt.Print("+")
	}
	fmt.Printf("%dw", w)
	if x >= 0 {
		fmt.Print("+")
	}
	fmt.Printf("%dx", x)
	if y >= 0 {
		fmt.Print("+")
	}
	fmt.Printf("%dy", y)
	if z >= 0 {
		fmt.Print("+")
	}
	fmt.Printf("%dz", z)
	fmt.Printf("=%d\n", rhs)
}
func part1() int {
	//convert parametric equations to cartesian, find their intersection and see if it meets the criteria
	stones := readInput()
	valid := 0
	for i := 0; i < len(stones); i++ {
		for j := i + 1; j < len(stones); j++ {
			m1, b1 := to2DCart(stones[i])
			m2, b2 := to2DCart(stones[j])
			x, y := solve2D(m1, b1, m2, b2)
			if x >= RANGE_START && x <= RANGE_END {
				if y >= RANGE_START && y <= RANGE_END {
					ti := (x - float64(stones[i].px)) / float64(stones[i].vx)
					if ti > 0 {
						tj := (x - float64(stones[j].px)) / float64(stones[j].vx)
						if tj > 0 {
							valid++
						}
					}
				}
			}
		}
	}
	return valid
}

func solve2D(m1, b1, m2, b2 float64) (float64, float64) {
	x := (b2 - b1) / (m1 - m2)
	y := m1*x + b1
	return x, y
}

func to2DCart(h hailstone) (float64, float64) {
	m := float64(h.vy) / float64(h.vx)
	b := float64(h.py) + (-1 * float64(h.px) / float64(h.vx) * float64(h.vy))
	return m, b
}
func readInput() []hailstone {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	stones := make([]hailstone, 0)
	for scanner.Scan() {
		t := scanner.Text()
		stone := hailstone{}
		parts := strings.Split(t, " @ ")
		stone.px, stone.py, stone.pz = getTriple(parts[0])
		stone.vx, stone.vy, stone.vz = getTriple(parts[1])
		stones = append(stones, stone)
	}

	return stones
}
func getTriple(s string) (int, int, int) {
	splits := strings.Split(s, ", ")
	x, err := strconv.Atoi(strings.Trim(splits[0], " "))
	if err != nil {
		panic(err)
	}
	y, err := strconv.Atoi(strings.Trim(splits[1], " "))
	if err != nil {
		panic(err)
	}
	z, err := strconv.Atoi(strings.Trim(splits[2], " "))
	if err != nil {
		panic(err)
	}
	return x, y, z
}

type hailstone struct {
	px, py, pz int
	vx, vy, vz int
}
