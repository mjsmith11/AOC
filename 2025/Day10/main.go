package main

import (
	"bufio"
	"fmt"
	"os"
	"slices"
	"strconv"
	"strings"

	"github.com/draffensperger/golp" //note this has extra install steps
)

func main() {
	fmt.Println("Part 1:", part1())
	fmt.Println("Part 2:", part2())
}
func part1() int {
	machines := readInput()
	total := 0
	for _, m := range machines {
		total += BFS(m)
	}
	return total
}
func part2() int {
	machines := readInput()
	total := 0
	for _, m := range machines {
		total += LP(m)
	}
	return total
}

func LP(m machine) int {
	const maxClicks = 1000
	numJoltages := len(m.joltageReq)
	lp := golp.NewLP(0, len(m.buttons))
	lp.SetVerboseLevel(golp.NEUTRAL)
	objectiveCoeffs := make([]float64, len(m.buttons))
	for i := 0; i < len(m.buttons); i++ {
		objectiveCoeffs[i] = 1.0
		lp.SetInt(i, true)
		lp.SetBounds(i, 0.0, float64(maxClicks))
	}
	lp.SetObjFn(objectiveCoeffs)
	for i := 0; i < numJoltages; i++ {
		var entries []golp.Entry
		for j, btn := range m.buttons {
			if slices.Contains(btn, i) {
				entries = append(entries, golp.Entry{Col: j, Val: 1.0})
			}
		}
		targetValue := float64(m.joltageReq[i])
		if err := lp.AddConstraintSparse(entries, golp.EQ, targetValue); err != nil {
			panic(err)
		}
	}
	status := lp.Solve()
	if status != golp.OPTIMAL {
		return 0
	}
	solution := lp.Variables()
	clicks := 0
	for _, val := range solution {
		clicks += int(val + 0.5)
	}
	return clicks
}

func BFS(m machine) int {
	q := make([]state, 0)
	q = append(q, BeginningState(len(m.lightReq)))
	for len(q) > 0 {
		st := q[0]
		q = q[1:]
		if st.IsGoal(m.lightReq) {
			return st.presses
		}
		for _, b := range m.buttons {
			newState := st.ApplyPress(b)
			q = append(q, newState)
		}
	}
	return -1
}

type state struct {
	presses int
	lights  []bool
}

func BeginningState(size int) state {
	return state{
		presses: 0,
		lights:  make([]bool, size),
	}
}

func (s *state) ApplyPress(button []int) state {
	newLights := make([]bool, len(s.lights))
	for i, l := range s.lights {
		newLights[i] = l
	}
	for _, l := range button {
		newLights[l] = !newLights[l]
	}
	return state{
		lights:  newLights,
		presses: s.presses + 1,
	}
}

func (s *state) IsGoal(goal []bool) bool {
	for i, l := range s.lights {
		if l != goal[i] {
			return false
		}
	}
	return true
}

type machine struct {
	lightReq   []bool
	buttons    [][]int
	joltageReq []int
}

func readInput() []machine {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	defer f.Close()

	nodes := make([]machine, 0)

	scanner := bufio.NewScanner(f)
	for scanner.Scan() {
		str := scanner.Text()
		splits := strings.Split(str, " ")
		lights := make([]bool, 0)
		for i := 1; i < len(splits[0])-1; i++ {
			if splits[0][i] == '#' {
				lights = append(lights, true)
			} else {
				lights = append(lights, false)
			}
		}
		opts := make([][]int, 0)
		for i := 1; i < len(splits)-1; i++ {
			opt := make([]int, 0)
			str := splits[i]
			str = str[1 : len(str)-1]
			splitsN := strings.Split(str, ",")
			for _, nStr := range splitsN {
				n, err := strconv.ParseInt(nStr, 10, 64)
				if err != nil {
					panic(err)
				}
				opt = append(opt, int(n))
			}
			opts = append(opts, opt)
		}
		joltage := make([]int, 0)
		joltageStr := splits[len(splits)-1]
		joltageStr = joltageStr[1 : len(joltageStr)-1]
		joltageSplits := strings.Split(joltageStr, ",")
		for _, jStr := range joltageSplits {
			j, err := strconv.ParseInt(jStr, 10, 64)
			if err != nil {
				panic(err)
			}
			joltage = append(joltage, int(j))
		}

		nodes = append(nodes, machine{
			lightReq:   lights,
			buttons:    opts,
			joltageReq: joltage,
		})
	}

	return nodes
}
