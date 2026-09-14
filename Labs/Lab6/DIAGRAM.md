# Схема работы — Lab6. Вариант 6

---

## Иерархия интерфейсов и классов (UML)

```
<<interface>>              <<interface>>         <<interface>>
 ICloneable                IComparable<IPerson>    IPerson
 + Clone():object          + CompareTo():int    ◄── + GetInfo():string
      ▲                        ▲                └── ICloneable
       └─────────────────────────┘                └── IComparable
                             ▲
                    +------------------+
                    |  Person(abstract)|   реализует IPerson
                    +------------------+
                    | + FirstName      |
                    | + LastName       |
                    | + BirthYear      |
                    | + Age (вычисл.)  |
                    +------------------+
                    | + GetInfo()      |
                    | + Clone()        |
                    | + CompareTo()    |
                    +------------------+
               ▲            ▲            ▲
               │            │            │
      +---------+--+ +-------+----+ +----+---------+
      |Schoolchild | |  Student   | |   Teacher    |
      +------------+ +------------+ +--------------+
      |Grade: int  | |Group: str  | |Position: str |
      |School: str | |Univer: str | |Experien: int |
      +------------+ +Course: int-+ +--------------+
      |Clone()     | |Clone()     | |Clone()       |
      |GetInfo()   | |GetInfo()   | |GetInfo()     |
      +------------+ +------------+ +--------------+
```

---

## Работа ICloneable

```
[Кнопка «Клонировать»]
    │
    ├─ persons[i].Clone()            ← вызов через интерфейс ICloneable
    │       │
    │       ├─ Schoolchild.Clone() → new Schoolchild { ...deepCopy }
    │       ├─ Student.Clone()     → new Student { ...deepCopy }
    │       └─ Teacher.Clone()     → new Teacher { ...deepCopy }
    │
    └─ persons.Add(clone)  → добавить копию в список
```

---

## Работа IComparable (сортировка)

```
[Кнопка «Сортировать»]
    │
    └─ persons.Sort()
           │
           └─ для каждой пары (a, b):
                  a.CompareTo(b)
                    │
                    └─ string.Compare(a.LastName, b.LastName)
                           │
                           ├─ < 0  → a стоит раньше
                           ├─ = 0  → равны
                           └─ > 0  → b стоит раньше
```

---

## Общая схема работы

```
[MainForm]
    │
    ├─► Список: List<IPerson> persons
    │
    ├─► [Добавить]     → AddPersonForm → persons.Add()
    ├─► [Клонировать]  → ICloneable.Clone() → persons.Add(clone)
    ├─► [Сортировать]  → IComparable.CompareTo() → RefreshList()
    ├─► [Сравнить]    → a.CompareTo(b) → MessageBox
    ├─► [Удалить]     → persons.Remove()
    └─► [Выход]       → Application.Exit()
```
