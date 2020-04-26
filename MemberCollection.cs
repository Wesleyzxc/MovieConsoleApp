using System;
using System.Collections.Generic;
using System.Text;

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

        public void BorrowMovie()
        {

        }

        public void ReturnMovie()
        {

        }

        public void ListOfMovies(Member member)
        {

        }
    }
}
