# Лабораторная работа №8. Вариант 6
## Тема: Делегаты. События. Лямбда-выражения.

---

## 📁 Файлы
| Файл | Описание |
|------|----------|
| `Lab8_Variant6.csproj` | Файл проекта Visual Studio |
| `Program.cs` | Точка входа |
| `Classes/Teacher.cs` | Класс `Teacher` + делегат |
| `Forms/MainForm.cs` | Главная форма |
| `Forms/MainForm.Designer.cs` | Разметка формы |
| `task_lab8.pdf` | Задание лабораторной работы |

---

## ▶️ Как запустить
1. Открыть `Lab8_Variant6.csproj` в **Visual Studio 2022**
2. Нажать **F5**
3. Откроется форма со списком преподавателей (5 заранее загружено)

### Управление
| Кнопка | Действие |
|--------|----------|
| **Пров. пенсионеров** | Для каждого преподавателя срабатывает событие `OnPensionerDetected` |
| **Фильтр по стажу** | `Func<Teacher,bool>` — оставить только с опытом ≥ N лет |
| **Сорт (лямбда)** | Сортировка списка по фамилии через лямбда-выражение |
| **Сбросить** | Вернуть исходный список |
| **Выход** | Закрыть программу |

---

## 🏗️ Устройство программы

### Класс `Teacher` (Classes/Teacher.cs)
```csharp
// Делегат
 public delegate void TeacherDelegate(Teacher t);

// Событие
 public event TeacherDelegate? OnPensionerDetected;

// Фабрика фильтров
 public static Func<Teacher,bool> GetExperienceFilter(int minExp)
     => t => t.Experience >= minExp;
```

- **`Age`** — вычисляется как `DateTime.Now.Year - BirthYear`
- **`IsPensioner()`** — М ≥ 65 лет или Ж ≥ 60 лет
- **`CheckPensioner()`** — срабатывает `OnPensionerDetected`, если условие верно

### `MainForm` (Forms/MainForm.cs)
- `List<Teacher> teachers` — список из 5 преподавателей (hard-coded)
- Отображается в `ListBox`

---

## 🔑 Ключевые концепции
- **Делегат**: `delegate void TeacherDelegate(Teacher t)`
- **Событие**: `event TeacherDelegate OnPensionerDetected`
- **`Func<T,bool>`**: заводская фабрика фильтров
- **Лямбда-выражения**: сортировка `(a,b) => string.Compare(a.LastName, b.LastName)`

Схема программы: см. `DIAGRAM.md`
