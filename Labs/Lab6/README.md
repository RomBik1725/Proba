# Лабораторная работа №6. Вариант 6
## Тема: Интерфейсы. ICloneable. IComparable.

---

## 📁 Файлы
| Файл | Описание |
|------|----------|
| `Lab6_Variant6.csproj` | Файл проекта Visual Studio |
| `Program.cs` | Точка входа |
| `Classes/IPerson.cs` | Интерфейс `IPerson` |
| `Classes/Person.cs` | Базовый класс |
| `Classes/Schoolchild.cs` | Школьник |
| `Classes/Student.cs` | Студент |
| `Classes/Teacher.cs` | Преподаватель |
| `Forms/MainForm.cs` | Главная форма |
| `Forms/MainForm.Designer.cs` | Разметка формы |
| `task_lab6.pdf` | Задание лабораторной работы |

---

## ▶️ Как запустить
1. Открыть `Lab6_Variant6.csproj` в **Visual Studio 2022**
2. Нажать **F5**
3. Откроется главное окно со списком персон

### Управление
| Кнопка | Действие |
|--------|----------|
| **Добавить** | Создать новую персону (школьник/студент/преп.) |
| **Клонировать** | Создать глубокую копию выбранной персоны (`ICloneable`) |
| **Сортировать** | Сортировка по фамилии (`IComparable`) |
| **Сравнить** | Сравнение выбранного с другим |
| **Удалить** | Удалить выбранного |
| **Выход** | Закрыть программу |

---

## 🏗️ Устройство программы

### Интерфейс `IPerson`
```csharp
public interface IPerson : ICloneable, IComparable<IPerson>
{
    string GetInfo();
}
```

### Классы
- **`Person`** — базовый абстрактный, реализует `IPerson`
- **`Schoolchild : Person`** — Grade, School; `Clone()` — глубокая копия
- **`Student : Person`** — Group, University, Course; аналогично
- **`Teacher : Person`** — Position, Experience; аналогично

### `IComparable<IPerson>` — сортировка по фамилии
```csharp
public int CompareTo(IPerson? other) =>
    string.Compare(LastName, (other as Person)?.LastName);
```

---

## 🔑 Ключевые концепции
- **Интерфейс**: `IPerson : ICloneable, IComparable<IPerson>`
- **`ICloneable.Clone()`**: глубокая копия объекта
- **`IComparable.CompareTo()`**: сравнение по фамилии для сортировки

Схема программы: см. `DIAGRAM.md`
