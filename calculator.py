def add(a, b):
    return a + b

def subtract(a, b):
    return a - b

def multiply(a, b):
    return a * b

def divide(a, b):
    if b == 0:
        raise ValueError("На ноль делить нельзя!")
    return a / b

def calculator():
    print("=== Калькулятор ===")
    print("Операции: +  -  *  /")
    print("Введите 'q' для выхода\n")

    while True:
        a = input("Первое число: ")
        if a.lower() == 'q':
            break

        op = input("Операция (+, -, *, /): ")

        b = input("Второе число: ")
        if b.lower() == 'q':
            break

        try:
            a, b = float(a), float(b)
            if op == '+':
                result = add(a, b)
            elif op == '-':
                result = subtract(a, b)
            elif op == '*':
                result = multiply(a, b)
            elif op == '/':
                result = divide(a, b)
            else:
                print("Неизвестная операция!\n")
                continue

            print(f"Результат: {result}\n")
        except ValueError as e:
            print(f"Ошибка: {e}\n")

if __name__ == "__main__":
    calculator()
