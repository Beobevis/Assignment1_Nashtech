namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.In ra màn hình Member có giới tính là Male
            // var malemem = GetMaleMember();
            // PrintData(malemem);

            //2. In ra màn hình Member có tuổi lớn nhất dựa theo Age
            // var oldest = GetOldestMemberbyAge();
            // PrintData(new List<Member> { oldest });

            //2.1 In ra màn hình Member có tuổi lớn nhất dựa theo Năm sinh
            // var oldest = GetOldestMemberbyDOB();
            // PrintData(new List<Member> { oldest });

            //3. In ra List với FullName = FirstName + LastName
            // var fullnames = GetFullName();
            // for(int i = 0; i< fullnames.Count;i++){
            //     string fullname = fullnames[i];
            //     Console.WriteLine($"{i+1}. {fullname}");
            // }

            //4. In ra List với Member theo năm sinh (=2000, >2000, <2000)
            // var results = MemberbyBirthYear();
            // Console.WriteLine("Member by 2000");
            // PrintData(results.Item1);
            // Console.WriteLine("===========================");
            // Console.WriteLine("Member over 2000");
            // PrintData(results.Item2);
            // Console.WriteLine("===========================");
            // Console.WriteLine("Member under 2000");
            // PrintData(results.Item3);

            //5.In ra List Member ở Hà Nội
            var results = GetMembersbyBirthPlace();
            PrintData(results);


        }
        static List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 22),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DOB = new DateTime(2001, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DOB = new DateTime(2000, 11, 6),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DOB = new DateTime(1999, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DOB = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DOB = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Member",
                LastName = "Old",
                Gender = "Male",
                DOB = new DateTime(1996, 1, 14),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };
        static void PrintData(List<Member> data)
        {
            var index = 0;

            foreach (var item in data)
            {
                ++index;
                Console.WriteLine($"{index}. {item.LastName} {item.FirstName} / {item.Gender} / {item.DOB.ToString("dd/MM/yyyy")} / {item.BirthPlace} / [{item.Age}]");
            }


        }

        static List<Member> GetMaleMember()
        {
            var result = new List<Member>();

            foreach (var member in members)
            {
                if (member.Gender == "Male")
                {
                    result.Add(member);
                }
            }
            return result;
        }

        static Member GetOldestMemberbyAge()
        {


            var maxAge = members[0].Age;
            var maxAgeIndex = 0;
            for (int i = 1; i < members.Count; i++)
            {
                var member = members[i];
                if (member.Age > maxAge)
                {
                    maxAge = member.Age;
                    maxAgeIndex = i;
                }
            }
            return members[maxAgeIndex];
        }

        static Member GetOldestMemberbyDOB()
        {
            //Method 1:
            // var maxDays = members[0].TotalDays;
            // var TotaldaysIndex = 0;
            // for(int i = 1; i< members.Count;i++){
            //     var member = members[i];
            //     if(member.TotalDays > maxDays){
            //         maxDays = member.TotalDays;
            //         TotaldaysIndex = i;
            //     }
            // }
            // return members[TotaldaysIndex];
            //method 2(using CompareTo):
            var oldest = members[0];
            for (var i = 1; i < members.Count; i++)
            {
                var member = members[i];
                if (member.CompareTo(oldest) > 0)
                {
                    oldest = member;
                }
            }
            return oldest;
        }

        static List<string> GetFullName()
        {
            //Method 1:
            var result = new List<string>();

            foreach (var member in members)
            {
                result.Add($"{member.LastName} {member.FirstName}");
            }

            //Method 2:
            // foreach(var member in members){
            //     result.Add(member.FullName);
            // }

            return result;
        }

        static Tuple<List<Member>, List<Member>, List<Member>> MemberbyBirthYear()
        {

            var list1 = new List<Member>();
            var list2 = new List<Member>();
            var list3 = new List<Member>();

            foreach (var member in members)
            {
                var birthYear = member.DOB.Year;
                switch (birthYear)
                {
                    case 2000:
                        list1.Add(member);
                        break;
                    case > 2000:
                        list2.Add(member);
                        break;
                    case < 2000:
                        list3.Add(member);
                        break;
                }
            }

            return Tuple.Create(list1, list2, list3);
        }

        static List<Member> GetMembersbyBirthPlace()
        {
            var result = new List<Member>();

            foreach (var member in members)
            {
                if (member.BirthPlace.Equals("Ha Noi", StringComparison.CurrentCultureIgnoreCase))
                {
                    result.Add(member);
                }
            }
            return result;
        }

    }

}






