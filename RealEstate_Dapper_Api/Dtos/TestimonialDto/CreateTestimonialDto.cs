﻿namespace RealEstate_Dapper_Api.Dtos.TestimonialDto
{
    public class CreateTestimonialDto
    {
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool TestimonialStatus { get; set; }
    }
}
