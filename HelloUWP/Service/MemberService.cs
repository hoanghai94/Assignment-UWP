using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloUWP.Entity;

namespace HelloUWP.Service
{
    interface MemberService
    {
        String Login(String email, String password);
        Member Register(Member member);
        Member GetInformation();
    }
}
