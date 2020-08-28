namespace Lesson7.Extend
{
    public static class Obj
    {
        public static T As<T>(this object value)
        {
            if (!(value is T))
            {
                return default;
            }

            // cast
            return (T)value;
        }
    }
}
