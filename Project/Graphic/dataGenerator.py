import random


def generate_same_letters(length):
    letter_num = random.randint(97, 122)
    text = ""
    for i in range(length):
        text += chr(letter_num)
    if length != 1000:
        text += "\n"
    return text


def generate_with_two_same_letters(length):
    text = ""
    letter_num_one = random.randint(97, 122)
    while True:
        letter_num_two = random.randint(97, 122)
        if letter_num_one != letter_num_two:
            break
    for i in range(length):
        letter = random.randint(1, 2)
        if letter == 1:
            text += chr(letter_num_one)
        else:
            text += chr(letter_num_two)
    if length != 1000:
        text += "\n"
    return text


def generate_with_diff_letters(length):
    text = ""
    for i in range(length):
        letter_num = random.randint(97, 122)
        text += chr(letter_num)
    if length != 1000:
        text += "\n"
    return text


def put_str_in_file(text, file_name):
    with open(file_name, "a") as f:
        f.write(text)


files = ["sameLetters", "twoSameLetters", "differentLetters"]
for i in range(3):
    for j in range(100, 1001, 30):
        if i == 0:
            put_str_in_file(generate_same_letters(j), files[i])
        elif i == 1:
            put_str_in_file(generate_with_two_same_letters(j), files[i])
        else:
            put_str_in_file(generate_with_diff_letters(j), files[i])