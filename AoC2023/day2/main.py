with open("input.txt") as f: 
    lines = [x.strip() for x in f.readlines()]

def validate_score(current_game_score): 
    max_red = 12
    max_green = 13
    max_blue = 14

    if max(current_game_score["red"]) > max_red or max(current_game_score["green"]) > max_green or max(current_game_score["blue"]) > max_blue: 
        return False 
    return True  

def get_power(current_game_score): 
    return max(current_game_score["red"]) * max(current_game_score["green"]) * max(current_game_score["blue"]) 

p1 = 0
p2 = 0
games = lines
for i, game in enumerate(games): 
    current_game_score = {"red": [], "green": [], "blue": []}
    cubes = game.split(": ")[1]
    for cube in cubes.replace(";", ",").split(", "): 
        amount, color = cube.split()
        current_game_score[color].append(int(amount))
    
    if validate_score(current_game_score): 
        p1 += i + 1

    p2 += get_power(current_game_score)

print(p1)
print(p2)