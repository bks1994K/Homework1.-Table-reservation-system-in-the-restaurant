namespace Homework1._Table_reservation_system_in_the_restaurant
{
    public static class NumberReservationGenerator
    {
        private static int _currentNumber = 0;

        public static int GetNextNumber()
        {
            _currentNumber = _currentNumber + 1;
            return _currentNumber;
        }
    }
}
