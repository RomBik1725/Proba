# Схема работы — Lab5. Вариант 6

---

## Иерархия классов (UML)

```
+----------------------------------------+
|          Person  (abstract)            |
+----------------------------------------+
| + FirstName : string                   |
| + LastName  : string                   |
| + BirthYear : int                      |
| + Age       : int  (вычисляемое)       |
+----------------------------------------+
| + Person(fn, ln, by)                   |
| + virtual GetInfo() : string           |
| + ToString() : string                  |
+----------------------------------------+
           ▲           ▲           ▲
           │           │           │
+----------+--+ +------+------+ +--+----------+
| Schoolchild | |   Student   | |   Teacher   |
+-------------+ +-------------+ +-------------+
| Grade:int   | | Group:string| | Position:str|
| School:str  | | Univer.:str | | Experien:int|
|             | | Course: int | |             |
+-------------+ +-------------+ +-------------+
| GetInfo()   | | GetInfo()   | | GetInfo()   |
+-------------+ +-------------+ +-------------+
```

---

## Поток выполнения

```
MainForm
    │
    ├─► Список persons = List<Person>  (загружены примеры)
    │
    │  [Кнопка «Добавить»]
    ├─► AddPersonForm.ShowDialog()
    │       │
    │       ├─ Тип: Школьник → new Schoolchild(...)
    │       ├─ Тип: Студент  → new Student(...)
    │       └─ Тип: Преп.   → new Teacher(...)
    │       └─► persons.Add(result)
    │           lbPersons.Items.Add(result.ToString())
    │
    │  [Кнопка «Инфо»]
    ├─► persons[selectedIndex].GetInfo()
    │       │
    │       └─ Полиморфный вызов нужной версии GetInfo()
    │
    │  [Кнопка «Сортировать»]
    └─► persons.Sort()  →  сравнение по LastName
```

---

## Полиморфизм GetInfo()

```
List<Person> persons = [
  Schoolchild { ... },   // Person
  Student     { ... },   // Person
  Teacher     { ... },   // Person
]

foreach (Person p in persons)
    Console.WriteLine(p.GetInfo());
              │
              ├─ если Schoolchild → Schoolchild.GetInfo()
              ├─ если Student     → Student.GetInfo()
              └─ если Teacher     → Teacher.GetInfo()
              (позднее связывание — определяется во время выполнения)
```
