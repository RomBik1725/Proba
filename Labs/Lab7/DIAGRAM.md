# Схема работы — Lab7. Вариант 6

---

## Структура классов

```
+------------------------+         +------------------------+
|     GraphSettings      |    1..* |     SettingsDialog     |
+------------------------+ <────── +------------------------+
| + CurveType : int      |         | - lbColors: ListBox    |
| + LineColor : Color    |         | - lbCurves: ListBox    |
| + LineWidth : float    |         | - nudCount: NumUpDown  |
| + XMin/XMax: double    |         | + Result: List<GS>     |
| + YMin/YMax: double    |         | + BtnOk_Click()        |
+------------------------+         +------------------------+
             ▲
       хранится в
+----------------------------------+
|           MainForm               |
+----------------------------------+
| - graphSettings: List<GS>        |
| - pnlDraw: Panel                 |
+----------------------------------+
| + miSelectLines_Click()          |
| + miPlot_Click()                 |
| + miClear_Click()                |
| + pnlDraw_Paint(Graphics g)      |
| + DrawCurve(g, pen, settings...) |
+----------------------------------+
```

---

## Поток выполнения

```
Пользователь нажимает «Выбор линий»
    │
    ▼
new SettingsDialog().ShowDialog()
    │
    ├─ Пользователь выбирает:
    │   сколько линий (1–5)
    │   цвет [Синий|Красный|Зеленый|Чёрный|Пурпурный]
    │   кривая [Прямая|Парабола|Гипербола|Окружн.|Роза]
    │   диапазон X и Y
    │   жмёт «OK» → Result = List<GraphSettings>
    │
    ▼
graphSettings = dlg.Result
pnlDraw.Invalidate()
    │
    ▼
pnlDraw_Paint(Graphics g)
    │
    ├─ Нарисовать оси X и Y
    │
    └─ Для каждого GraphSettings:
            DrawCurve(g, pen, settings)
                │
                ├─ CurveType=0: y=x          (по точкам x в [XMin..XMax])
                ├─ CurveType=1: y=x²
                ├─ CurveType=2: y=1/x        (с разрывом при x≈0)
                ├─ CurveType=3: окружность  (t: 0..2π)
                └─ CurveType=4: роза         (r=a·cos(3t), t: 0..2π)
                            │
                            └─ g.DrawLines(pen, points[])
```

---

## Преобразование координат (мир → экран)

```
Математические (x, y)
         │
         ▼
  scr_x = cx + (int)(x * sx)    cx = Width/2
  scr_y = cy - (int)(y * sy)    cy = Height/2
                                 sx = Width  / (XMax - XMin)
                                 sy = Height / (YMax - YMin)
```
