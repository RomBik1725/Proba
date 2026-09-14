# Схема работы — Lab3. Вариант 6

---

## Структура формы MainForm

```
MainForm
├── Panel pnlDraw          (область анимации, событие Paint)
├── Timer timer1           (тик → перерисовка)
├── TrackBar trbSpeed      (скорость: 1..10)
├── CheckBox chkPause      (пауза)
├── RadioButton rbRed      (цвет: красный)
├── RadioButton rbGreen    (цвет: зелёный)
├── RadioButton rbBlue     (цвет: синий)
├── Button btnReset        (сброс настроек)
├── Button btnInfo         (информация)
└── Button btnExit         (выход)
```

---

## Поток событий

```
Запуск приложения
    │
    ▼
MainForm.InitializeComponent()
    │  Создание всех контролов
    │  Timer.Interval = 100 мс
    │  Timer.Start()
    ▼
┌──────────────────────────────┐
│  Цикл (каждые N мс)          │
│  Timer.Tick                  │
│    │                         │
│    ├─ Обновить позицию       │
│    │  объекта (x += dx)      │
│    │                         │
│    └─ panel.Invalidate()     │
│         │                    │
│         ▼                    │
│  panel_Paint(Graphics g)     │
│    └─ g.FillEllipse(...)     │ ◄── цвет из RadioButton
└──────────────────────────────┘
         ↑
         │
   TrackBar изменён
   trbSpeed_Scroll()
         │
         └─► Timer.Interval = 200 - value*18

   CheckBox изменён
   chkPause_CheckedChanged()
         │
         ├─► checked=true  → Timer.Stop()
         └─► checked=false → Timer.Start()
```

---

## Взаимодействие компонентов

```
[TrackBar] ──скорость──► [Timer.Interval]
[CheckBox] ──пауза──────► [Timer.Enabled]
[RadioButton] ──цвет──► [selectedColor]
                              │
[Timer.Tick] ──► position++ ─┤
                              ▼
                    [panel.Invalidate()] ──► [Paint] ──► экран
```
