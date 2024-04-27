with open("input.txt") as f: 
    lines = [x.rstrip() for x in f.readlines()]

def p1(): 
    r = 0
    for line in lines: 
        data = line.split(": ")[1].split(' | ')

        winning_numbers =  [int(val) for val in data[0].split()]
        numbers = [int(val) for val in data[1].split()]

        card_points = 0  
        for number in numbers: 
            if number in winning_numbers and card_points == 0: 
                card_points = 1
            elif number in winning_numbers: 
                card_points = card_points * 2 
        
        r += card_points

    return r

def p2(): 
    r = {}
    for i, line in enumerate(lines): 
        data = line.split(": ")[1].split(' | ')
        winning_numbers =  [int(val) for val in data[0].split()]
        numbers = [int(val) for val in data[1].split()]

        if i not in r: 
            r[i] = 1 

        card_points = 0
        for number in numbers: 
            if number in winning_numbers: 
                card_points += 1

        for n in range(i + 1, i + card_points + 1): 
            r[n] = r.get(n, 1) + r[i]
        
    return sum(r.values())

print(p1())
print(p2())