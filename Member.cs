namespace MovieManager
{
    public class Member
    {
        private string firstName;
        private string lastName;
        private string address;
        private int contactNumber;
        private int password;
        private Movie[] holding = new Movie[10];
        private int holdingPointer = 0;
        public Member(string first, string last, string addy, int num, int pass)
        {
            firstName = first;
            lastName = last;
            address = addy;
            contactNumber = num;
            password = pass;
        }
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }
        public string GetUsername()
        {
            return (lastName + firstName);
        }
        public int GetPassword()
        {
            return password;
        }
        public int GetNumHolding()
        {
            return holdingPointer;
        }
        public void RentDVD(Movie rented)
        {
            holding[holdingPointer] = rented;
            holdingPointer++;
        }
        public void ReturnDVD(Movie returning)
        {
            for (int i = 0; i< holdingPointer; i++)
            {
                if (holding[i] == returning)
                {
                    for (int moveDown = i; moveDown < holdingPointer; moveDown++)
                    {
                        holding[moveDown] = holding[moveDown + 1];
                        holding[moveDown + 1] = null;
                    }
                    holdingPointer--;
                    break;
                }
            }
            
        }
        public Movie[] GetHolding()
        {
            return holding;
        }
        public int GetNumber()
        {
            return contactNumber;
        }
    }
}
