def Average(arr):
    sum = 0.0
    count = 0.0

    for num in arr:
        sum += num
        count += 1

    if count == 0:
        return 0.0
    return sum / count


def main():
    arr = [
        2.5,
        -1.4,
        -7.2,
        -11.7,
        -13.5,
        -13.5,
        -14.9,
        -15.2,
        -14.0,
        -9.7,
        -2.6,
        2.1,
    ]  # (a)
    ave = Average(arr)  # (b)
    student_id = "104844794"
    print("Average: ", ave)  # (c)
    print(f"Minh An Nguyen - {student_id}")  # (d)

    print("Multiple digits" if ave >= 10 else "Single digit")  # 9

    if ave < 0:  # 10
        print("Average value negative")

    # 11
    last_digit_ave = int(str(ave)[-1])
    last_digit_id = int(student_id[-1])

    if last_digit_ave > last_digit_id:
        print("Larger than my last digit")
    elif last_digit_ave < last_digit_id:
        print("Smaller than my last digit")
    else:
        print("Equal to my last digit")


main()
