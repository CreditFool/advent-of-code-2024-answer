def read_input(path: str):
    file = open(path, "r")
    list_a = []
    list_b = []
    for line in file:
        data = line.split()
        list_a.append(int(data[0]))
        list_b.append(int(data[-1]))

    return list_a, list_b


def calculate_distance(list_a, list_b):
    sorted_a = sorted(list_a)
    sorted_b = sorted(list_b)

    result = 0
    for i in range(len(sorted_a)):
        result += abs(sorted_a[i] - sorted_b[i])

    return result


def calculate_similiarity(list_a, list_b):
    appearence_dict = {}
    for data in list_a:
        appearence_dict[data] = 0

    for data in list_b:
        if data not in appearence_dict.keys():
            continue

        appearence_dict[data] += 1

    result = 0
    for key, val in appearence_dict.items():
        result += (key * val)

    return result


input = read_input("./input.txt")
print("distance:\t ", calculate_distance(*input))
print("similiarity:\t ", calculate_similiarity(*input))

