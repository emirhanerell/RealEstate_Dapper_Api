﻿namespace RealEstate_Dapper_Api.Dtos.TestimonialDto
{
    public class UpdateTestimonialDto
    {
        public int TestimonialID { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
