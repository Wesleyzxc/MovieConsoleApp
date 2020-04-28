namespace MovieManager
{
    public class MemberCollection
    {
        private Member[] memberArr = new Member[10];
        private int pointer = 0;
        public void RegisterMember(Member member)
        {
            if (pointer < 10)
            {
                memberArr[pointer] = member;
                pointer++;
            }
        }
        public Member GetMember(int i)
        {
            return memberArr[i];
        }
        public Member GetMember(string user)
        {
            for (int i = 0; i< pointer; i++)
            {
                if (memberArr[i].GetUsername() == user)
                    return memberArr[i];
            }
            return null;
        }

        public int GetNumMembers()
        {
            return pointer;
        }
        public int GetPhoneNumber(string first, string last)
        {
            for(int i = 0; i < pointer; i++)
            {
                if (first == memberArr[i].GetFirstName() && last == memberArr[i].GetLastName())
                {

                    return memberArr[i].GetNumber();
                }
            }
            return 0;
        }
    }
}
