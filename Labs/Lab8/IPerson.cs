namespace Lab8_Variant6
{
    // Интерфейс перенесён из ЛР №6 без изменений
    interface IPerson
    {
        string FirstName { get; }
        string LastName  { get; }
        int    BirthYear { get; }
        int    Age();
        bool   IsPensioner();
        string GetRole();
    }
}
