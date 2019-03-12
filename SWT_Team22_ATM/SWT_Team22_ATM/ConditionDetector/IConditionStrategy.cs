namespace SWT_Team22_ATM.ConditionDetector
{
    public interface IConditionStrategy<T>
    {

        bool ConditionBetween(T check, T comparedTo);
    }
}