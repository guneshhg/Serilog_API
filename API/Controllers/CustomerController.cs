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
    public class CustomerController : BaseApiController
    {
        private readonly CustomerRepository customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(DataContext dataContext, IMapper mapper)
        {
            _mapper = mapper;
            customerRepository = new CustomerRepository(dataContext);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDTO customerDTO)
        {
            Customer customer = new Customer();
            _mapper.Map(customerDTO, customer);

            await customerRepository.AddAsync(customer);

            return Ok(customer.Id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> Get(int id)
        {
            var customer = await customerRepository.GetDetailAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            CustomerDTO customerDTO = new CustomerDTO();
            _mapper.Map(customer, customerDTO);

            return Ok(customerDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> List()
        {
            var customers = await customerRepository.ListAsync();

            IEnumerable<CustomerDTO> customersDTO = new List<CustomerDTO>();

            _mapper.Map(customers, customersDTO);

            return Ok(customersDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDTO customerDTO)
        {
            Customer customer = await customerRepository.GetDetailAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            customerDTO.Id = id;

            _mapper.Map(customerDTO, customer);

            await customerRepository.UpdateAsync(customer);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await customerRepository.GetDetailAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            await customerRepository.DeleteAsync(customer);

            return Ok();
        }

    }
}