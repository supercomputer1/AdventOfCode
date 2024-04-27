def try_convert_string_to_int(value): 
    try: 
        return int(value)
    except ValueError: 
        return value

def get_translated_number(value): 
    for k, v in translations.items(): 
        if v == value: 
            return k
    return 0

def get_digit_sum(values): 
    return int(f"{values[0]}{values[-1]}")

with open("input.txt") as f: 
    lines = [x.strip() for x in f.readlines()]

translations = {
    1: "one",
    2: "two",
    3: "three",
    4: "four",
    5: "five",
    6: "six",
    7: "seven",
    8: "eight",
    9: "nine"
} 

map = {} 
for i in range(len(lines)): 
    for char in lines[i]: 
        if i in map: 
            map[i].append(try_convert_string_to_int(char))
        else: 
            map[i] = [try_convert_string_to_int(char)]
    
def part_one(): 
    sums = []
    for v in map.values(): 
        values = []
        for i in range(len(v)):
            if type(v[i]) == int: 
                values.append(int(v[i]))
        sums.append(get_digit_sum(values))

    return sum(sums)

def part_two():
    sums = []
    for v in map.values(): 
        current_line_sums = []
        for i in range(len(v)): 
            if type(v[i]) == int: 
                current_line_sums.append(v[i])
                continue
            current_word = v[i] 
            for j in range(i + 1, len(v)): 
                if type(v[j]) == int: 
                    continue
                current_word += v[j]
                translatedValue = get_translated_number(current_word)
                if translatedValue != 0: 
                    current_line_sums.append(translatedValue)
        sums.append(get_digit_sum(current_line_sums))

    return sum(sums)

print(part_one())
print(part_two())