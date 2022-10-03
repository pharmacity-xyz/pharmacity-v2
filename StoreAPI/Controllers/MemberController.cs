using BusinessObjects.Models;
using DataAccess.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Implements;
using StoreAPI.Storage;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly IMemberRepository memberRepository;

        public MemberController(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        [HttpPost("login")]
        public IActionResult Login(MemberDTO memberDTO)
        {
            try
            {
                if (memberDTO.Email.Equals("") && memberDTO.Password.Equals("")) {                 
                    throw new Exception("Email and Password cannot be empty");
                }
                else
                {
                    if (memberDTO.Email.Equals("")) throw new Exception("Email cannot be empty");
                    if (memberDTO.Password.Equals("")) throw new Exception("Password cannot be empty");
                }
                

                MemberDTO member = memberRepository.Login(memberDTO.Email, memberDTO.Password);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("changePassword")]
        public IActionResult changePass(string email, string password, string newPassword, string confirmNewPassword)
        {
            try
            {
                MemberDTO member = memberRepository.Login(email, password);

                if (!confirmNewPassword.Equals(newPassword)) throw new Exception("Confirm password does not match new password");

                member.Password = newPassword;

                memberRepository.Update(member);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("logout")]
        public IActionResult logout()
        {
            try
            {
                LoggedUser.Instance.User = null;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("loggedMember")]
        public IActionResult loggedUser()
        {
            try
            {
                return Ok(LoggedUser.Instance.User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public IActionResult register(MemberDTO memberDTO)
        {
            try
            {
                //if (memberDTO.Email.Equals("") && memberDTO.Password.Equals(""))
                //{
                //    throw new Exception("Email and Password cannot be empty");
                //}
                //else
                //{
                //    if (memberDTO.Email.Equals("")) throw new Exception("Email cannot be empty");
                //    if (memberDTO.Password.Equals("")) throw new Exception("Password cannot be empty");
                //}

                memberDTO.Role = Role.USER.ToString();
                memberRepository.Add(memberDTO);

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("edit")]
        public IActionResult edit(
            string newCompany,
            string newCity,
            string newCountry
        )
        {
            try
            {
                MemberDTO member = LoggedUser.Instance.User;

                if (member == null)
                {
                    throw new Exception("Can't do this action");
                }

                member.City = newCity;
                member.Country = newCountry;
                member.CompanyName = newCompany;

                memberRepository.Update(member);

                LoggedUser.Instance.User = member;

                return Ok(LoggedUser.Instance.User);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                List<MemberDTO> memberDTOs = memberRepository.GetAll();
                return Ok(memberDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
