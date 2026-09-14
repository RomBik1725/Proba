# Схема работы — Lab9. Вариант 6

---

## Структура класса Car

```
+---------------------------------------+
|                  Car                  |
+---------------------------------------+
| + Brand   : string                    |
| + Model   : string                    |
| + Year    : int                       |
| + Color   : string                    |
| + Mileage : double                    |
+---------------------------------------+
| + Car()                               |
| + Car(brand, model, year, clr, miles) |
| + GetKey() : string                   |
|     => $"{Brand}_{Model}_{Year}"      |
| + ToString() : string                 |
+---------------------------------------+
```

---

## Структура Dictionary

```
Dictionary<string, Car>
┌──────────────────────────────────────────┐
│ Ключ                    Значение            │
│ "Toyota_Camry_2018"   →  Car(Toyota,Camry,2018) │
│ "BMW_X5_2020"         →  Car(BMW,X5,2020)       │
│ "Honda_Civic_2017"    →  Car(Honda,Civic,2017)  │
│ ...                  →  ...                   │
└──────────────────────────────────────────┘
Добавление: cars[car.GetKey()] = car
Проверка: cars.ContainsKey(key)
Удаление: cars.Remove(key)
```

---

## LINQ-операции

```
Сортировка по году:
  cars.Values
      .OrderBy(c => c.Year)
      .ToList()

Фильтр по поиску:
  cars.Values
      .Where(c => c.Brand.ToLower().Contains(q)
               || c.Model.ToLower().Contains(q))

Удалить старые:
  foreach (key in cars.Keys.ToList())
      if (cars[key].Year < cutYear) cars.Remove(key)

LINQ статистика:
  Average(c => c.Mileage)                   → средний пробег
  Select(c => c.Brand).Distinct().Count()   → уникальные марки
  MaxBy(c => c.Year)                        → новейшая модель
```

---

## Общая схема работы

```
[MainForm] хранит Dictionary<string, Car>
    │
    ├─► [Добавить]          → new Car(...), cars[key] = car
    ├─► [Удалить выбранный] → cars.Remove(keys[index])
    ├─► [Удалить старые]    → все с Year < cutYear
    ├─► [По году]          → LINQ OrderBy Year
    ├─► [По пробегу]        → LINQ OrderBy Mileage
    ├─► [Найти]             → LINQ Where Contains
    ├─► [LINQ статистика]   → Average, Distinct, MaxBy → MessageBox
    └─► [Все / Сброс]       → RefreshList(all)
```
