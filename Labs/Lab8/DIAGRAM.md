# Схема работы — Lab8. Вариант 6

---

## Структура класса Teacher

```
<<delegate>>
 TeacherDelegate(Teacher t)

+--------------------------------------------+
|                  Teacher                   |
+--------------------------------------------+
| + FirstName  : string                      |
| + LastName   : string                      |
| + Gender     : string ("М" / "Ж")         |
| + BirthYear  : int                         |
| + Experience : int                         |
| + Position   : string                      |
+--------------------------------------------+
| + Age : int  { get => Now.Year - BirthYear }|
| + IsPensioner() : bool                     |
|     М: Age >= 65,  Ж: Age >= 60           |
| + event OnPensionerDetected: TeacherDeleg. |
| + CheckPensioner() : void                  |
| + static GetExperienceFilter(int)          |
|     : Func<Teacher, bool>                  |
+--------------------------------------------+
```

---

## Поток работы события OnPensionerDetected

```
[Кнопка «Пров. пенсионеров»]
    │
    └─ foreach (Teacher t in teachers)
            │
            ├─ Подписаться на событие:
            │   t.OnPensionerDetected += t2 => MessageBox.Show(...)
            │
            ├─ t.CheckPensioner()
            │       │
            │       ├─ IsPensioner()? ─► Нет  → ничего
            │       └─ IsPensioner()? ─► Да   → вызвать событие
            │                               → MessageBox: "Пенсионер!"
            └─ t.OnPensionerDetected = null  (отписаться)
```

---

## Поток работы Func<Teacher,bool> (фильтр)

```
[Кнопка «Фильтр по стажу»]
    │
    ├─ int minExp = (int)nudMinExp.Value
    │
    ├─ var filter = Teacher.GetExperienceFilter(minExp)
    │            │
    │            └─ возвращает: t => t.Experience >= minExp
    │
    └─ var filtered = teachers.Where(t => filter(t)).ToList()
               │
               └─ RefreshList(filtered)
```

---

## Поток работы сортировки (лямбда)

```
[Кнопка «Сорт (лямбда)»]
    │
    └─ teachers.Sort((a, b) => string.Compare(a.LastName, b.LastName))
                │
                └─ Лямбда сравнивает фамилии алфавитно
                └─ RefreshList()
```
