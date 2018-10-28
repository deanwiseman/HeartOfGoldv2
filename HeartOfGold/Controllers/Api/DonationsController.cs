using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using HeartOfGold.Models;
using HeartOfGold.Dtos;
using AutoMapper;
using System.Net.Http;

namespace HeartOfGold.Controllers.Api
{
    public class DonationsController : ApiController
    {
        private ApplicationDbContext _context;

        public DonationsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/donations
        public IHttpActionResult GetDonations()
        {
            var donationDtos = _context.Items.ToList().Select(Mapper.Map<Item, DonationDto>);

            return Ok(donationDtos);
        }

        // GET /api/donations/1
        public IHttpActionResult GetDonation(int id)
        {
            var donation = _context.Items.SingleOrDefault(i => i.Id == id);

            if (donation == null)
                return NotFound();

            return Ok(Mapper.Map<Item, DonationDto>(donation));
        }

        // POST /api/donations
        [HttpPost]
        public IHttpActionResult CreateDonation(DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var donation = Mapper.Map<DonationDto, Item>(donationDto);

            _context.Items.Add(donation);
            _context.SaveChanges();

            donationDto.Id = donation.Id;

            return Created(new Uri(Request.RequestUri + "/" + donation.Id), donationDto);

        }

        // PUT /api/donations/1
        [HttpPut]
        public IHttpActionResult UpdateDonation(int id, DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var donationInDb = _context.Items.SingleOrDefault(i => i.Id == id);

            if (donationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(donationDto, donationInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/donations/1
        // This is a soft delete.
        [HttpPut]
        public IHttpActionResult DeleteDonation(int id, DonationDto donationDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var donationInDb = _context.Items.SingleOrDefault(i => i.Id == id);

            if (donationInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            donationInDb.IsActive = false;
            donationInDb.Quantity = 0;

            Mapper.Map(donationDto, donationInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
