namespace Lab6_Variant6
{
    // Пользовательский интерфейс — контракт для всех «персон»
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
