# Схема работы — Lab1. Вариант 6

---

## Структура класса Point3D

```
+----------------------------------+
|            Point3D               |
+----------------------------------+
| - x : double                     |
| - y : double                     |
| - z : double                     |
+----------------------------------+
| + Point3D()                      |
| + Point3D(x, y, z)               |
| + X : double  { get; set; }      |
| + Y : double  { get; set; }      |
| + Z : double  { get; set; }      |
| + Input() : void                 |
| + DistanceToOrigin() : double    |
| + Print() : void                 |
+----------------------------------+
```

---

## Поток выполнения программы (Main)

```
Main()
  │
  ├─► Объект 1: Point3D p1 = new Point3D()
  │     │
  │     ├─► p1.Input()          ← ввод X, Y, Z с клавиатуры
  │     ├─► p1.Print()          ← вывод координат
  │     └─► p1.DistanceToOrigin()  ← √(x²+y²+z²)
  │
  ├─► Объект 2: Point3D p2 = new Point3D(3, 4, 12)
  │     ├─► p2.Print()
  │     └─► p2.DistanceToOrigin()  → 13.0
  │
  ├─► Объект 3: Point3D p3 = new Point3D(-1.5, 2.5, -3.5)
  │     ├─► p3.Print()
  │     └─► p3.DistanceToOrigin()
  │
  └─► Изменение p2 через свойства
        p2.X = 1; p2.Y = 2; p2.Z = 2
        p2.Print()             → (1; 2; 2)
        p2.DistanceToOrigin()  → 3.0
```

---

## Формула расчёта

```
DistanceToOrigin = √(x² + y² + z²)

Пример: Point3D(3, 4, 12)
  √(3² + 4² + 12²) = √(9 + 16 + 144) = √169 = 13.0
```
