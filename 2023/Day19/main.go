package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
	"strings"
)

var combinations int

func main() {
	fmt.Println("Part 1", part1())
	fmt.Println("Part 2", part2())
}

func part1() int {
	total := 0
	w, parts := readInput()
	for _, p := range parts {
		if w.eval(p) == "A" {
			total += p.totalRating()
		}
	}
	return total
}

func part2() int {
	w, _ := readInput()
	combinations = 0
	w.traverse(*InitRanges(), "in")
	return combinations
}

func readInput() (*workflow, []*part) {
	f, err := os.Open("input.txt")
	if err != nil {
		panic(err)
	}
	scanner := bufio.NewScanner(f)
	defer f.Close()
	myWorkflow := newWorkflow()
	for scanner.Scan() {
		t := scanner.Text()
		if t == "" {
			break
		}
		myWorkflow.addRule(workflowRuleFromString(t))
	}
	parts := make([]*part, 0)
	for scanner.Scan() {
		t := scanner.Text()
		parts = append(parts, partFromString(t))
	}

	return myWorkflow, parts
}

func partFromString(str string) *part {
	//example input {x=787,m=2655,a=1222,s=2876}
	// drop braces
	s1 := str[1 : len(str)-1]
	valueStrs := strings.Split(s1, ",")
	x, err := strconv.Atoi(strings.Split(valueStrs[0], "=")[1])
	if err != nil {
		panic(err)
	}
	m, err := strconv.Atoi(strings.Split(valueStrs[1], "=")[1])
	if err != nil {
		panic(err)
	}
	a, err := strconv.Atoi(strings.Split(valueStrs[2], "=")[1])
	if err != nil {
		panic(err)
	}
	s, err := strconv.Atoi(strings.Split(valueStrs[3], "=")[1])
	if err != nil {
		panic(err)
	}
	return &part{
		x: x,
		m: m,
		a: a,
		s: s,
	}
}

type part struct {
	x int
	m int
	a int
	s int
}

type ranges struct {
	mins  map[string]int
	maxes map[string]int
}

func InitRanges() *ranges {
	mins := make(map[string]int, 4)
	maxes := make(map[string]int, 4)
	for _, d := range []string{"x", "m", "a", "s"} {
		maxes[d] = 4000
		mins[d] = 1
	}
	return &ranges{
		mins:  mins,
		maxes: maxes,
	}
}

func (r *ranges) count() {
	total := 1
	for _, d := range []string{"x", "m", "a", "s"} {
		total *= (r.maxes[d] - r.mins[d] + 1)
	}
	combinations += total
}

func (r *ranges) applyCondition(c *condition) ranges {
	newRanges := InitRanges()
	for _, d := range []string{"x", "m", "a", "s"} {
		newRanges.maxes[d] = r.maxes[d]
		newRanges.mins[d] = r.mins[d]
	}
	if c.compOp == ">" {
		newMin := c.value + 1
		if newMin > newRanges.mins[c.variable] {
			newRanges.mins[c.variable] = newMin
		}
	} else {
		newMax := c.value - 1
		if newMax < newRanges.maxes[c.variable] {
			newRanges.maxes[c.variable] = newMax
		}
	}
	return *newRanges
}

func (r *ranges) applyNotCondition(c *condition) ranges {
	newRanges := InitRanges()
	for _, d := range []string{"x", "m", "a", "s"} {
		newRanges.maxes[d] = r.maxes[d]
		newRanges.mins[d] = r.mins[d]
	}
	if c.compOp == ">" {
		newMax := c.value
		if newMax < newRanges.maxes[c.variable] {
			newRanges.maxes[c.variable] = newMax
		}
	} else {
		newMin := c.value
		if newMin > newRanges.mins[c.variable] {
			newRanges.mins[c.variable] = newMin
		}

	}
	return *newRanges
}

func (p *part) totalRating() int {
	return p.x + p.m + p.a + p.s
}
func newWorkflow() *workflow {
	return &workflow{
		rules: make(map[string]*workflowRule, 0),
	}
}

type workflow struct {
	rules map[string]*workflowRule
}

// recursive traverse through to workflow
func (w *workflow) traverse(r ranges, at string) {
	rule := w.rules[at]
	for _, s := range rule.steps {
		// check for default case
		if s.cond == nil {
			// these parts are accepted add them to the count
			if s.dest == "A" {
				r.count()
			} else if s.dest != "R" {
				// the ranges are the same since it was a default case
				w.traverse(r, s.dest)
			}
		} else {
			// not a default state so we must divide the range into parts meeting this condition and not
			// apply the condition for the partition of parts meeting the condition
			newR := r.applyCondition(s.cond)
			if s.dest == "A" {
				// parts meeting the new ranges are accepted.  Count them
				newR.count()
			} else if s.dest != "R" {
				// traverse deeper into the workflow with the new ranges
				w.traverse(newR, s.dest)
			}
			// when moving to the next rule, we want only parts not meeting the condition
			r = r.applyNotCondition(s.cond)
		}
	}
}

func (w *workflow) eval(p *part) string {
	ruleName := "in"
	for ruleName != "R" && ruleName != "A" {
		rule := w.rules[ruleName]
		ruleName = rule.eval(p)
	}
	return ruleName
}

func (w *workflow) addRule(r *workflowRule) {
	w.rules[r.name] = r
}

func workflowRuleFromString(s string) *workflowRule {
	splits := strings.Split(s, "{")
	name := splits[0]
	ruleString := strings.Split(splits[1], "}")[0]
	splitRules := strings.Split(ruleString, ",")
	rules := make([]*workflowStep, 0)
	for _, r := range splitRules {
		rules = append(rules, workflowStepFromString(r))
	}
	return &workflowRule{
		name:  name,
		steps: rules,
	}
}

func (wr *workflowRule) eval(p *part) string {
	for _, s := range wr.steps {
		if s.cond == nil {
			return s.dest
		}
		if s.cond.eval(p) {
			return s.dest
		}
	}
	panic(wr)
}

type workflowRule struct {
	name  string
	steps []*workflowStep
}

func workflowStepFromString(s string) *workflowStep {
	splits := strings.Split(s, ":")
	if len(splits) == 1 {
		return &workflowStep{
			cond: nil,
			dest: splits[0],
		}
	} else {
		return &workflowStep{
			cond: conditionFromString(splits[0]),
			dest: splits[1],
		}
	}
}

type workflowStep struct {
	cond *condition
	dest string
}

func conditionFromString(s string) *condition {
	val, err := strconv.Atoi(s[2:])
	if err != nil {
		panic(err)
	}
	return &condition{
		variable: s[0:1],
		compOp:   s[1:2],
		value:    val,
	}
}

func (c *condition) eval(p *part) bool {
	var n int
	if c.variable == "x" {
		n = p.x
	} else if c.variable == "m" {
		n = p.m
	} else if c.variable == "a" {
		n = p.a
	} else if c.variable == "s" {
		n = p.s
	} else {
		fmt.Println("variable panic")
		panic(c.variable)
	}
	if c.compOp == ">" {
		return n > c.value
	} else if c.compOp == "<" {
		return n < c.value
	} else {
		fmt.Println("op panic")
		panic(c.compOp)
	}
}

type condition struct {
	variable string
	compOp   string
	value    int
}
