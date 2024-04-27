# Did not solve this one on my own, had to google for some help.
# Remember to practice more "grid" problems.

with open("input.txt") as f: 
    lines = [x.rstrip() for x in f.readlines()]

P = complex
adjacent = [P(-1,1), P(0,1), P(1,1), P(-1,0), P(1,0), P(-1,-1), P(0,-1), P(1,-1)]

def get_number(grid, pos):
	if pos not in grid or not grid[pos].isnumeric():
		return None

	while pos-1 in grid and grid[pos-1].isnumeric():
		pos -= 1

	start = pos
	num = ""
	while pos in grid and grid[pos].isnumeric():
		num+=grid[pos]
		pos+=1

	return start, int(num)

def get_adacent_parts(grid, pos):
	parts = set()
	for d in adjacent:
		parts.add(get_number(grid, pos+d))
	return parts-{None}

def p1(grid, symbols):
	parts = set()
	for s in symbols:
		parts|=get_adacent_parts(grid, s)
	p1 = 0
	for p in parts:
		p1+=p[1]
	return p1

def p2(grid, symbols):
	ans = 0
	for s in symbols:
		if grid[s] != '*': continue
		parts = list(get_adacent_parts(grid, s))
		if len(parts) == 2:
			ans += parts[0][1]*parts[1][1]
	return ans

grid = {}
symbols = []
for y, line in enumerate(lines):
    for x, v in enumerate(line):
        if v != ".":
            grid[P(x,y)] = v
            if not v.isnumeric():
                symbols.append(P(x,y))

print(p1(grid, symbols))
print(p2(grid, symbols))