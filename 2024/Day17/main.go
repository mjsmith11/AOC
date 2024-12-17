package main

import (
	"fmt"
	"math"
	"strconv"
	"strings"
)

var done bool

// 139543226591642 too high
func main() {
	fmt.Print("Part 1:")
	comp := New("2,4,1,5,7,5,1,6,4,2,5,5,0,3,3,0", 33940147, 0, 0)
	comp.run1()
	fmt.Println()
	done = false
	part2(0, "2,4,1,5,7,5,1,6,4,2,5,5,0,3,3,0")
}

func part2(curOct int, prog string) {
	if done {
		return
	}
	a := curOct
	for i := 0; i < 8; i++ {
		comp := New(prog, a, 0, 0)
		comp.run2()
		match := true
		for i, v := range comp.out {
			if v != comp.program[16-len(comp.out)+i] {
				match = false
			}
		}
		if match {
			if len(comp.out) == 16 {
				fmt.Println("Part 2:", a)
				done = true
				break
			} else {
				part2(a*8, prog)
			}
		}
		a++
	}
}

func octToInt(digits []int) int {
	sum := 0
	for i, v := range digits {
		sum += int(math.Pow(8, float64(i))) * v
	}
	return sum
}

type cpu struct {
	program []int
	pc      int
	a       int
	b       int
	c       int
	out     []int
}

func New(program string, a, b, c int) *cpu {
	instructions := strings.Split(program, ",")
	prog := make([]int, 0)
	for _, v := range instructions {
		n, err := strconv.Atoi(v)
		if err != nil {
			panic(err)
		}
		prog = append(prog, n)
	}
	return &cpu{
		program: prog,
		pc:      0,
		a:       a,
		b:       b,
		c:       c,
		out:     make([]int, 0),
	}
}

func (c *cpu) run1() {
	for c.pc < len(c.program) {
		op := c.program[c.pc]
		comboarg := c.getVal(c.program[c.pc+1])
		literalarg := c.program[c.pc+1]
		if op == 0 {
			c.a = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
		if op == 1 {
			c.b = c.b ^ literalarg
			c.pc += 2
		}
		if op == 2 {
			c.b = comboarg % 8
			c.pc += 2
		}
		if op == 3 {
			if c.a != 0 {
				c.pc = literalarg
			} else {
				c.pc += 2
			}
		}
		if op == 4 {
			c.b = c.b ^ c.c
			c.pc += 2
		}
		if op == 5 {
			fmt.Print(comboarg%8, ",")
			c.pc += 2
		}
		if op == 6 {
			c.b = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
		if op == 7 {
			c.c = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
	}
}

func (c *cpu) run2() {
	for c.pc < len(c.program) {
		op := c.program[c.pc]
		comboarg := c.getVal(c.program[c.pc+1])
		literalarg := c.program[c.pc+1]
		if op == 0 {
			c.a = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
		if op == 1 {
			c.b = c.b ^ literalarg
			c.pc += 2
		}
		if op == 2 {
			c.b = comboarg % 8
			c.pc += 2
		}
		if op == 3 {
			if c.a != 0 {
				c.pc = literalarg
			} else {
				c.pc += 2
			}
		}
		if op == 4 {
			c.b = c.b ^ c.c
			c.pc += 2
		}
		if op == 5 {
			c.out = append(c.out, comboarg%8)
			c.pc += 2
		}
		if op == 6 {
			c.b = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
		if op == 7 {
			c.c = int(float64(c.a) / math.Pow(2, float64(comboarg)))
			c.pc += 2
		}
	}
}

// func (c *cpu) makesCopy() bool {
// 	for c.pc < len(c.program) {
// 		op := c.program[c.pc]
// 		comboarg := c.getVal(c.program[c.pc+1])
// 		literalarg := c.program[c.pc+1]
// 		if op == 0 {
// 			c.a = int(float64(c.a) / math.Pow(2, float64(comboarg)))
// 			c.pc += 2
// 		}
// 		if op == 1 {
// 			c.b = c.b ^ literalarg
// 			c.pc += 2
// 		}
// 		if op == 2 {
// 			c.b = comboarg % 8
// 			c.pc += 2
// 		}
// 		if op == 3 {
// 			if c.a != 0 {
// 				c.pc = literalarg
// 			} else {
// 				c.pc += 2
// 			}
// 		}
// 		if op == 4 {
// 			c.b = c.b ^ c.c
// 			c.pc += 2
// 		}
// 		if op == 5 {
// 			val := comboarg % 8
// 			if c.outPtr >= len(c.program) {
// 				return false
// 			}
// 			if c.program[c.outPtr] != val {
// 				return false
// 			}
// 			c.outPtr++
// 			c.pc += 2
// 		}
// 		if op == 6 {
// 			c.b = int(float64(c.a) / math.Pow(2, float64(comboarg)))
// 			c.pc += 2
// 		}
// 		if op == 7 {
// 			c.c = int(float64(c.a) / math.Pow(2, float64(comboarg)))
// 			c.pc += 2
// 		}
// 	}
// 	return c.outPtr == len(c.program)
// }

func (c *cpu) getVal(code int) int {
	if code <= 3 {
		return code
	}
	if code == 4 {
		return c.a
	}
	if code == 5 {
		return c.b
	}
	if code == 6 {
		return c.c
	}
	panic(code)
}
