# Схема работы — Lab4. Вариант 6

---

## Иерархия классов (UML)

```
         +----------------------------------+
         |            Point3D               |
         +----------------------------------+
         | - x, y, z : double               |
         +----------------------------------+
         | + Point3D()                      |
         | + Point3D(x, y, z)               |
         | + X, Y, Z : double {validate}    |
         | + DistanceToOrigin() : double    |
         | + operator +(a, b) : Point3D     |
         | + operator -(a, b) : Point3D     |
         | + operator ==(a, b) : bool       |
         | + operator !=(a, b) : bool       |
         | + virtual GetInfo() : string     |
         | + ToString() : string            |
         +----------------------------------+
                         ▲
                         │ наследование
         +----------------------------------+
         |        ColoredPoint3D            |
         +----------------------------------+
         | + Color : Color                  |
         | + Size  : int                    |
         +----------------------------------+
         | + ColoredPoint3D()               |
         | + ColoredPoint3D(x,y,z,clr,sz)  |
         | + override GetInfo() : string    |
         | + operator +(a, b) : Colored...  |
         +----------------------------------+
```

---

## Поток выполнения MainForm

```
Пользователь вводит X1,Y1,Z1 и X2,Y2,Z2
         │
         ▼
[Кнопка «Создать»]
    │
    ├─► p1 = new Point3D(x1, y1, z1)
    ├─► p2 = new Point3D(x2, y2, z2)
    ├─► cp1 = new ColoredPoint3D(p1.X, p1.Y, p1.Z, selectedColor)
    ├─► cp2 = new ColoredPoint3D(p2.X, p2.Y, p2.Z, Color.Blue)
    │
    └─► Вывод в RichTextBox:
          p1.GetInfo()         → "Point3D (x; y; z)"
          p2.GetInfo()
          (p1 + p2).GetInfo()  → сумма координат
          (p1 - p2).GetInfo()  → разность
          p1 == p2             → bool
          cp1.GetInfo()        → "ColoredPoint3D ... | цвет: Red"
          cp2.GetInfo()
          (cp1 + cp2).GetInfo()

[Кнопка «Инфо»]
    └─► new InfoForm(p1, p2).ShowDialog()
              │
              └─► показ расстояния (p1 - p2).DistanceToOrigin()

[Кнопка «Цвет CP1»]
    └─► ColorDialog → selectedColor = dlg.Color
```

---

## Перегрузка операторов

```
Point3D + Point3D:
  new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z)

ColoredPoint3D + ColoredPoint3D:
  new ColoredPoint3D(a.X+b.X, a.Y+b.Y, a.Z+b.Z, a.Color, a.Size)

Point3D == Point3D:
  a.x==b.x && a.y==b.y && a.z==b.z
```
