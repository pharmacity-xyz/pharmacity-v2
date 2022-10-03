using DataAccess;
using DataAccess.DTO;
using DataAccess.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implements
{
    public class MemberRepository : IMemberRepository
    {
        public void Add(MemberDTO member)
        {
            MemberDAO.Instance.SaveMember(Mapper.mapToEntity(member));
        }

        public List<MemberDTO> GetAll()
        {
            return MemberDAO.Instance.FindAll().Select(m => Mapper.mapToDTO(m)).ToList();
        }

        public MemberDTO GetLoggedAccount()
        {
            throw new NotImplementedException();
        }

        public MemberDTO Login(string email, string password)
        {
            return Mapper.mapToDTO(MemberDAO.Instance.FindMemberByEmailPassword(email, password));
        }

        public void Update(MemberDTO member)
        {
            MemberDAO.Instance.UpdateMember(Mapper.mapToEntity(member));
        }
    }
}
