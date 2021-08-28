using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO;
using AutoMapper;
using Data;
using Data.Entity;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class MembershipController : BaseApiController
    {
        private readonly MembershipRepository membershipRepository;
        private readonly IMapper _mapper;
        public MembershipController(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            membershipRepository = new MembershipRepository(dataContext);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembershipDTO membershipDTO)
        {
            Membership membership = new Membership();
            _mapper.Map(membershipDTO, membership);

            await membershipRepository.AddAsync(membership);

            return Ok();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembershipDTO>> GetAction(string id)
        {
            var membership = await membershipRepository.GetDetailAsync(id);

            if (membership == null)
            {
                return NotFound();
            }

            MembershipDTO membershipDTO = new MembershipDTO();
            _mapper.Map(membership, membershipDTO);

            return Ok(membershipDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MembershipDTO>>> List()
        {
            var memberships = await membershipRepository.ListAsync();

            IEnumerable<MembershipDTO> membershipsDTO = new List<MembershipDTO>();

            _mapper.Map(memberships, membershipsDTO);

            return Ok(membershipsDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, MembershipDTO membershipDTO)
        {
            Membership membership = await membershipRepository.GetDetailAsync(id);

            if (membership == null)
            {
                return NotFound();
            }

            membershipDTO.MembershipCode = id;

            _mapper.Map(membershipDTO, membership);

            await membershipRepository.UpdateAsync(membership);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            Membership membership = await membershipRepository.GetDetailAsync(id);

            if (membership == null)
            {
                return NotFound();
            }

            await membershipRepository.DeleteAsync(membership);

            return Ok();

        }

    }
}