# Схема работы — Lab10. Вариант 6

---

## Структура формы

```
MainForm
├── grpFile
│    ├── nudCount (кол-во точек: 5..100)
│    └── btnGenerate («Сгенерировать»)
├── grpSphere
│    ├── nudCX, nudCY, nudCZ (центр сферы)
│    ├── nudRadius (радиус)
│    └── btnCheck («Проверить»)
├── rtbOutput (вывод результатов)
└── lblStatus (строка статуса)
```

---

## Генерация файла (btnGenerate_Click)

```
Пользователь задаёт N, нажимает «Сгенерировать»
    │
    ▼
 BinaryWriter → файл "points3d.dat"
    ├─ Write(N : int)                  ← всего точек
    └─ цикл 0..N-1:
          Write(x : double)           ← случайное [−0..20 * 0.5]
          Write(y : double)
          Write(z : double)
    │
    ▼
 BinaryReader → прочитать и отобразить в rtbOutput
```

---

## Поиск в сфере (btnCheck_Click)

```
Пользователь задаёт CX, CY, CZ, R, нажимает «Проверить»
    │
    ▼
 Файл "points3d.dat" существует?
    ├─ НЕТ → MessageBox "Сначала сгенерируйте"
    └─ ДА →
            BinaryReader → ReadInt32()  (= N)
            цикл 0..N-1:
                x = ReadDouble()
                y = ReadDouble()
                z = ReadDouble()
                │
                └─ dist = √((x-cx)²+(y-cy)²+(z-cz)²)
                        │
                        ├─ dist <= R?
                        │   ► ДА:  inside++
                        │          rtbOutput += "[IN] P{i}: ..."
                        └─ dist > R?
                            ► не выводится
            │
            ▼
        rtbOutput += "Итог: inside из total"
        lblStatus = "..."
```

---

## Формат бинарного файла points3d.dat

```
Байты   0–3   : int32  = N (кол-во точек)
Байты   4–11  : double = x1
Байты  12–19  : double = y1
Байты  20–27  : double = z1
Байты  28–35  : double = x2
... и так далее (N тройк) ...

Общий размер: 4 + N * 24 байта
```
