package main

import (
	"bufio"
	"strconv"
	"strings"
)

func execute23(inst []string) int {
	pc := 0
	reg := make(map[string]int, 8)
	mulCnt := 0
	for pc >= 0 && pc < len(inst) {
		parts := strings.Split(inst[pc], " ")
		if parts[0] == "set" {
			reg[parts[1]] = getValue23(reg, parts[2])
		} else if parts[0] == "sub" {
			reg[parts[1]] = getValue23(reg, parts[1]) - getValue23(reg, parts[2])
		} else if parts[0] == "mul" {
			reg[parts[1]] = getValue23(reg, parts[1]) * getValue23(reg, parts[2])
			mulCnt++
		} else if parts[0] == "jnz" {
			if getValue23(reg, parts[1]) != 0 {
				pc += getValue23(reg, parts[2])
				continue
			}
		} else {
			panic(parts[0])
		}
		pc++
	}
	return mulCnt
}

func getValue23(reg map[string]int, s string) int {
	s = strings.TrimSpace(s)
	if value, err := strconv.Atoi(s); err == nil {
		return value
	}
	if value, exists := reg[s]; exists {
		return value
	}
	return 0
}

func getInst23() []string {
	raw := `set b 84
	set c b
	jnz a 2
	jnz 1 5
	mul b 100
	sub b -100000
	set c b
	sub c -17000
	set f 1
	set d 2
	set e 2
	set g d
	mul g e
	sub g b
	jnz g 2
	set f 0
	sub e -1
	set g e
	sub g b
	jnz g -8
	sub d -1
	set g d
	sub g b
	jnz g -13
	jnz f 2
	sub h -1
	set g b
	sub g c
	jnz g 2
	jnz 1 3
	sub b -17
	jnz 1 -23`
	instructions := make([]string, 32, 32)
	scanner := bufio.NewScanner(strings.NewReader(raw))
	index := 0
	for scanner.Scan() {
		instructions[index] = strings.Trim(scanner.Text(), "\t")
		index++
	}
	return instructions
}
